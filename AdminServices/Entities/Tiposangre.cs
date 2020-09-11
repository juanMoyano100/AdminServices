using System;
using System.Collections.Generic;

namespace AdminServices.Entities
{
    public partial class Tiposangre
    {
        public Tiposangre()
        {
            Informacionpersonal = new HashSet<Informacionpersonal>();
        }

        public int IdTipoSangre { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Informacionpersonal> Informacionpersonal { get; set; }
    }
}
