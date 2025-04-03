using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMonofia2025.ViewModel
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }//not allow null
        public int Salary { get; set; }
        public string ImageUrl { get; set; }
        public string? Address { get; set; } //allow null

        public int DepartmentID { get; set; }


        public List<Department> DeptList { get; set; }
    }
}
