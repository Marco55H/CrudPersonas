using CapaBl;
using CapaEnt;
using System;

namespace CRUDASP.Models
{
    public class ClsPersonaConDepartamentoM : ClsPersona
    {
        private string nombreDept;
        public string NombreDept { get { return nombreDept; } }

        public ClsPersonaConDepartamentoM(ClsPersona persona)
        {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IDDepartamento = persona.IDDepartamento;

            ClsDepartamento departamento = ClsServiciosDepartamentos.BuscarDepartamentoBl(IDDepartamento);

            this.nombreDept = departamento.Nombre;

        }
    }
}