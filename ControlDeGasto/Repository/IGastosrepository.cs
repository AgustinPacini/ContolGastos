using ControlDeGasto.Models;

namespace ControlDeGasto.Repository
{
    public interface IGastosRepository
    {
        void Ingreso(GastoModel gasto);
        //void EgresarGasto(GastoModel gasto);
        //Task<List<GastoModel>> ObtenerGastosDelMes(int mes, int anio);
        Task<IEnumerable<GastoModel>> ObtenerGastos(int mes, int anio);
        Task<DineroEnCuenta> ObtenerDineroEnCuenta();
        Task<GastoModel> GetGastoById(int id);
        Task<GastoModel> DeleteGasto(GastoModel gasto);
        Task EgresarGastoAsync(GastoModel gasto);


    }

}
