
global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot.Services.CharacterService
{
    public class CharacterService : IcharacterService
    {
        private static List<Character> characters = new List<Character>{
         new Character(),
         new Character{Id=1, Name="sunil"}
        };
        private readonly IMapper _mapper;



        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetCharactorDto>>> AddCharacter(AddChracterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharactorDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(m => m.Id) + 1;
            characters.Add(character);

            var ServiceResponse = new ServiceResponse<List<GetCharactorDto>>();
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharactorDto>(c)).ToList();
            return ServiceResponse;

        }

        public async Task<ServiceResponse<List<GetCharactorDto>>> DeleteCharacter(int id)
        {
            var ServiceResponse=new ServiceResponse<List<GetCharactorDto>>();
             try
            {
                var character = characters.First(c => c.Id == id);
                if(character is null)throw new Exception($"Character with id'{id}' not found");
                characters.Remove(character);
                ServiceResponse.Data=characters.Select(c => _mapper.Map<GetCharactorDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                ServiceResponse.Succed = false;
                ServiceResponse.message = ex.Message;

            }

        return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharactorDto>>> GetAllCharacter()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharactorDto>>();
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharactorDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharactorDto>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetCharactorDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            ServiceResponse.Data = _mapper.Map<GetCharactorDto>(character);
            return ServiceResponse;

        }

        public async Task<ServiceResponse<GetCharactorDto>> UpdateCharacter(UpdateCharacterDto updatedCharcter)
        {
            var ServiceResponse = new ServiceResponse<GetCharactorDto>();
            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updatedCharcter.Id);
                if(character is null)throw new Exception($"Character with id'{updatedCharcter.Id}' not found");
                character.Name = updatedCharcter.Name;
                character.Hitpoint = updatedCharcter.Hitpoint;
                character.Strength = updatedCharcter.Strength;
                character.Defenece = updatedCharcter.Defenece;
                character.Interlligence = updatedCharcter.Interlligence;
                character.Class = updatedCharcter.Class;
                ServiceResponse.Data = _mapper.Map<GetCharactorDto>(character);
            }
            catch (Exception ex)
            {
                ServiceResponse.Succed = false;
                ServiceResponse.message = ex.Message;

            }
            return ServiceResponse;

        }


    }
}
