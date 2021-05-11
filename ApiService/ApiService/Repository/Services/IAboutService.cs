using Repository.Data.Entities;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IAboutService
    {
        Task<About> GetAbout();
        Task<About> GetAboutById(int id);
        Task AboutToUpdate(About aboutToUpdate, About about);
    }
}
