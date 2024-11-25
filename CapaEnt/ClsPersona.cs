namespace CapaEnt
{
    public class ClsPersona
    {

        #region Atributos
        private int id;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNacimiento;
        #endregion


        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IDDepartamento { get; set; }

        #endregion


        #region Contructores
        public ClsPersona() { }

        public ClsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNacimiento = fechaNacimiento;
            IDDepartamento = idDepartamento;
        }
        #endregion
    }
}
