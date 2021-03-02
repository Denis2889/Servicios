using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Logueo : Usuario
    {

        public Logueo(string usuario, string clave, int idperfil, string nombreperfil)
        {
            _User = usuario;
            _Clave = clave;
            _IDPerfil = idperfil;
            _NombrePerfil = nombreperfil;
        }
        public Logueo() { }
    }
}
