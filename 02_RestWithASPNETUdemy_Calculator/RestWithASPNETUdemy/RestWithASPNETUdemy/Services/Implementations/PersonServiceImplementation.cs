using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    //persistencia e atualizacao no banco de dados.
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int cont;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for ( int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }
               
        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementeAndGet(),
                FirstName = "Diego",
                LastName = "Soares",
                Address = "São Paulo",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementeAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person LastNme" + i,
                Address = "Some Address" + i,
                Gender = "Male"
            };
        }

        private long IncrementeAndGet()
        {
            return Interlocked.Increment(ref cont);
        }
    }
}
