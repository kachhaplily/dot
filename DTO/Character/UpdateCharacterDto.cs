using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot.DTO.Character
{
    public class UpdateCharacterDto
    {
     public int Id { get; set; }
        public string Name { get; set; } = "lily";
        public int Hitpoint { get; set; } = 199;
        public int Strength { get; set; } = 10;
        public int Defenece { get; set; } = 10;
        public int Interlligence { get; set; } = 20;
        public RpgCLass Class { get; set; }=RpgCLass.knight;
    }
}