using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.Domain.IRepository
{
    public interface ITableRepository
    {
        Task<TableDomain> GetTableByIdAsync(int tableId);
        Task CreateTableAsync(TableDomain tableDomain);
        Task UpdateTableAsync(TableDomain tableDomain);
        Task DeleteTableAsync(int tableId);
        Task<List<TableDomain>> GetAllTablesAsync();
    }
}
