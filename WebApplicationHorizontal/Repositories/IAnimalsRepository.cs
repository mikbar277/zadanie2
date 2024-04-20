using WebApplication1.Model;

namespace WebApplication1.Repositories;

public interface IAnimalsRepository
{
    public IEnumerable<Animal> GetAnimals();
}