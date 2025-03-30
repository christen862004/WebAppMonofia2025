using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMonofia2025.Models
{
    public class Employee
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }//not allow null
        public int Salary { get; set; }
        public string ImageUrl { get; set; }
        public string? Address { get; set; } //allow null
        
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public virtual Department? Department { get; set; }
    }
}
