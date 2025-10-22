using Microsoft.AspNetCore.Mvc;
using workshop.models;
using workshop.models.builders;
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
        public static async Task<IResult> Add(IPersonBuilder builder, IRepository<Person> repository, PersonPost model)
        {
            try
            {
                var person = builder.SetName(model.Name).SetEmail(model.Email).SetAge(model.Age).Build();
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
                var entity = await repository.GetById(id);
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
                var entity = await repository.GetById(id);
                if (entity == null) return Results.NotFound();
                if (model.Name != null) entity.Name = model.Name;
                if (model.Age != null) entity.Age = model.Age.Value;
                return Results.Ok(entity);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
