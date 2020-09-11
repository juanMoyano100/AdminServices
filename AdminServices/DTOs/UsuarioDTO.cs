using AdminServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminServices.DTOs
{
    public class UsuarioDTO
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
        public int  idTipoUsuario { get; set; }
        public string nombreTipoUsuario { get; set; }
        public string Nacionalidad { get; set; }
        public string CiudadResidencia { get; set; }
        public string DireccionResidencia { get; set; }
        public string EstadoCivil { get; set; }
        public int IdTipoSangre { get; set; }
        public string Genero { get; set; }
        public string EstaEmbarazada { get; set; }
        public string NombresContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string tipoSangreNombre { get; set; }
   

    }
}
