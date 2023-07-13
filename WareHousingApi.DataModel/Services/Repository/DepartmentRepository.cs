//using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WareHousingApi.Common;
using WareHousingApi.Data.Contracts;
using WareHousingApi.DataModel;
using WareHousingApi.Entities.Entities;
using WareHousingApi.Entities.Models.Departments;

namespace WareHousingApi.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentViewModel>> GetPaginateCategoriesAsync(string searchText)
        {
            List<DepartmentViewModel> categories = await _context.TblDepartmen.GroupJoin(_context.TblDepartmen,
                (cl => cl.MotherId),
                (or => or.Id),
                ((cl, or) => new { DepartmentInfo = cl, ParentInfo = or }))
                .SelectMany(p => p.ParentInfo.DefaultIfEmpty(), (x, y) => new { x.DepartmentInfo, ParentInfo = y })
                //.OrderBy("DepartmanCode")
                .Select(c => new DepartmentViewModel
                {
                    Id = c.DepartmentInfo.Id,
                    DepartmentName = c.DepartmentInfo.DepartmentName,
                    MotherId= c.ParentInfo.MotherId,
                    MotherName= c.ParentInfo.DepartmentName
                }).AsNoTracking().ToListAsync();

            return categories;
        }


        public async Task<List<TreeViewCategory>> GetAllCategoriesAsync()
        {
            var Categories = await (from c in _context.TblDepartmen
                                    where (c.MotherId == null)
                                    select new TreeViewCategory { id = c.Id, title = c.DepartmentName }).ToListAsync();
            foreach (var item in Categories)
            {
                BindSubCategories(item);
            }

            return Categories;
        }

        public void BindSubCategories(TreeViewCategory Department)
        {
            var SubCategories = (from c in _context.TblDepartmen
                                 where (c.MotherId == Department.id)
                                 select new TreeViewCategory { id = c.Id, title = c.DepartmentName}).ToList();
            foreach (var item in SubCategories)
            {
                BindSubCategories(item);
                Department.subs.Add(item);
            }
        }

        public TblDepartman FindByDepartmentName(string departmentName)
        {
            return _context.TblDepartmen.Where(c => c.DepartmentName == departmentName.TrimStart().TrimEnd()).FirstOrDefault();
        }


        public bool IsExistDepartment(string departmentName, int? recentDepartmentId = null)
        {
            if (recentDepartmentId != 0 )
                return _context.TblDepartmen.Any(c => c.DepartmentName.Trim().Replace(" ", "") == departmentName.Trim().Replace(" ", ""));
            else
            {
                var Department = _context.TblDepartmen.Where(c => c.DepartmentName.Trim().Replace(" ", "") == departmentName.Trim().Replace(" ", "")).FirstOrDefault();
                if (Department == null)
                    return false;
                else
                {
                    if (Department.Id != recentDepartmentId)
                        return true;
                    else
                        return false;
                }
            }
        }


    }
}
