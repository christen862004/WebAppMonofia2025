using System.Dynamic;

namespace WebAppMonofia2025.Models
{
    public class TestClass
    {
        public int Add(int x,int y)//receive a=>x
        {
            dynamic a = 10;
            dynamic b = "20";
            dynamic obj = new Student();
            b = a + obj;
            return x + y;
        }
        public void Cal()
        {
            int a = 10;
            int b = 20;
            Add(a,b);//call a,b
        }
    }

}
