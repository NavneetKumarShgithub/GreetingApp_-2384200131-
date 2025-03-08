using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using ModelLayer.Model;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using System;
using NLog;
using NLog.Web;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly ILogger<HelloGreetingController> logger;
        private readonly IGreetingBL greetingBL;
        

        public HelloGreetingController(ILogger<HelloGreetingController> logger, IGreetingBL gettingBL)
        {
            this.logger = logger;
            this.greetingBL = gettingBL;
        }

        [HttpGet]
        [Route("Messageshow")]
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
            var result = greetingBL.HelloWorldPrint();
            responseModel.Success = true;
            responseModel.Message = "Hello API endpoint hit";

            responseModel.Data = result;
            return Ok(responseModel);
        }

        [HttpPost]
        [Route("UserAttributeMessage")]
        public IActionResult UserAttributeMsg(UserModel userModel) 
        {
            var message = greetingBL.UserAttributeMsgBL(userModel);
            return Ok(message);
        }

        /// <summary>
        /// Get method to get the greetimg message
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>
        [HttpPost]
        [Route("RequestData")]
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
        [Route("partial Update")]
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
        [Route("PartiallyUpdatation")]
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

        /// <summary>
        /// Save a message in Greetingdatabase
        /// </summary>
        /// <param name="greetingModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ad message")]
        public IActionResult AddMessage(GreetingModel greetingModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            var result = greetingBL.AddGreeting(greetingModel);

            if (result)
            {

                responseModel.Success = true;
                responseModel.Message = "Greeting message save successfully";
                responseModel.Data = greetingModel.GreetingMessage;
                return Ok(responseModel);
            }
            return BadRequest(responseModel);
        }

        ///// <summary>
        ///// retrive message by UId number
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("{id}")]
        //public IActionResult GetMessage(int id)
        //{
        //    ResponseModel<string> responseModel = new ResponseModel<string>();
        //    var message = greetingBL.GetGreetingById(id); 
        //    if (message == null)
        //    {
        //        responseModel.Success = false;
        //        responseModel.Message = "not found";
        //        responseModel.Data = null;
        //        return NotFound(responseModel);
        //    }

        //    responseModel.Success = true;
        //    responseModel.Message = "Greeting message save successfully";
        //    responseModel.Data = null;
        //    return Ok(responseModel);
        //}



    }
}