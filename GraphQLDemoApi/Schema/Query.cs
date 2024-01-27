namespace GraphQLDemoApi.Schema
{
    using Bogus;
    public class Query
    {
        private readonly Faker<InstructorType> instructorFaker;
        private readonly Faker<StudentType> studentFaker;
        private readonly Faker<CourseType> courseFaker;

        [GraphQLDeprecated("Old version")]
        public string Instructions=> "Hit the like button and subscribe to my channel";
      
        /// <summary>
        /// Constructor
        /// </summary>
        public Query()
        {
            instructorFaker = new Faker<InstructorType>()
                .RuleFor(i => i.Id, Guid.NewGuid())
                .RuleFor(i => i.FirstName, f => f.Name.FirstName())
                .RuleFor(i => i.LastName, f => f.Name.LastName())
                .RuleFor(i => i.Salary, f => f.Random.Double(40000, 200000));

             studentFaker = new Faker<StudentType>()
                .RuleFor(i => i.Id, Guid.NewGuid())
                .RuleFor(i => i.FirstName, f => f.Name.FirstName())
                .RuleFor(i => i.LastName, f => f.Name.LastName())
                .RuleFor(i => i.GPA, f => f.Random.Double(40, 100));

            courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.JobTitle())
                .RuleFor(c=> c.Students, studentFaker.Generate(4))
                .RuleFor(c => c.Instructor, instructorFaker.Generate());
        }

        public IEnumerable<CourseType> GetCourses()
        {
            return courseFaker.Generate(5);  
        }


        /* Query format for this type of resolver: below:
         * what hot chocolate does is, it removes the usual "Get" word and "Async" word from the query name. 
         {
           couseById(id:"9e5d0e6e-feb5-440e-8dd1-39832c42e265") {
              name
              instructor {
                firstName 
              }
              students{
                firstName
              }
             }
            }
         * 
         */

        public async Task<CourseType> GetCouseByIdAsync(Guid id)
        {
            await Task.Delay(500);

            CourseType Course = courseFaker.Generate();
            Course.Id = id;

            return Course;

        }
    }
}
