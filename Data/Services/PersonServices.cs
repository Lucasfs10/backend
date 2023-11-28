using Data.DbContext;
using Data.Models;
using Data.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class PersonServices
    {
        private readonly IMongoCollection<Person> _personRepository;

        public PersonServices(IOptions<MongoDBContext> mongoService)
        {
            var mongoClient = new MongoClient(mongoService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoService.Value.DatabaseName);

            _personRepository = mongoDatabase.GetCollection<Person>("Person");
        }

        public async Task CreateAsync(Person person)
        {
            await _personRepository.InsertOneAsync(person);
        }

        public async Task DeleteAsync(string id)
        {
            await _personRepository.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<Person>> GetAsync() =>
            await _personRepository.Find(x => true).ToListAsync();
        

        public async Task<Person> GetByIdAsync(string id) =>
            await _personRepository.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Person person)
        {
            await _personRepository.ReplaceOneAsync(x => x.Id == id, person);
        }
    }
}
