using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller

        
    {
        private readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        public IRegionRepository RegionRepository { get; }

        [HttpGet]
        public IActionResult GetAllRegions()

        {
            var regions = regionRepository.GetAll();

            //return Dto regions
            var regionsDto = new List<Models.Dto.Region>();
            regions.ToList().ForEach(region =>
            {
                var regionDto = new Models.Dto.Region()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    Area = region.Area,
                    Lat = region.Lat,
                    Long = region.Long,
                    Population = region.Population

                };

                regionsDto.Add(regionDto);

            });   
            


            return Ok(regionsDto);
        }

    }
}
