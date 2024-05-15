using Api_Dotnet.Model;

namespace Api_Dotnet.Services
{
    public interface IDepartment
    {
        List<Department> GetAllList(bool? IsActive);
        Department? GetById(int id);
        Department AddDeparement(AddUpdateDepartment DeptObj);
        Department? UpdateDepartment(int id, AddUpdateDepartment DeptObj);
        bool DeleteDepartmentById(int id);

    }
}