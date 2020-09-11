using System;
using System.Collections.Generic;

namespace AdminServices.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Cedula { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdInformacionPersonal { get; set; }

        public virtual Informacionpersonal IdInformacionPersonalNavigation { get; set; }
        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
    }
}
