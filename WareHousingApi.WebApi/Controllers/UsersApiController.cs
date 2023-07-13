using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common;
using WareHousingApi.Common.Api;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Entities;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IMapper _map;

        public UsersApiController(IUnitOfWork context, UserManager<ApplicationUsers> userManager, IMapper map)
        {
            _context = context;
            _userManager = userManager;
            _map = map;
        }


        [HttpGet("GetUsers")]
        public ApiResult<IEnumerable<ApplicationUsers>> Get()
        {
            var userList = _context.userManagerUW.Get();
            return Ok(userList);
        }


        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApplicationUsers), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<ApplicationUsers> GetById([FromQuery] string userid)
        {
            var user = _context.userManagerUW.GetById(userid);
            return Ok(user);
        }

        [HttpPost]
        [Route("CreateUserApi")]
        public async Task<ApiResult<string>> Create([FromForm] UserCreateModel model)
        {
            //کنترل ولید بودن مدل
            if (!ModelState.IsValid || model.UserInWareHouseIDC == null)
                return BadRequest();
            //کنترل تکراری نبودن اطلاعات
            var getUser = _context.userManagerUW.Get(u => u.UserName == model.UserNameC || u.PhoneNumber == model.PhoneNumberC);
            if (getUser.Count() > 0)
            {
                //تکراری
                return BadRequest("ثبت تکراری");
            }
            try
            {
                ApplicationUsers U = new ApplicationUsers
                {
                    FirstName = model.FirstNameC,
                    Family = model.FamilyC,
                    PhoneNumber = model.PhoneNumberC,
                    UserName = model.UserNameC,
                    UserImage = model.UserImageC,
                    Gender = model.GenderC,
                    UserType = 2,
                    MelliCode = model.MelliCodeC,
                    BirthDayDate = ConvertDate.ConvertShamsiToMiladi(model.BirthDayDateC),
                    PersonalCode = model.PersonalCodeC,
                    CreateDateTime = DateTime.Now
                };
                //ایجاد کاربر
                IdentityResult result = await _userManager.CreateAsync(U, "123456");
                if (result.Succeeded)
                {
                    //تنظیم نقش کاربر
                    if (U.UserType == 1)
                    {
                        await _userManager.AddToRoleAsync(U, "admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(U, "user");
                    }
                }
                //ثبت اطلاعات انبار کاربر
                for (int i = 0; i < model.UserInWareHouseIDC.Count(); i++)
                {
                    UserInWareHouse_Tbl UW = new UserInWareHouse_Tbl
                    {
                        CreateDateTime = DateTime.Now,
                        UserIDInWareHouse = U.Id,
                        WareHouseID = model.UserInWareHouseIDC[i],
                        UserID = model.UserID
                    };
                    _context.userInWareHouseUW.Create(UW);
                }
                _context.Save();
                //
                return Ok(U);
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        [ProducesResponseType(typeof(ApplicationUsers), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResult<string>> Update([FromForm] UserEditModel model)
        {
            if (string.IsNullOrEmpty(model.UserId) || model.UserInWareHouseID == null) return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var getUser = await _userManager.FindByIdAsync(model.UserIDWareHouse);
                if (getUser != null)
                {
                    //ویرایش انبارهایی که کاربر دسترسی دارد
                    _context.userInWareHouseUW.DeleteByRange(_context.userInWareHouseUW.Get(u => u.UserIDInWareHouse == model.UserIDWareHouse));
                    //ثبت اطلاعات انبار کاربر
                    for (int i = 0; i < model.UserInWareHouseID.Count(); i++)
                    {
                        UserInWareHouse_Tbl UW = new UserInWareHouse_Tbl
                        {
                            CreateDateTime = DateTime.Now,
                            UserIDInWareHouse = model.UserIDWareHouse,
                            WareHouseID = model.UserInWareHouseID[i],
                            UserID = model.UserId
                        };
                        _context.userInWareHouseUW.Create(UW);
                    }
                    _context.Save();

                    model.BirthDayDate = ConvertDate.ConvertShamsiToMiladi(model.BirthDayDate) + "";
                    var mapModel = _map.Map(model, getUser);

                    IdentityResult result = await _userManager.UpdateAsync(mapModel);
                    if (result.Succeeded)
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return BadRequest();
        }


        [HttpGet("GetUserWareHouseDropDownApi")]
        public ApiResult<IEnumerable<int>> GetUserWareHouseDropDown(string useridinwarehouse)
        {
            //لیست انبارهایی که کاربر به اطلاعات آنها دسترسی دارد
            var UserWareHouseList = _context.userInWareHouseUW.Get(u => u.UserIDInWareHouse == useridinwarehouse);

            return Ok(UserWareHouseList.Select(s => s.WareHouseID));
        }

        [HttpPost]
        [Route("InsertAccessApi")]
        public async Task<ApiResult<string>> InsertAccess([FromForm] UserAccessModel model)
        {
            try
            {
                //دریافت اطلاعات یوزر
                var getUser = await _userManager.FindByIdAsync(model.UserIdAccess);
                //پیدا کردن رول های کاربر
                var roles = await _userManager.GetRolesAsync(getUser);
                //حذف همه رول های کاربر
                IdentityResult deleteAllrole = await _userManager.RemoveFromRolesAsync(getUser, roles);
                //ثبت مجدد دسترسی ها
                if (model.InvoiceList == "on") await _userManager.AddToRoleAsync(getUser, "InvoiceList");
                if (model.Inventory == "on") await _userManager.AddToRoleAsync(getUser, "Inventory");
                if (model.CreateInvoice == "on") await _userManager.AddToRoleAsync(getUser, "CreateInvoice");
                if (model.ProductFlow == "on") await _userManager.AddToRoleAsync(getUser, "ProductFlow");
                if (model.InvoiceSeparation == "on") await _userManager.AddToRoleAsync(getUser, "InvoiceSeparation");
                if (model.AllProductInvoiced == "on") await _userManager.AddToRoleAsync(getUser, "AllProductInvoiced");
                if (model.ProductLocation == "on") await _userManager.AddToRoleAsync(getUser, "ProductLocation");
                if (model.ProductPrice == "on") await _userManager.AddToRoleAsync(getUser, "ProductPrice");
                if (model.WareHousingHandle == "on") await _userManager.AddToRoleAsync(getUser, "WareHousingHandle");
                if (model.WastageRiallyStock == "on") await _userManager.AddToRoleAsync(getUser, "WastageRiallyStock");
                if (model.RiallyStock == "on") await _userManager.AddToRoleAsync(getUser, "RiallyStock");
                //
                await _userManager.AddToRoleAsync(getUser, "user");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetUserAccessApi")]
        public async Task<ApiResult<List<string>>> GetUserAccess(string userid)
        {
            try
            {
                var getUser = await _userManager.FindByIdAsync(userid);
                var roles = await _userManager.GetRolesAsync(getUser);

                return Ok(roles.ToList());
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }
    }
}
