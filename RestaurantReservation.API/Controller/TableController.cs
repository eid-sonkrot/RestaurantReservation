using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Business.ServiceClass;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly TableService _tableService;

        public TableController(IMapper mapper, TableService tableService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
        }
        [Authorize]
        [HttpGet("Tables")]
        public async Task<IActionResult> GetTables()
        {
            var tables = await _tableService.GetAllTablesAsync();
            var tableDTOs = _mapper.Map<IEnumerable<TableDTO>>(tables);

            return Ok(tableDTOs);
        }
        [Authorize]
        [HttpGet("GetTableById/{tableId}")]
        public async Task<IActionResult> GetTableById(int tableId)
        {
            var table = await _tableService.GetTableByIdAsync(tableId);

            if (table is null)
            {
                return NotFound();
            }
            var tableDto = _mapper.Map<TableDTO>(table);

            return Ok(tableDto);
        }
        [Authorize]
        [HttpPost("CreateTable")]
        public async Task<IActionResult> CreateTable([FromBody] TableDTO tableDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newTable = _mapper.Map<TableDomain>(tableDto);

            await _tableService.CreateTableAsync(newTable);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateTable/{tableId}")]
        public async Task<IActionResult> UpdateTable(int tableId, [FromBody] TableDTO tableDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingTable = await _tableService.GetTableByIdAsync(tableId);

            if (existingTable is null)
            {
                return NotFound();
            }
            try
            {
                var updatedTable = _mapper.Map<TableDomain>(tableDto);

                updatedTable.TableId = tableId;
                await _tableService.UpdateTableAsync(updatedTable);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize]
        [HttpDelete("DeleteTable/{tableId}")]
        public async Task<IActionResult> DeleteTable(int tableId)
        {
            var existingTable = await _tableService.GetTableByIdAsync(tableId);

            if (existingTable is null)
            {
                return NotFound();
            }
            await _tableService.DeleteTableAsync(tableId);
            return NoContent();
        }
    }
}