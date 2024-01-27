namespace GraphQLDemoApi.Schema.Queries
{
    public enum Subject
    {
        Mathematics,
        Science,
        History
    }

    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Subject Subject { get; set; }
        public InstructorType Instructor { get; set; } = new InstructorType();
        public IEnumerable<StudentType> Students { get; set; } = Enumerable.Empty<StudentType>();
    }
}
