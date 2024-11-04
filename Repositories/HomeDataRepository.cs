using MessmeApi.Models;
using Microsoft.EntityFrameworkCore;

public class HomeDataRepository : IHomeDataRepository
{
    private readonly PostgresContext _context;
    public HomeDataRepository(PostgresContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<HomeData>> GetAllHomeData()
    {
        return await _context.homedata.ToListAsync();
    }
}