using System;
using System.Collections.Generic;

namespace AdminServices.Entities
{
    public partial class Informacionpersonal
    {
        public Informacionpersonal()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdInformacionPersonal { get; set; }
        public string Nacionalidad { get; set; }
        public string CiudadResidencia { get; set; }
        public string DireccionResidencia { get; set; }
        public string EstadoCivil { get; set; }
        public int IdTipoSangre { get; set; }
        public string Genero { get; set; }
        public string EstaEmbarazada { get; set; }
        public string NombresContacto { get; set; }
        public string TelefonoContacto { get; set; }

        public virtual Tiposangre IdTipoSangreNavigation { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
