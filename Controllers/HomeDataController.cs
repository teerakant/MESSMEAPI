using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class HomeDataController : ControllerBase
{
    private readonly IHomeDataRepository _homeDataRepository;
    private readonly IMapper _mapper;
    public HomeDataController(IHomeDataRepository homeDataRepository,
                                IMapper mapper)
    {
        _homeDataRepository = homeDataRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HomeDataDto>>> GetHomeData()
    {
        var homedata = await _homeDataRepository.GetAllHomeData();
        var homedataDtos = _mapper.Map<IEnumerable<HomeDataDto>>(homedata);
        return Ok(homedata);
    }
}