using MessmeApi.Models;

public interface IHomeDataRepository
{
    Task<IEnumerable<HomeData>> GetAllHomeData();
}
