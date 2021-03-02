using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Usuario
    {
        protected int IDPerfil;
        protected string NombrePerfil;
        protected bool Estado;
        protected int IDUsuario;
        protected string Nombres;
        protected string Apellidos;
        protected string Clave;
        protected string Mail;
        protected string Celular;
        protected string User;



        public int _IDPerfil
        {
            get
            {
                return IDPerfil;
            }

            set
            {
                IDPerfil = value;
            }
        }

        public string _NombrePerfil
        {
            get
            {
                return NombrePerfil;
            }

            set
            {
                NombrePerfil = value;
            }
        }

        public bool _Estado
        {
            get
            {
                return Estado;
            }

            set
            {
                Estado = value;
            }
        }

        public int _IDUsuario
        {
            get
            {
                return IDUsuario;
            }

            set
            {
                IDUsuario = value;
            }
        }

        public string _Nombres
        {
            get
            {
                return Nombres;
            }

            set
            {
                Nombres = value;
            }
        }

        public string _Apellidos
        {
            get
            {
                return Apellidos;
            }

            set
            {
                Apellidos = value;
            }
        }

        public string _Clave
        {
            get
            {
                return Clave;
            }

            set
            {
                Clave = value;
            }
        }

        public string _Mail
        {
            get
            {
                return Mail;
            }

            set
            {
                Mail = value;
            }
        }

        public string _Celular
        {
            get
            {
                return Celular;
            }

            set
            {
                Celular = value;
            }
        }

        public string _User
        {
            get
            {
                return User;
            }

            set
            {
                User = value;
            }
        }
        public Usuario(int iDPerfil, string nombrePerfil, bool estado, int iDUsuario, string nombres, string apellidos, string clave, string mail, string celular, string user)
        {
            _IDPerfil = iDPerfil;
            _NombrePerfil = nombrePerfil;
            _Estado = estado;
            _IDUsuario = iDUsuario;
            _Nombres = nombres;
            _Apellidos = apellidos;
            _Clave = clave;
            _Mail = mail;
            _Celular = celular;
            _User = user;
        }
        public Usuario() { }
    }
}
