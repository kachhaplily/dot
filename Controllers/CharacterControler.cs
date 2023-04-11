global using dot.models;
global using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dot.Services;
using dot.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dot.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterControler : ControllerBase
    {
        private static List<Character> characters = new List<Character>{
         new Character(),
         new Character{Id=1, Name="sunil"}
        };
        private readonly IcharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterControler(IcharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharactorDto>>>> Get() => Ok(await _characterService.GetAllCharacter());
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharactorDto>>>> GetSingle(int id) => Ok(await _characterService.GetCharacterById(id));
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharactorDto>>>> AddCharacter(AddChracterDto newCharacter) => Ok(await _characterService.AddCharacter(newCharacter));
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharactorDto>>>> UpdateChracter(UpdateCharacterDto updatedCharcter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharcter);
            switch (response.Data)
            {
                case not null:
                    return Ok(response);
                default:
                    return NotFound(response);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharactorDto>>>>DeleteCharacter(int id) 
        {
            var response = await _characterService.DeleteCharacter(id);
            switch (response.Data)
            {
                case not null:
                    return Ok(response);
                default:
                    return NotFound(response);
            }
        }


    }
}