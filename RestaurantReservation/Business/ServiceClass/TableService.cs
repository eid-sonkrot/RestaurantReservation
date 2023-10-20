using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;

namespace RestaurantReservation.Business.ServiceClass
{
    public class TableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }
        public async Task<TableDomain> GetTableByIdAsync(int tableId)
        {
            return await _tableRepository.GetTableByIdAsync(tableId);
        }
        public async Task CreateTableAsync(TableDomain tableDomain)
        {
            await _tableRepository.CreateTableAsync(tableDomain);
        }
        public async Task UpdateTableAsync(TableDomain tableDomain)
        {
            await _tableRepository.UpdateTableAsync(tableDomain);
        }
        public async Task DeleteTableAsync(int tableId)
        {
            await _tableRepository.DeleteTableAsync(tableId);
        }
        public async Task<List<TableDomain>> GetAllTablesAsync()
        {
            return await _tableRepository.GetAllTablesAsync();
        }
    }
}