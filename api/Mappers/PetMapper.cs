using api.Dtos.Pet;
using api.Models;

namespace api.Mappers
{
    public static class PetMappers
    {
        public static PetDto ToPetDto(this Pet petModel)
        {
            return new PetDto
            {
                Id = petModel.Id,
                Age = petModel.Age,
                Color = petModel.Color,
                CreatedOn = petModel.CreatedOn,
                Name = petModel.Name,
                Type = petModel.Type
            };
        }

        public static Pet ToPetFromCreateDTO(this CreatePetRequestDto petDto)
        {
            return new Pet
            {
                Age = petDto.Age,
                Color = petDto.Color,
                Name = petDto.Name,
                Type = petDto.Type
            };
        }
    }
}