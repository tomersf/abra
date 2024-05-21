using api.Data;
using api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Services
{
    public class PetService
    {
        private readonly IMongoCollection<Pet> _petCollection;

        public PetService(ApplicationDBContext dbContext)
        {
            _petCollection = dbContext.PetCollection;
        }

        public async Task<PetSum> GetPetsAsync()
        {
            var pets = await _petCollection.Find(pet => true).ToListAsync();
            int petsAgeSum = pets.Sum(pet => pet.Age);

            return new PetSum()
            {
                petsAgeSum = petsAgeSum,
                Pets = pets
            };

        }


        public async Task<Pet> GetPetAsync(string id) => await _petCollection.Find(pet => pet.Id == id).FirstOrDefaultAsync();


        public async Task CreatePetAsync(Pet Pet) =>
            await _petCollection.InsertOneAsync(Pet);


        public async Task<ReplaceOneResult> UpdatePetAsync(string id, Pet Pet) =>
            await _petCollection.ReplaceOneAsync(s => s.Id == id, Pet);

        public async Task<DeleteResult> DeletePetAsync(string id) =>
            await _petCollection.DeleteOneAsync(s => s.Id == id);

    }
}