using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMonofia2025.Models
{
    public class Employee
    {
        //[Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Name Required")]
        [MaxLength(25,ErrorMessage ="Name Mustbe Less than 25 char")]
        [MinLength(3,ErrorMessage ="Name Must be More Than 2 Char")]
        [Unique(No =111)]
        public string Name { get; set; }//not allow null

        //[Range(7000,50000)]
        [Remote("CheckOdd","Employee",AdditionalFields = "Address", ErrorMessage ="Salary Must Be ODd")]
        public int Salary { get; set; }
        
        [RegularExpression(@"\w*\.(jpg|png)",ErrorMessage ="Image Must BE png or jpg ex: asd.png ")]//jfakjf.jpg
        public string ImageUrl { get; set; }

        public string? Address { get; set; } //allow null
        
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        //[Required]
        public virtual Department? Department { get; set; }
    }
}
