using WebAppMonofia2025.Models;

namespace WebAppMonofia2025.ViewModel
{
    public class EmployeeWithBracnchListColorMsgViewModel
    {
        //Encrypt model Proerty + Select needed Property
        public int EmpID{ get; set; }
        public string EmpName{ get; set; }
        
        //Add More Extra PRoperty
        public int Temp { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }
        public List<string> Branches { get; set; }
    }
}
