using System.Collections.Generic;
using System.Linq;
using WebSpa.TypeScript.Infrastructure;
using WebSpa.TypeScript.Models;

namespace WebSpa.TypeScript.Services
{
    public class PersonService : ServiceBase
    {
        protected static List<PersonModel> PeopleList { get; }

        static PersonService()
        {
            PeopleList = new List<PersonModel>
            {
                new PersonModel(1, "Patrik", "Duch"),
                new PersonModel(2, "Eva", "Duchová"),
                new PersonModel(3, "Petra", "Duchová"),
                new PersonModel(4, "Tomáš", "Silber"),
                new PersonModel(5, "Jakub", "Mazur"),
                new PersonModel(6, "Josef", "Bebčák"),
                new PersonModel(7, "Bogdan", "Walek")
            };
        }

        public virtual Result<List<PersonModel>> Search(string term = null)
        {
            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                term = term.Trim();

                var result = 
                    PeopleList
                    .Where(x =>
                        x.FirstName.ToLower().Contains(term) ||
                        x.LastName.ToLower().Contains(term)
                    )
                    .ToList();

                return Ok(result);
            }

            return Ok(PeopleList);
        }

        public virtual Result<int> Add(PersonModel model)
        {
            if(model == null)
                return Error<int>();
            if(string.IsNullOrEmpty(model.FirstName))
                return Error<int>("First name not defined.");
            if(string.IsNullOrEmpty(model.LastName))
                return Error<int>("Last name not defined.");

            TrimStrings(model);

            var personExists =
                PeopleList
                .Any(x =>
                    x.FirstName == model.FirstName &&
                    x.LastName == model.LastName
                    );
            if(personExists)
            {
                return Error<int>("Person with the same first name and last name already exists.");
            }

            var newId = PeopleList.Max(x => x?.Id ?? 0) + 1;
            model.Id = newId;

            PeopleList.Add(model);

            return Ok(model.Id);
        }
        
        public virtual Result Update(PersonModel model)
        {
            if (model == null)
                return Error();
            if (model.Id <= 0)
                return Error($"{model.Id} <= 0.");
            var person = PeopleList.Where(x => x.Id == model.Id).FirstOrDefault();
            if (person == null)
                return Error($"Person with id = {model.Id} not found.");

            TrimStrings(model);

            var personExists =
                PeopleList
                .Any(x =>
                    x.Id != model.Id &&
                    x.FirstName == model.FirstName &&
                    x.LastName == model.LastName
                    );
            if(personExists)
            {
                return Error("Person with the same first name and last name already exists.");
            }

            person.FirstName = model.FirstName;
            person.LastName = model.LastName;

            return Ok();
        }

        public virtual Result Delete(int id)
        {
            var unit = PeopleList.Where(x => x.Id == id).FirstOrDefault();
            if (unit == null)
                return Error($"Can't find person with Id = {id}.");
            PeopleList.Remove(unit);
            return Ok();
        }
        
        private static void TrimStrings(PersonModel model)
        {
            model.FirstName = model.FirstName.Trim();
            model.LastName = model.LastName.Trim();
        }
    }
}
