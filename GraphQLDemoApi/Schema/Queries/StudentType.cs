namespace GraphQLDemoApi.Schema.Queries
{
    public class StudentType
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [GraphQLName("gpa")]
        public double GPA { get; set; }

    }
}
