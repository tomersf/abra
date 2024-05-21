using api.Dtos.Pet;
using api.Mappers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/pet")]
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;
        public PetController(PetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<PetSum> Get() => await _petService.GetPetsAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Pet>> Get(string id)
        {
            Pet pet = await _petService.GetPetAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> Post([FromBody] CreatePetRequestDto PetDto)
        {

            var PetModel = PetDto.ToPetFromCreateDTO();
            await _petService.CreatePetAsync(PetModel);
            return CreatedAtAction(nameof(Get), new { id = PetModel.Id }, PetModel.ToPetDto());
        }

    }
}