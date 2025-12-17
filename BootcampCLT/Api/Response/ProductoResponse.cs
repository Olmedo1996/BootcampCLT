namespace BootcampCLT.Api.Response
{
    public record ProductoResponse
    {
        private double precio;

        public int Id { get; init; }
        public string Codigo { get; init; }
        public string Nombre { get; init; }
        public string Descripcion { get; init; }
        public decimal Precio { get; init; }
        public bool Activo { get; init; }
        public int CategoriaId { get; init; }
        public string CategoriaNombre { get; init; }
        public DateTime FechaCreacion { get; init; }
        public DateTime? FechaActualizacion { get; init; }
        public int CantidadStock { get; init; }

        public ProductoResponse() { }

        public ProductoResponse(int Id, string Codigo, string Nombre, string Descripcion, double Precio, bool Activo, int CategoriaId, DateTime FechaCreacion, DateTime? FechaActualizacion, int CantidadStock)
        {
            this.Id = Id;
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            precio = Precio;
            this.Activo = Activo;
            this.CategoriaId = CategoriaId;
            this.FechaCreacion = FechaCreacion;
            this.FechaActualizacion = FechaActualizacion;
            this.CantidadStock = CantidadStock;
        }
    }
}


// del profesor
