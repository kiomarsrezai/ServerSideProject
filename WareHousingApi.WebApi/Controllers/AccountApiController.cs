using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.WebApi.Tools.Interface;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly IJwtTokenGenerator _token;
        private readonly IUnitOfWork _context;

        public AccountApiController(UserManager<ApplicationUsers> userManager,
                                        SignInManager<ApplicationUsers> signInManager,
                                            IJwtTokenGenerator token,
                                                IUnitOfWork context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;
            _context = context;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                //کنترل اینکه کاربر وجود داره یا نه
                var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == model.UserName);
                if (user == null) return Unauthorized("Invalid UserName");

                //کنترل اینکه رمز عبور صحیح است یا خیر
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (!result.Succeeded) return Unauthorized("Invalid UserName Or Password");

                //دریافت نقش های کاربر
                var roles = await _userManager.GetRolesAsync(user);

                //کنترل وضعیت سال مالی
                var FiscalYearStatus = _context.fiscalYearUW.Get(f => f.FiscalYearID == model.FiscalYear).SingleOrDefault();
                byte fiscalStatus = 10;

                if (FiscalYearStatus.FiscalFlag == true && FiscalYearStatus.EndDate.Date >= DateTime.Now)
                {
                    //همه چیز درست می باشد
                    fiscalStatus = 0;
                }
                else if (FiscalYearStatus.FiscalFlag == true && FiscalYearStatus.EndDate.Date < DateTime.Now)
                {
                    //سال مالی باز می باشد ولی تاریخ روز از تاریخ پایان سال مالی عبور کرده است
                    fiscalStatus = 1;
                }
                else if (FiscalYearStatus.FiscalFlag == false)
                {
                    //سال مالی بسته است
                    fiscalStatus = 2;
                }

                var usertoken = new UserJwtToken
                {
                    Roles = await _userManager.GetRolesAsync(user),
                    Token = await _token.CreateTokenAsync(user),
                    UserName = user.UserName,
                    UserID = user.Id,
                    FiscalYearFlag = fiscalStatus
                };

                return Ok(usertoken);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
           
        }
    }
}
