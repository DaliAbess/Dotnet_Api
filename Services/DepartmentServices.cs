using Api_Dotnet.Model;

namespace Api_Dotnet.Services
{
    public class DepartmentServices : IDepartment
    {
        private readonly List<Department> _departmentList;

        public DepartmentServices()
        {
            _departmentList = new List<Department>()
            {
                new Department()
                {
                    Id = 1,
                    DepartmentName= "Computer Science",
                    Description = "Head of Department",
                    IsActive = true,


                }
            };
        }
        public List<Department> GetAllList(bool? IsActive)
        {
            return IsActive== null ? _departmentList : _departmentList.Where(dept=>dept.IsActive==IsActive).ToList();
        }

        public Department? GetById(int id)
        {
            return _departmentList.FirstOrDefault(dept=>dept.Id==id);
         }


        public Department AddDeparement(AddUpdateDepartment DeptObj)
        {
            var AddDepartment = new Department()
            {
                Id = _departmentList.Max(id=> id.Id) + 1,
                DepartmentName = DeptObj.DepartmentName,
                Description = DeptObj.Description,
                IsActive =DeptObj.IsActive
            };
            _departmentList.Add(AddDepartment);

            return AddDepartment;
        }
              
        
        
        public Department? UpdateDepartment(int id, AddUpdateDepartment DeptObj)
        {
            var Deptindex = _departmentList.FindIndex(idx => idx.Id==id);

            if(Deptindex>0)
            {
                var Dept = _departmentList[Deptindex];
                Dept.DepartmentName = DeptObj.DepartmentName;
                Dept.Description = DeptObj.Description;
                Dept.IsActive = DeptObj.IsActive;

                _departmentList[Deptindex] = Dept;

                return Dept;

            }
            else
            {
                return null;
            }

        }

        public bool DeleteDepartmentById(int id)
        {
            var deptindex = _departmentList.FindIndex(idx => idx.Id == id);
            if (deptindex>0)
            {
                _departmentList.RemoveAt(deptindex);
            }
            return deptindex>0;
        }

    }
}