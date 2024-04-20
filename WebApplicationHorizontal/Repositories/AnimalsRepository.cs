using System.Data.SqlClient;
using WebApplication1.Model;

namespace WebApplication1.Repositories;

public class AnimalsRepository : IAnimalsRepository
{
    private IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT Animal.IdAnimal, Animal.Name, Animal.Description, Animal.Category, Animal.Area FROM Animal ORDER BY Name";

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var grade = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Area = dr["Area"].ToString(),
                Category = dr["Category"].ToString(),
                Description = dr["Description"].ToString()
            };
            animals.Add(grade);
        }
        return animals;
    }
}