namespace GraphQLDemoApi.Schema
{
    
    public class InstructorType
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public double Salary { get; set; }
    }
}
