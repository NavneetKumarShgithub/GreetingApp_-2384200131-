using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using ModelLayer.Model;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello to Greeting AppAPI Endpoint";

            responseModel.Data = "Hello World!";
            return Ok(responseModel);
        }

        /// <summary>
        /// Get method to get the greetimg message
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>
        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Message = "Request received successfully";
            responseModel.Success = true;
            responseModel.Data = $"Key: {requestModel.key}, Value: {requestModel.value}";
            return Ok(responseModel);
        }

        /// <summary>
        /// Put method to update the greeting message
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>
        [HttpPut]
        public IActionResult Put(RequestModel requestModel) 
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Message = "Request Update successfully";
            responseModel.Success = true;
            responseModel.Data = $"Update Key:{requestModel.key}, Update Value: {requestModel.value}";

            return Ok(responseModel);
        }

        /// <summary>
        /// Patch method to partially update the greeting message
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>
        [HttpPatch]
        public IActionResult Patch(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Message = "Request partially updated successfully";
            responseModel.Success = true;
            responseModel.Data = $"Partially Updated Key: {requestModel.key}, Partially Updated Value: {requestModel.value}";
            return Ok(responseModel);            
        }

        /// <summary>
        /// Delete method to delete the greeting message
        /// </summary>
        /// <param name="key"> </param>
        /// <returns>response model</returns>
        [HttpDelete("{key}")]
        public IActionResult Delete(string key) 
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Message = $"Request with Key: {key} deleted successfully";
            responseModel.Success = true;
            responseModel.Data = null; // No data to return on delete
            return Ok(responseModel);
        }


    }
}