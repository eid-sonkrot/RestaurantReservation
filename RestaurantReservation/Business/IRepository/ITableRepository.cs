using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
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