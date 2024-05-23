using Microsoft.AspNetCore.Mvc;
using SOAPDemo;


namespace CustomerRewardTelecom.CustomerService.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly SOAPDemoSoap _soapClient;

        public CustomerController()
        {
            _soapClient = new SOAPDemoSoapClient(SOAPDemoSoapClient.EndpointConfiguration.SOAPDemoSoap);
        }
        [HttpGet("FindPerson/{id}")]
        public async Task<IActionResult> FindPerson(string id)
        {
            try
            {
                var person = await _soapClient.FindPersonAsync(id);
                if (person == null)
                {
                    return NotFound();
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" An error occured while we were processing your request, please try aggain: {ex.Message}");
            }
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            try
            {
                var result = await _soapClient.GetByNameAsync(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" An error occured while we were processing your request: {ex.Message}");
            }
        }

        [HttpGet("GetDataSetByName")]
        public async Task<IActionResult> GetDataSetByName([FromQuery] string name)
        {
            try
            {
                var result = await _soapClient.GetDataSetByNameAsync(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" An error occured while we were processing your request: {ex.Message}");
            }
        }

        [HttpGet("GetListByName")]
        public async Task<IActionResult> GetListByName([FromQuery] string name)
        {
            try
            {
                var result = await _soapClient.GetListByNameAsync(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" An error occured while we were processing your request: {ex.Message}");
            }
        }

        [HttpGet("LookupCity/{zipCode}")]
        public async Task<IActionResult> LookupCity(string zipCode)
        {
            try
            {
                var address = await _soapClient.LookupCityAsync(zipCode);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" An error occured while we were processing your request: {ex.Message}");
            }
        }

        [HttpGet("Mission")]
        public async Task<IActionResult> Mission()
        {
            try
            {
                var mission = await _soapClient.MissionAsync();
                return Ok(mission);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while we wre processing your request: {ex.Message}");
            }
        }

        [HttpGet("QueryByName")]
        public async Task<IActionResult> QueryByName([FromQuery] string name)
        {
            try
            {
                var result = await _soapClient.QueryByNameAsync(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while we were processing yoor request: {ex.Message}");
            }
        }

    }
}



