using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot.Services.CharacterService
{
    public class CharacterService : IcharacterService
    {
          private static List<Character>characters  =new  List <Character>{
         new Character(),
         new Character{Id=1, Name="sunil"}   
        };

        public async Task <List<Character>> AddCharacter(Character newCharacter)
        {
             characters.Add(newCharacter);
            return characters;
        }

        public  async Task <List<Character>> GetAllCharacter()
        {
            return characters;
        }

        public async Task < Character> GetCharacterById(int id)
        {
            
            var character= characters.FirstOrDefault(c => c.Id == id);
            if(character is not null){
                return  character;
            }
            throw new Exception("character not fpund");
        }
    }
}