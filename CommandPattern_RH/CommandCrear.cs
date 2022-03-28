using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_RH
{
    public interface CommandCrear
    {
        string execute(string estatus);
    }
}
