namespace WareHousingApi.DataModel.Services.Interface
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "WareHousingApiConnectionString");
        //Task<IEnumerable<T>> LoadData<T>(string storedProcedure, string connectionId = "SqlErp"));
        Task SaveData<T>(string storedProcedure, T parameter, string connectionId = "WareHousingApiConnectionString");
    }
}