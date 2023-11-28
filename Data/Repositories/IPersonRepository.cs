using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<ICollection<Person>> GetAllAsync();
        Task<Person> CreateAsync(Person person);
        Task<Person> UpdateAsync(Person person);
        Task DeleteAsync(string id);
    }
}
