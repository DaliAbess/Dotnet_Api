namespace Api_Dotnet.Model
{
    public class AddUpdateDepartment
    {

        public required string DepartmentName { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}