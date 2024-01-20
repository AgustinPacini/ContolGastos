using Newtonsoft.Json;

namespace ControlDeGasto.Models
{
    public class GastoModel 
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("Monto")]
        public decimal Monto { get; set; }
        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }


        [JsonProperty("Tipo")]

        public TipoGasto Tipo { get; set; }
    }
    public enum TipoGasto
    {
        Debito,
        Efectivo,
        Credito,
        Tranferencia
    }
    public class GastosDelMesModel
    {
        public List<GastoModel> Ingresos { get; set; }
        public List<GastoModel> Egresos { get; set; }
        public decimal TotalIngresos { get { return Ingresos.Sum(x => x.Monto); } }
        public decimal TotalEgresos { get { return Egresos.Sum(x => x.Monto); } }
        public decimal Balance { get { return TotalIngresos - TotalEgresos; } }
    }

}
