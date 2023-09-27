using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;
using Serilog;

namespace RestaurantReservation.Business
{
    public class TableService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public TableService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TableDTO> GetTableByIdAsync(int tableId)
        {
            try
            {
                var table = await _dbContext.Tables.FindAsync(tableId);

                Log.Information("Table {TableId} retrieved successfully", tableId);
                return _mapper.Map<TableDTO>(table);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching table with ID: {TableId}", tableId);
                throw;
            }
        }
        public async Task CreateTableAsync(TableDTO tableDTO)
        {
            try
            {
                var newTable = _mapper.Map<Table>(tableDTO);
                _dbContext.Tables.Add(newTable);
                await _dbContext.SaveChangesAsync();

                Log.Information("Table {TableId} created successfully", newTable.table_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating table");
                throw;
            }
        }
        public async Task UpdateTableAsync(TableDTO tableDTO)
        {
            try
            {
                var existingTable = await _dbContext.Tables.FindAsync(tableDTO.TableId);

                if (existingTable is not null)
                {
                    _mapper.Map(tableDTO, existingTable);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Table {TableId} updated successfully", tableDTO.TableId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating table with ID: {TableId}", tableDTO.TableId);
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
                    _dbContext.Tables.Remove(table);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Table {TableId} deleted successfully", tableId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting table with ID: {TableId}", tableId);
                throw;
            }
        }
        public async Task<List<TableDTO>> GetAllTablesAsync()
        {
            try
            {
                var tables = await _dbContext.Tables.ToListAsync();
                var tableDTOs = _mapper.Map<List<TableDTO>>(tables);

                Log.Information("Retrieved all tables successfully");
                return tableDTOs;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all tables");
                throw;
            }
        }
    }
}