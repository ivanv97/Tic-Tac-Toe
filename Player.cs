﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Player
    {
        public char Name { get; private set; }

        public Player(char name)
        {
            Name = name;
        }
    }
}
