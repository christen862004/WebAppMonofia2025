namespace WebAppMonofia2025.Repository
{
    //ISP
    public interface IEmployeeRepository:IRepository<Employee>
    {
        List<Employee> GetByDeptId(int deptID);
    }
}
