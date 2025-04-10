namespace WebAppMonofia2025.Repository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        string ID { get; set; }
        
        //main department methohd
    }
}
