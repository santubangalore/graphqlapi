namespace GraphQLDemoApi.Schema.Queries
{
    public class CourseInputType
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }

    }
}
