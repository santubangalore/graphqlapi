using GraphQLDemoApi.Schema.Queries;

namespace GraphQLDemoApi.Schema.Mutations
{
    public class CourseInputType
    {
        public string name { get; set; }

        public Subject subject { get; set; }

        public Guid InstructorId { get; set; }

    }
}
