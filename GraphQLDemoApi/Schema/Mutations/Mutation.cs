using GraphQLDemoApi.Schema.Queries;

namespace GraphQLDemoApi.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> courses;

        public Mutation()
        {
            courses = new List<CourseResult>();
        }

        /* nature of query/mutation
         * pls note, at least one field from the created object should be part fo the query.
         * mutation{
              createCourse(name: "Algorithm", instructorId: "9e5d0e6e-feb5-440e-8dd1-39832c42e265", subject: MATHEMATICS){
                name
                id
                }
            }
         * 
         */

        public CourseResult CreateCourse(string name, Subject subject, Guid instructorId)
        {
            CourseResult course = new CourseResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Subject = subject,
                InstructorId = instructorId,
            };

            courses.Add(course);
            return course;
        }


        public CourseResult UpdateCourse(Guid id, string name, Subject subject, Guid instructorId)
        {
            CourseResult course = courses.FirstOrDefault(c => c.Id == id);  

            if(course == null)
            {
                throw new Exception("Course not found");
            }
            course.Name = name;
            course.Subject = subject;
            course.InstructorId = instructorId;

            return course;
        }
    }
}
