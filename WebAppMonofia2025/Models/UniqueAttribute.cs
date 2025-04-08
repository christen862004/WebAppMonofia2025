using System.ComponentModel.DataAnnotations;

namespace WebAppMonofia2025.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        public int No { get; set; }
        //Server side Only
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            Employee EmpFromRequest =validationContext.ObjectInstance as Employee;
            
            ITIContext context = new ITIContext();
            string name = value.ToString();
            Employee empFRomDB= 
                context.Employee
                .FirstOrDefault(e => e.Name == name && e.DepartmentID ==EmpFromRequest.DepartmentID);
            if(empFRomDB == null ) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exists");
        }
    }
}
