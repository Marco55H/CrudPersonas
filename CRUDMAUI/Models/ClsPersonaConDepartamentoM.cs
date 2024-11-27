using CapaBl;
using CapaEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMAUI.Models
{
    internal class ClsPersonaConDepartamentoM:ClsPersona
    {
        String nombreDept;

        public String NombreDept { get { return nombreDept; } }

        public ClsPersonaConDepartamentoM(ClsPersona persona)
        {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Telefono= persona.Telefono;
            this.Apellidos = persona.Apellidos;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.IDDepartamento = persona.IDDepartamento;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.nombreDept = ClsServiciosDepartamentos.BuscarDepartamentoBl(persona.IDDepartamento).Nombre;
        }

        public ClsPersonaConDepartamentoM()
        {
        }
    }
}
