using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dot.Services.CharacterService
{
    public interface IcharacterService
    {
        Task<ServiceResponse<List<GetCharactorDto>>> GetAllCharacter();
        Task<ServiceResponse<GetCharactorDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharactorDto>>> AddCharacter(AddChracterDto newCharacter);
        Task<ServiceResponse<GetCharactorDto>> UpdateCharacter(UpdateCharacterDto updatedCharcter);
        Task<ServiceResponse<List<GetCharactorDto>>> DeleteCharacter(int id);


    }
}