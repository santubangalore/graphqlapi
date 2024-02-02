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

        public CourseResult CreateCourse(CourseInputType courseInputType)
        {
            CourseResult course = new CourseResult
            {
                Id = Guid.NewGuid(),
                Name = courseInputType.name,
                Subject = courseInputType.subject,
                InstructorId = courseInputType.InstructorId,
            };

            courses.Add(course);
            return course;
        }

        /* createCourse template after adding CreateCourseType class
         * mutation {
        createCourse(courseInputType: {
         name:"Chemistry",
         subject:SCIENCE,
         instructorId:"8d10e1c3-1984-4001-9fe4-3857c464b639"
        })
            {
                name
                subject
            }
        }
         *
         * Note: Return field  list  { name, subject} is mandatory
         */


        public CourseResult UpdateCourse(Guid id, string name, Subject subject, Guid instructorId)
        {
            CourseResult course = courses.FirstOrDefault(c => c.Id == id);  

            if(course == null)
            {
                throw new GraphQLException(new Error( "Course not found", "COURSE_NOT_FOUND"));
            }
            course.Name = name;
            course.Subject = subject;
            course.InstructorId = instructorId;

            return course;
        }

        public bool DeleteCourse(Guid id)
        {
            return courses.RemoveAll(q => q.Id == id) >= 1;
        }
    }
}
