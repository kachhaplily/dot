using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharactorDto>();
            CreateMap<AddChracterDto,Character>();
        }
        
    }
}