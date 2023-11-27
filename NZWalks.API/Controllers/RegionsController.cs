using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Domain.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // Get Data from Database
            var regions = dbContext.Regions.ToList();

            // 
            var regionsDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }


            return Ok(regionsDto);
        }


        [Route("{id:Guid}")]
        [HttpGet]
        public IActionResult GetById([FromRoute]Guid id)
        {
            //Region region = dbContext.Regions.Find(id)!;
            Region? region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }
    }
}
