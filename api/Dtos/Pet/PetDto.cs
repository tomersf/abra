using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enum;

namespace api.Dtos.Pet
{
    public class PetDto
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public PetType Type { get; set; } = PetType.Other;

        public string Color { get; set; } = "white";

        public int Age { get; set; } = 0;
    }
}