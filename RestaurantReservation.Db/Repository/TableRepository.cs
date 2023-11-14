using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Domain;
using RestaurantReservation.Domain.IRepository;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public TableRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TableDomain> GetTableByIdAsync(int tableId)
        {
            try
            {
                var table = await _dbContext.Tables.FindAsync(tableId);

                return _mapper.Map<TableDomain>(table);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching table with ID: {TableId}", tableId);
                throw;
            }
        }
        public async Task CreateTableAsync(TableDomain tableDomain)
        {
            try
            {
                var newTable = _mapper.Map<Table>(tableDomain);

                _dbContext.Tables.Add(newTable);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating table");
                throw;
            }
        }
        public async Task UpdateTableAsync(TableDomain tableDomain)
        {
            try
            {
                var tableEntity = _mapper.Map<Table>(tableDomain);
                var existingTable = await _dbContext.Tables.FindAsync(tableEntity.TableId);

                if (existingTable is not null)
                {
                    _dbContext.Entry(existingTable).CurrentValues.SetValues(tableEntity);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating table with ID: {TableId}", tableDomain.TableId);
                throw;
            }
        }
        public async Task DeleteTableAsync(int tableId)
        {
            try
            {
                var table = await _dbContext.Tables.FindAsync(tableId);

                if (table is not null)
                {
                    _dbContext.Restaurants.Find(table.RestaurantId).Tables.Remove(table);
                    _dbContext.Tables.Remove(table);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting table with ID: {TableId}", tableId);
                throw;
            }
        }
        public async Task<List<TableDomain>> GetAllTablesAsync()
        {
            try
            {
                var tables = await _dbContext.Tables.ToListAsync();

                return tables.Select(t => _mapper.Map<TableDomain>(t)).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all tables");
                throw;
            }
        }
    }
}