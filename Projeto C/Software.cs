using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_C
{
    class Software
    {
        public string software;
        public string data;
        public string hora;
        public string tipo;       

        public Software()
        {

        }

        public Software(string software, string data, string hora, string tipo, int cont)
        {
            this.software = software;
            this.data = data;
            this.hora = hora;
            this.tipo = tipo;            
        }
    }
}
