namespace ControlDeGasto.Models
{
    public class DineroEnCuenta
    {
        public DateTime Fecha { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal TotalCobros { get; set; }
        public decimal CantidadRestante { get; set; }
    }

}
