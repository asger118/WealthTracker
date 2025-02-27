using BlazorStockApp.Shared.DTOs;
using BlazorStockApp.Shared.Models;

namespace BlazorStockApp.Shared.Mappers
{
    public interface IStockMapper
    {
        Stock Mapper(Rootobject rootobject); 
    }
}
