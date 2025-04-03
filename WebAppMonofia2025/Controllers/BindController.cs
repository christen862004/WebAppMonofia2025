using Microsoft.AspNetCore.Mvc;

namespace WebAppMonofia2025.Controllers
{
    public class BindController : Controller
    {

        //Bind/testPrmitive/100?age=2&name=ahmed
        //Bind/testPrmitive?age=2&name=ahmed&id=100
        //<form action="Bind/testPrmitive" method="get">
        //<input name=age
        //<input name=name
        
        public IActionResult testPrmitive(int id,int age,string name,string[] color)
        {
            
            return Content($"name={name}\t age={age}");
        }

        //Test Collection
        //Bind/TestDic?name=christen&phones[Mohamed]=123&phones[ahmed]=456
        public IActionResult TestDic(Dictionary<string,string> phones,string name)
        {
            return Content($"name={name}");
        }

        //Test Complex Type Custom Class 
        //http://localhost:31945/Bind/TestObj/1?name=sd&ManagerName=ahmed&emps[0].name=ali
        //public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee>? Emps)
        public IActionResult TestObj(Department dept)
        {
            return Content($"ok");

        }
    }
}
