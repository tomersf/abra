using System.ComponentModel.DataAnnotations;
using api.Enum;

namespace api.Dtos.Pet
{
    public class CreatePetRequestDto
    {

        [Required]
        [Length(0, 25, ErrorMessage = "Name of pet must be at most 25 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public PetType Type { get; set; } = PetType.Other;

        [Required]
        public string Color { get; set; } = "white";

        [Required]
        [Range(0, 20, ErrorMessage = "Age must be between 0 and 20")]
        public int Age { get; set; } = 0;
    }
}