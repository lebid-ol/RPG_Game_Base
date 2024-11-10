using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base
{
    internal interface IGlobalCharacter
    {
        public string Name { get; }
        public double Health { get; set; }
        public double Attack { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }

    }
}
