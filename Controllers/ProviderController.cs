
using curifyapi.Extensions;
using curifyapi.Models.DTO;
using curifyapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace curifyapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProviderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProviderById(int id)
        {
            try
            {
                var provider = await _unitOfWork.ProviderRepository.GetProviderByIdAsync(id);

                if (provider == null)
                {
                    return NotFound("Provider not found");
                }

                var providerDto = provider.MapToDto();

                return Ok(providerDto);
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAllProviders()
        {
            try
            {
                var providers = await _unitOfWork.ProviderRepository.GetAllProvidersAsync();

                // Map User entities to UserDtos for controlled data exposure
                var providerDtos = providers.MapToDtos();

                return Ok(providerDtos);
            }
            catch (Exception err)
            {
                // Handle exceptions gracefully
                return StatusCode(500, err.Message);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateProvider([FromBody] CreateProviderDto request)
        {
            try
            {

                var provider = request.MapToProvider();

                var createdProvider = await _unitOfWork.ProviderRepository.CreateProviderAsync(provider);
                await _unitOfWork.SaveChangesAsync();

                // Map created User entity to UserDto for controlled data exposure
                var providerDto = createdProvider.MapToDto();

                return CreatedAtAction("GetProviderById", new { id = createdProvider.Id }, providerDto);
            }
            catch (Exception err)
            {
                // Handle exceptions gracefully
                return StatusCode(500, err.Message);
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(int id, [FromBody] UpdateProviderDto request)
        {
            try
            {
                // Validate user update data (implementation not shown for brevity)

                var existingProvider = await _unitOfWork.ProviderRepository.GetProviderByIdAsync(id);

                if (existingProvider == null)
                {
                    return NotFound("Provider not found");
                }

                // Apply UpdateUserDto properties to existing User entity using extension method
                request.ApplyToProvider(existingProvider);

                var updatedProvider = await _unitOfWork.ProviderRepository.UpdateProviderAsync(id, existingProvider);
                await _unitOfWork.SaveChangesAsync();

                // Map updated User entity to UserDto for controlled data exposure
                var providerDto = updatedProvider.MapToDto();

                return Ok(providerDto);
            }
            catch (Exception err)
            {
                // Handle exceptions gracefully
                return StatusCode(500, err.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            try
            {
                var provider = await _unitOfWork.ProviderRepository.GetProviderByIdAsync(id);

                if (provider == null)
                {
                    return NotFound("Provider not found");
                }

                await _unitOfWork.ProviderRepository.DeleteProviderAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception err)
            {
                // Handle exceptions gracefully
                return StatusCode(500, err.Message);
            }
        }


    }
}