using WareHousingApi.Entities.Entities;
using WareHousingApi.Entities.Models.Departments;

namespace WareHousingApi.Data.Contracts
{
    public interface IDepartmentRepository
    {
        TblDepartman FindByDepartmentName(string departmentName);
        Task<List<TreeViewCategory>> GetAllCategoriesAsync();
        bool IsExistDepartment(string departmentName, int? recentCategoryId = null);
        Task<List<DepartmentViewModel>> GetPaginateCategoriesAsync(string searchText);
    }
}
