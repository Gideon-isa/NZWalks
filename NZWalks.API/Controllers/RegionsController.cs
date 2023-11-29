using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Domain.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data from Database
            var regions = await regionRepository.GetAllAsync();

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
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            //Region region = dbContext.Regions.Find(id)!;
            Region? region = await regionRepository.GetByIdAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto
            {
                Id  = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
            };

            return Ok(regionDto);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or Convert DTO to Domain Model
            Region newRegion = new Region()
            {
               
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // SQL Server automatically generate a guid; No need to generate a new Guid value for newRegion model

            // Use Domain Model to create Region
            newRegion =  await regionRepository.CreateAsync(newRegion);
            

            var regionDto = new RegionDto()
            {
                Id = newRegion.Id,
                Code = newRegion.Code,
                Name = newRegion.Name,
                RegionImageUrl = newRegion.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = newRegion.Id }, regionDto); 

        }

        [Route("{id:Guid}")]
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto update)
        {
            var regionDominaModel = new Region
            {
                Code = update.Code,
                Name = update.Name,
                RegionImageUrl = update.RegionImageUrl,
            };

            var regionDomainModel = await regionRepository.UpdateAsync(id, regionDominaModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //// Map Dto to Domain model
            //regionDomainModel.Name = update.Name;
            //regionDomainModel.Code = update.Code;
            //regionDomainModel.RegionImageUrl = update.RegionImageUrl;

            //Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Map
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

    }
}
