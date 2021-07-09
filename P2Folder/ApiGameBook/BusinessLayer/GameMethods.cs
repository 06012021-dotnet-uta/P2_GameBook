using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GameMethods
    {
        private gamebookdbContext _context;

        public GameMethods(gamebookdbContext context)
        {
            _context = context;
        }
    }
}
