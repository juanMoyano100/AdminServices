using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AdminServices.DTOs;
using AdminServices.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminServices.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly adminContext adminContext;

        public UsuarioController(adminContext adminContext)
        {
            this.adminContext = adminContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> get()
        {
            var list = await adminContext.Usuario.Select(
                s => new UsuarioDTO
                {
                    IdUsuario = s.IdUsuario,
                    Cedula = s.Cedula,
                    PrimerNombre = s.PrimerNombre,
                    SegundoNombre = s.SegundoNombre,
                    ApellidoPaterno = s.ApellidoPaterno,
                    ApellidoMaterno = s.ApellidoMaterno,
                    CorreoElectronico = s.CorreoElectronico,
                    Telefono = s.Telefono,
                    Celular = s.Celular,
                    idTipoUsuario=s.IdTipoUsuarioNavigation.IdTipoUsuario,
                    nombreTipoUsuario = s.IdTipoUsuarioNavigation.Nombre,
                    Nacionalidad = s.IdInformacionPersonalNavigation.Nacionalidad,
                    CiudadResidencia = s.IdInformacionPersonalNavigation.CiudadResidencia,
                    DireccionResidencia = s.IdInformacionPersonalNavigation.DireccionResidencia,
                    EstadoCivil = s.IdInformacionPersonalNavigation.EstadoCivil,
                    IdTipoSangre=s.IdInformacionPersonalNavigation.IdTipoSangre,
                    tipoSangreNombre = s.IdInformacionPersonalNavigation.IdTipoSangreNavigation.Nombre,
                    Genero = s.IdInformacionPersonalNavigation.Genero,
                    EstaEmbarazada = s.IdInformacionPersonalNavigation.EstaEmbarazada,
                    NombresContacto = s.IdInformacionPersonalNavigation.NombresContacto,
                    TelefonoContacto = s.IdInformacionPersonalNavigation.TelefonoContacto
                }).ToListAsync();
            if (list.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return list;
            }
        }

        [HttpGet("search/{apellido}")]
        public async Task<ActionResult<List<UsuarioDTO>>> getByName(String apellido)
        {
            var list = await adminContext.Usuario.Where(
                e => e.ApellidoPaterno.Contains(apellido)
            ).Select(
                s => new UsuarioDTO
                {
                    IdUsuario = s.IdUsuario,
                    Cedula = s.Cedula,
                    PrimerNombre = s.PrimerNombre,
                    SegundoNombre = s.SegundoNombre,
                    ApellidoPaterno = s.ApellidoPaterno,
                    ApellidoMaterno = s.ApellidoMaterno,
                    CorreoElectronico = s.CorreoElectronico,
                    Telefono = s.Telefono,
                    Celular = s.Celular,
                    idTipoUsuario = s.IdTipoUsuarioNavigation.IdTipoUsuario,
                    nombreTipoUsuario = s.IdTipoUsuarioNavigation.Nombre,
                    Nacionalidad = s.IdInformacionPersonalNavigation.Nacionalidad,
                    CiudadResidencia = s.IdInformacionPersonalNavigation.CiudadResidencia,
                    DireccionResidencia = s.IdInformacionPersonalNavigation.DireccionResidencia,
                    EstadoCivil = s.IdInformacionPersonalNavigation.EstadoCivil,
                    IdTipoSangre = s.IdInformacionPersonalNavigation.IdTipoSangre,
                    tipoSangreNombre = s.IdInformacionPersonalNavigation.IdTipoSangreNavigation.Nombre,
                    Genero = s.IdInformacionPersonalNavigation.Genero,
                    EstaEmbarazada = s.IdInformacionPersonalNavigation.EstaEmbarazada,
                    NombresContacto = s.IdInformacionPersonalNavigation.NombresContacto,
                    TelefonoContacto = s.IdInformacionPersonalNavigation.TelefonoContacto
                }
                ).ToListAsync();
            if (list.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return list;
            }
        }

        [HttpGet("{cedula}")]
        public async Task<ActionResult<UsuarioDTO>> getById(string cedula)
        {
            var list = await adminContext.Usuario.Select(
                s => new UsuarioDTO
                {
                    IdUsuario = s.IdUsuario,
                    Cedula = s.Cedula,
                    PrimerNombre = s.PrimerNombre,
                    SegundoNombre = s.SegundoNombre,
                    ApellidoPaterno = s.ApellidoPaterno,
                    ApellidoMaterno = s.ApellidoMaterno,
                    CorreoElectronico = s.CorreoElectronico,
                    Telefono = s.Telefono,
                    Celular = s.Celular,
                    idTipoUsuario = s.IdTipoUsuarioNavigation.IdTipoUsuario,
                    nombreTipoUsuario = s.IdTipoUsuarioNavigation.Nombre,
                    Nacionalidad = s.IdInformacionPersonalNavigation.Nacionalidad,
                    CiudadResidencia = s.IdInformacionPersonalNavigation.CiudadResidencia,
                    DireccionResidencia = s.IdInformacionPersonalNavigation.DireccionResidencia,
                    EstadoCivil = s.IdInformacionPersonalNavigation.EstadoCivil,
                    IdTipoSangre = s.IdInformacionPersonalNavigation.IdTipoSangre,
                    tipoSangreNombre = s.IdInformacionPersonalNavigation.IdTipoSangreNavigation.Nombre,
                    Genero = s.IdInformacionPersonalNavigation.Genero,
                    EstaEmbarazada = s.IdInformacionPersonalNavigation.EstaEmbarazada,
                    NombresContacto = s.IdInformacionPersonalNavigation.NombresContacto,
                    TelefonoContacto = s.IdInformacionPersonalNavigation.TelefonoContacto

                }).FirstOrDefaultAsync(s => s.Cedula== cedula);

            if (list == null)
            {
                return NotFound();
            }
            else
            {
                return list;
            }

        }

        [HttpPut]
        public async Task<HttpStatusCode> update(UsuarioDTO usuarioDTO)
        {
            var entity = await adminContext.Usuario.FirstOrDefaultAsync(s => s.IdUsuario== usuarioDTO.IdUsuario);

            entity.IdUsuario = usuarioDTO.IdUsuario;
            entity.Cedula = usuarioDTO.Cedula;
            entity.PrimerNombre = usuarioDTO.PrimerNombre;
            entity.SegundoNombre = usuarioDTO.SegundoNombre;
            entity.ApellidoPaterno = usuarioDTO.ApellidoPaterno;
            entity.ApellidoMaterno = usuarioDTO.ApellidoMaterno;
            entity.CorreoElectronico = usuarioDTO.CorreoElectronico;
            entity.Telefono = usuarioDTO.Telefono;
            entity.Celular = usuarioDTO.Celular;
            entity.IdTipoUsuario = usuarioDTO.idTipoUsuario;
            entity.IdTipoUsuarioNavigation.Nombre = usuarioDTO.nombreTipoUsuario;
            entity.IdInformacionPersonalNavigation.Nacionalidad = usuarioDTO.Nacionalidad;
            entity.IdInformacionPersonalNavigation.CiudadResidencia = usuarioDTO.CiudadResidencia;
            entity.IdInformacionPersonalNavigation.DireccionResidencia = usuarioDTO.DireccionResidencia;
            entity.IdInformacionPersonalNavigation.EstadoCivil =usuarioDTO.EstadoCivil;
            entity.IdInformacionPersonalNavigation.IdTipoSangre=usuarioDTO.IdTipoSangre;
            entity.IdInformacionPersonalNavigation.IdTipoSangreNavigation.Nombre=usuarioDTO.tipoSangreNombre;
            entity.IdInformacionPersonalNavigation.Genero=usuarioDTO.Genero;
            entity.IdInformacionPersonalNavigation.EstaEmbarazada=usuarioDTO.EstaEmbarazada;
            entity.IdInformacionPersonalNavigation.NombresContacto=usuarioDTO.NombresContacto;
            entity.IdInformacionPersonalNavigation.TelefonoContacto=usuarioDTO.TelefonoContacto;
            await adminContext.SaveChangesAsync();
            return HttpStatusCode.OK;

        }

        [HttpPost]
        public async Task<HttpStatusCode> insert(UsuarioDTO usuarioDTO)
        {
            var personalInfo = new Informacionpersonal()
            {
                Nacionalidad=usuarioDTO.Nacionalidad,
                CiudadResidencia=usuarioDTO.CiudadResidencia,
                DireccionResidencia=usuarioDTO.DireccionResidencia,
                EstadoCivil=usuarioDTO.EstadoCivil,
                IdTipoSangre=usuarioDTO.IdTipoSangre,
                EstaEmbarazada=usuarioDTO.EstaEmbarazada,
                NombresContacto=usuarioDTO.NombresContacto,
                TelefonoContacto=usuarioDTO.TelefonoContacto,
            };
            Informacionpersonal aux = adminContext.Informacionpersonal.Add(personalInfo).Entity;

            var user = new Usuario()
            {
                IdUsuario = usuarioDTO.IdUsuario,
                Cedula = usuarioDTO.Cedula,
                PrimerNombre = usuarioDTO.PrimerNombre,
                SegundoNombre = usuarioDTO.SegundoNombre,
                ApellidoPaterno = usuarioDTO.ApellidoPaterno,
                ApellidoMaterno = usuarioDTO.ApellidoMaterno,
                CorreoElectronico = usuarioDTO.CorreoElectronico,
                Telefono = usuarioDTO.Telefono,
                Celular = usuarioDTO.Celular,
                IdTipoUsuario = usuarioDTO.idTipoUsuario,
                IdInformacionPersonal=aux.IdInformacionPersonal
            };
            adminContext.Usuario.Add(user);

            await adminContext.SaveChangesAsync();

            return HttpStatusCode.OK;
        }


    }
}
