using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.Api;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities.Entities;
using WareHousingApi.Entities.Models.Dto.Department;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentApiController : Controller
    {
        public readonly IConfiguration _config;
        public readonly IUnitOfWork _uw;
        private readonly DataModel.ApplicationDbContext _context;
        private readonly ISqlDataAccess _sqlDataAccess;
        public DepartmentApiController(IConfiguration config, DataModel.ApplicationDbContext context, ISqlDataAccess sqlDataAccess, IUnitOfWork uw)
        {
            _context = context;
            _config = config;
            _sqlDataAccess = sqlDataAccess;
            _uw = uw;
        }


        //[HttpGet("DepartmentList")]
        //public ApiResult<IEnumerable<DepartmentComViewModel>> GetDepartmentList()
        //{
        //    //var customerList = _uw.departmentUW.Get();
        //    var customerList = _sqlDataAccess.LoadData<IEnumerable<DepartmentComViewModel>, dynamic>(storedProcedure: "SP002_Department_Com", null);
        //    return Ok(customerList);
        //}

        [HttpGet]
        [Route("DepartmentList")]
        //[HttpGet]
        public async Task<ApiResult<List<DepartmentComViewModel>>> GetDepartmentList()
        {
            var data = await _sqlDataAccess.LoadData<DepartmentComViewModel, dynamic>(storedProcedure: "SP002_Department_Com", null);
            return Ok(data);
        }



        [HttpPost]
        [Route("DepartmentCreate")]
        public ApiResult<string> Create([FromForm] int areaId, [FromForm] int? motherId = null, [FromForm] string departmentname = "", [FromForm] string departmenCode = "", [FromForm] string userid = "")
        {
            //کنترل نال بودن اطلاعات
            if (departmentname == "") return BadRequest();
            //کنترل تکراری نبودن اطلاعات
            var getDepartment = _context.TblDepartmen.Where(c => c.DepartmentName == departmentname);
            if (getDepartment.Count() > 0)
            {
                //تکراری
                return BadRequest();
            }
            //try
            //{
            TblDepartman departman = new TblDepartman
            {
                DepartmentName = departmentname,
                AreaId = areaId,
                Active = true,
                DepartmentCode = departmenCode,
                MotherId = motherId
            };
            _context.TblDepartmen.AddAsync(departman);
            _context.SaveChangesAsync();
            return BadRequest();
            //}
            //catch (Exception)
            //{
            //    return BadRequest("خطای سرور");
            //}
        }

        //[Route("DepartmentList")]
        //[HttpGet]
        //public async Task<ApiResult<List<DepartmentComViewModel>>> GetDepartmentList()
        //{
        //    List<DepartmentComViewModel> dataViews = new List<DepartmentComViewModel>();

        //    using (SqlConnection sqlconnect = new SqlConnection(_config.GetConnectionString("WareHousingApiConnectionString")))
        //    {
        //        using (SqlCommand sqlCommand = new SqlCommand("SP003_Department_Com", sqlconnect))
        //        {
        //            sqlconnect.Open();
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
        //            while (await dataReader.ReadAsync())
        //            {
        //                DepartmentComViewModel data = new DepartmentComViewModel();
        //                data.Id = int.Parse(dataReader["Id"].ToString());
        //                data.DepartmentCode = dataReader["DepartmentCode"].ToString();
        //                data.DepartmentName = dataReader["DepartmentName"].ToString();
        //                dataViews.Add(data);
        //            }
        //        }
        //    }
        //    return Ok(dataViews);
        //}


        //[Route("DepartmentAcceptorRead")]
        //[HttpGet]
        //public async Task<ApiResult<List<DepartmentAcceptorViewModel>>> DepartmentAcceptorRead()
        //{
        //    List<DepartmentAcceptorViewModel> ContractView = new List<DepartmentAcceptorViewModel>();
        //    {
        //        using (SqlConnection sqlconnect = new SqlConnection(_config.GetConnectionString("WareHousingApiConnectionString")))
        //        {
        //            using (SqlCommand sqlCommand = new SqlCommand("SP003_DepartmentAcceptor_Read", sqlconnect))
        //            {
        //                sqlconnect.Open();
        //                sqlCommand.CommandType = CommandType.StoredProcedure;
        //                SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
        //                while (await dataReader.ReadAsync())
        //                {
        //                    DepartmentAcceptorViewModel data = new DepartmentAcceptorViewModel();
        //                    data.Id = int.Parse(dataReader["Id"].ToString());
        //                    data.DepartmanId = StringExtensions.ToNullableInt(dataReader["DepartmanId"].ToString());
        //                    data.AreaId = StringExtensions.ToNullableInt(dataReader["AreaId"].ToString());
        //                    data.DepartmentCode = dataReader["DepartmentCode"].ToString();
        //                    data.DepartmentName = dataReader["DepartmentName"].ToString();
        //                    data.AreaName = dataReader["AreaName"].ToString();
        //                    ContractView.Add(data);
        //                }
        //            }
        //            sqlconnect.Close();
        //        }
        //    }
        //    return Ok(ContractView);
        //}


        //[Route("DepartmentAcceptorInsert")]
        //[HttpPost]
        //public async Task<ApiResult<string>> DepartmentAcceptorInsert([FromBody] DepartmentAcceptorInsertViewModel param)
        //{
        //    string readercount = null;
        //    using (SqlConnection sqlconnect = new SqlConnection(_config.GetConnectionString("WareHousingApiConnectionString")))
        //    {
        //        using (SqlCommand sqlCommand = new SqlCommand("SP003_DepartmentAcceptor_Insert", sqlconnect))
        //        {
        //            sqlconnect.Open();
        //            sqlCommand.Parameters.AddWithValue("DepartmanId", param.DepartmanId);
        //            sqlCommand.Parameters.AddWithValue("AreaId", param.AreaId);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
        //            while (dataReader.Read())
        //            {
        //                if (dataReader["Message_DB"].ToString() != null) readercount = dataReader["Message_DB"].ToString();
        //            }
        //        }
        //    }
        //    if (string.IsNullOrEmpty(readercount)) return Ok("با موفقیت انجام شد");
        //    else
        //        return BadRequest(readercount);
        //}


        //[Route("DepartmentAcceptorDelete")]
        //[HttpPost]
        //public async Task<ApiResult<string>> DepartmentAcceptorDelete([FromBody] PublicParamIdViewModel param)
        //{
        //    string readercount = null;
        //    using (SqlConnection sqlconnect = new SqlConnection(_config.GetConnectionString("WareHousingApiConnectionString")))
        //    {
        //        using (SqlCommand sqlCommand = new SqlCommand("SP003_DepartmentAcceptor_Delete", sqlconnect))
        //        {
        //            sqlconnect.Open();
        //            sqlCommand.Parameters.AddWithValue("Id", param.Id);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
        //            while (dataReader.Read())
        //            {
        //                if (dataReader["Message_DB"].ToString() != null) readercount = dataReader["Message_DB"].ToString();
        //            }
        //        }
        //    }
        //    if (string.IsNullOrEmpty(readercount)) return Ok("با موفقیت انجام شد");
        //    else
        //        return BadRequest(readercount);
        //}


        //[Route("DepartmentAcceptorUserRead")]
        //[HttpGet]
        //public async Task<ApiResult<List<DepartmentAcceptorUserReadViewModel>>> DepartmentAcceptorUserRead(PublicParamIdViewModel param)
        //{
        //    List<DepartmentAcceptorUserReadViewModel> ContractView = new List<DepartmentAcceptorUserReadViewModel>();
        //    {
        //        using (SqlConnection sqlconnect = new SqlConnection(_config.GetConnectionString("WareHousingApiConnectionString")))
        //        {
        //            using (SqlCommand sqlCommand = new SqlCommand("SP003_DepartmentAcceptorUser_Read", sqlconnect))
        //            {
        //                sqlconnect.Open();
        //                sqlCommand.Parameters.AddWithValue("Id", param.Id);
        //                sqlCommand.CommandType = CommandType.StoredProcedure;
        //                SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
        //                while (await dataReader.ReadAsync())
        //                {
        //                    DepartmentAcceptorUserReadViewModel data = new DepartmentAcceptorUserReadViewModel();

        //                    data.Id = int.Parse(dataReader["Id"].ToString());
        //                    data.FirstName = dataReader["FirstName"].ToString();
        //                    data.LastName = dataReader["LastName"].ToString();
        //                    data.Resposibility = dataReader["Resposibility"].ToString();
        //                    data.UserId = int.Parse(dataReader["UserId"].ToString());
        //                    ContractView.Add(data);
        //                }
        //            }
        //            sqlconnect.Close();
        //        }
        //    }
        //    return Ok(ContractView);
        //}

        //[Route("EmployeeModal")]
        //[HttpGet]
        //public async Task<ApiResult<List<EmployeeModalViewModel>>> EmployeeModal(PublicParamIdViewModel param)
        //{
        //    List<EmployeeModalViewModel> dataview = new List<EmployeeModalViewModel>();
        //    {
        //        using (SqlConnection sqlconnect = new SqlConnection(_config.GetConnectionString("WareHousingApiConnectionString")))
        //        {
        //            using (SqlCommand sqlCommand = new SqlCommand("SP003_Employee_Read", sqlconnect))
        //            {
        //                sqlconnect.Open();
        //                sqlCommand.CommandType = CommandType.StoredProcedure;
        //                SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
        //                while (await dataReader.ReadAsync())
        //                {
        //                    EmployeeModalViewModel data = new EmployeeModalViewModel();

        //                    data.Id = int.Parse(dataReader["Id"].ToString());
        //                    data.FirstName = dataReader["FirstName"].ToString();
        //                    data.LastName = dataReader["LastName"].ToString();
        //                    data.Bio = dataReader["Bio"].ToString();
        //                    dataview.Add(data);
        //                }
        //            }
        //            sqlconnect.Close();
        //        }
        //    }
        //    return Ok(dataview);
        //}


        //[Route("DepartmentAcceptorEmployeeInsert")]
        //[HttpPost]
        //public async Task<ApiResult<string>> DepartmentAcceptorEmployeeInsert([FromBody] DepartmentAcceptorEmployeeInsertViewModel param)
        //{
        //    string readercount = null;
        //    using (SqlConnection sqlconnect = new SqlConnection(_config.GetConnectionString("WareHousingApiConnectionString")))
        //    {
        //        using (SqlCommand sqlCommand = new SqlCommand("SP003_DepartmentAcceptorUser_Insert", sqlconnect))
        //        {
        //            sqlconnect.Open();
        //            sqlCommand.Parameters.AddWithValue("EmployeeId", param.EmployeeId);
        //            sqlCommand.Parameters.AddWithValue("DepartmentAcceptorId", param.DepartmentAcceptorId);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
        //            while (dataReader.Read())
        //            {
        //                if (dataReader["Message_DB"].ToString() != null) readercount = dataReader["Message_DB"].ToString();
        //            }
        //        }
        //    }
        //    if (string.IsNullOrEmpty(readercount)) return Ok("با موفقیت انجام شد");
        //    else
        //        return BadRequest(readercount);
        //}


        //[Route("DepartmentAcceptorEmployeeDelete")]
        //[HttpPost]
        //public async Task<ApiResult<string>> DepartmentAcceptorEmployeeDelete([FromBody] PublicParamIdViewModel param)
        //{
        //    string readercount = null;
        //    using (SqlConnection sqlconnect = new SqlConnection(_config.GetConnectionString("WareHousingApiConnectionString")))
        //    {
        //        using (SqlCommand sqlCommand = new SqlCommand("SP003_DepartmentAcceptorUser_Delete", sqlconnect))
        //        {
        //            sqlconnect.Open();
        //            sqlCommand.Parameters.AddWithValue("Id", param.Id);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
        //            while (dataReader.Read())
        //            {
        //                if (dataReader["Message_DB"].ToString() != null) readercount = dataReader["Message_DB"].ToString();
        //            }
        //        }
        //    }
        //    if (string.IsNullOrEmpty(readercount)) return Ok("با موفقیت انجام شد");
        //    else
        //        return BadRequest(readercount);
        //}




    }
}
