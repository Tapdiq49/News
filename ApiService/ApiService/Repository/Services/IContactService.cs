using Repository.Data.Entities;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IContactService
    {
        Task<Contact> GetContact();
        Task<Contact> GetContactById(int id);
        Task ContactToUpdate(Contact contactToUpdate, Contact contact);
    }
}
