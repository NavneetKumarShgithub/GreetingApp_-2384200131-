using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using ModelLayer.Model;
using BusinessLayer.Interface;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly ILogger<HelloGreetingController> logger;
        private readonly IGreetingBL gettingBL;

        public HelloGreetingController(ILogger<HelloGreetingController> logger, IGreetingBL gettingBL)
        {
            this.logger = logger;
            this.gettingBL = gettingBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello to Greeting AppAPI Endpoint";

            responseModel.Data = "Hello World!";
            return Ok(responseModel);
        }
        [HttpGet]
        [Route("GettingMessage")]
        public IActionResult Get1()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            var result = gettingBL.HelloWorldPrint();
            responseModel.Success = true;
            responseModel.Message = "Hello API endpoint hit";

            responseModel.Data = result;
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