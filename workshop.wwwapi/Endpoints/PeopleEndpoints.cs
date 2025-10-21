using Microsoft.AspNetCore.Mvc;
using workshop.models;
using workshop.Repository;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Endpoints
{
    public static class PeopleEndpoints
    {
        public static void ConfigurePeopleEndpoints(this WebApplication app)         
        {
            var people = app.MapGroup("/people");

            people.MapGet("/", GetAll);
            people.MapPost("/", Add);
            people.MapDelete("/{id}", Delete);
            people.MapPut("/{id}", Update);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Person> repository)
        {
            var results = await repository.GetAsync();
            return TypedResults.Ok(results);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> Add(IRepository<Person> repository, PersonPost model)
        {
            try
            {

                Person person = new Person()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email
                };
                await repository.Insert(person);

                return TypedResults.Created($"https://localhost:7010/people/{person.Id}", person);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(IRepository<Person> repository, int id)
        {
            try
            {
                var model = await repository.GetById(id);
                var target = await repository.Delete(id);
                if (target is not null) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Name = target.Name, Email= target.Email, Age = target.Age });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(IRepository<Person> repository, int id, PersonPut model)
        {
            try
            {
                var target = await repository.GetById(id);
                if (target == null) return Results.NotFound();
                if (model.Name != null) target.Name = model.Name;
                if (model.Age != null) target.Age = model.Age.Value;
                return Results.Ok(target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
