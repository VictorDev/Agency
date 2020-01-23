using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo
{
    interface IWritableObject
    {
        void Write(SaveManager man);
    }
}
