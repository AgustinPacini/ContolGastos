using Newtonsoft.Json;

namespace ControlDeGasto.Models
{
    public class GastoModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("Monto")]
        public decimal Monto { get; set; }
        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty("TipoGasto")]
        public string TipoGasto { get; set; }
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
