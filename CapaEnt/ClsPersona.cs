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

        // Constructor con parámetros
        public ClsPersona(int _id, string _nombre, string _apellidos, string _telefono, string _direccion,
                       string _foto, DateTime _fechaNacimiento, int _idDepartamento)
        {
            id = _id;
            nombre = _nombre;
            apellidos = _apellidos;
            telefono = _telefono;
            direccion = _direccion;
            foto = _foto;
            fechaNacimiento = _fechaNacimiento;
            IDDepartamento = _idDepartamento;
        }
        #endregion
    }
}
