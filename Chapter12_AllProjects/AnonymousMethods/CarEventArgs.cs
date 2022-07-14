﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    class CarEventArgs : EventArgs
    {
        public readonly string message;
        public CarEventArgs(string msg)
        {
            message = msg;
        }
    }
}
