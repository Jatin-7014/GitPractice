﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApp.Exceptions
{
    internal class MovieRemovedSuccessException:Exception
    {
        public SuccessException(string message):base(message)
        {
                       Console.WriteLine("Throws exception");

        }
    }
}
