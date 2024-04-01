namespace FactuSystem.Data.Request // Sin el punto al final
{
    public class CuadrarCajaRequest
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cajero { get; set; } = null!;
        public decimal Monto { get; set; }
        public decimal MontoCuadrado { get; set; }
    }
} // Aquí se agrega un punto y coma al final
