using EntityFrameworkExample.Data;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Repositories
{
    public class MyRepository: IRepository
    {
        private readonly PersonContext _context;

        public MyRepository(PersonContext context)
        {
            _context = context;
        }

        public void CreatePerson()
        {
            _context.Add(new Person() { 
                FirstName = "Robert ", LastName = "Berends",
                City = "Birmingham", Address = "2632 Petunia Way" });
            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetPeople()
        {
            return _context.People.ToList();
        }

        public void UpdatePerson(int id)
        {
            var person = _context.People.SingleOrDefault(eachPerson => eachPerson.PersonId == id);
            person.FirstName = "Hoang 123";
            _context.Update(person);
            _context.SaveChanges();
        }
    }
}
