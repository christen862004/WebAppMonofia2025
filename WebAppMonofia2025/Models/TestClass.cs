using System.Dynamic;

namespace WebAppMonofia2025.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }

    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //using bubble sort alg.
        }
    }
    //Extne
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {

        }
    }
    //DIP | IOC   (lossly Couple)
    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            
        }
    }

    class MyList//High Level Class
    {
        int[] arr;
        ISort mySort;//abstractio or inrterface Class
        public MyList(ISort sort)//inject
        {
            arr = new int[10];
            mySort =  sort;// new BubbleSort();dont create ask counstructor  + method
        }
        public void SortArr() {
            mySort.Sort(arr);
        }
    }
    //----------------------------------------
    public class TestClass
    {
        public int Add(int x,int y)//receive a=>x
        {
            MyList list1 = new MyList(new BubbleSort());//main function |ControllerFactory Contrine
            MyList list2 = new MyList(new SelectionSort());//main function | Contrine
            MyList list3 = new MyList(new ChrisSort());//main function | Contrine

            //Create 
             //Child<Student>
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

    public class Parent<T>//Open Type
    {
        public T Model { get; set; }
    }
    public class Child : Parent<Student>
    {
        string _viewData;

        public object ViewData  //Special Function
        {
            get { return _viewData; }
            set { _viewData = value.ToString(); }
        }

        public dynamic Viewbag  //Special Function
        {
            get { return _viewData; }
            set { _viewData = value; }
        }
    }
}
