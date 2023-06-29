namespace APIControlGastos.Models
{
    public class Balance
    {
        public DateTime Fecha { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal TotalCobros { get; set; }
        public decimal CantidadRestante { get; set; }
    }

}
