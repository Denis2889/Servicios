using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Perfil : Usuario
    {
        public Perfil(int idperfil, string nombrePerfil, bool estado)
        {
            _IDPerfil = idperfil;
            _NombrePerfil = nombrePerfil;
            _Estado = estado;
        }
        public Perfil() { }
    }
}
