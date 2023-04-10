using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot.Services.CharacterService
{
    public interface IcharacterService
    {
        Task <List<Character>>GetAllCharacter();
         Task<Character>GetCharacterById(int id);
        Task <List<Character>>AddCharacter(Character newCharacter);
    }
}