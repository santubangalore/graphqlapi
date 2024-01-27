namespace GraphQLDemoApi.Schema
{
    public class Mutation
    {
        private readonly List<CourseType> courses;

        public Mutation()
        {
            courses = new List<CourseType>();
        }

        public bool CreateCourse(string name, Subject subject, Guid instructorId)
        {
            CourseType course = new CourseType 
            {   
                Id= Guid.NewGuid(), 
                Name= name,
                Subject= subject,
                Instructor = new InstructorType
                {
                    Id = instructorId,

                }
            };

            this.courses.Add(course);
            return true;
        }
    }
}
