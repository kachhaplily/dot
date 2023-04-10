global using dot.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dot.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dot.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterControler:ControllerBase
    {
        // private static List<Character>characters  =new  List <Character>{
        //  new Character(),
        //  new Character{Id=1, Name="sunil"}   
        // };
        private readonly IcharacterService _characterService;

        public CharacterControler(IcharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpGet("GetAll")]
        public async Task <ActionResult <List<Character>>> Get(){
            return Ok(await _characterService.GetAllCharacter());
        }
         [HttpGet("{id}")]
        public async Task <ActionResult <List<Character>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task <ActionResult<List <Character>>>AddCharacter(Character newCharacter){
         return Ok ( await _characterService.AddCharacter(newCharacter));
        }
    }
}