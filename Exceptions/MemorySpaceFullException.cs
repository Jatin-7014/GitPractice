﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApp.Exceptions
{
    internal class MemorySpaceFullException:Exception
    {
        public MemorySpaceFullException(string message):base(message)
        { 
           Console.WriteLine("Throws exception");
        }
    }
}
