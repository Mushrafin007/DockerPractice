using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestProject.Services.CrudApiService;
using static TestProject.Model.CrudApiModel;

namespace TestProject.Controller
{
    [ApiController]
    public class CrudApiController : ControllerBase
    {
        ICrudApiService _ICrudApiService;

        public CrudApiController(ICrudApiService CrudApiService) 
        {
            _ICrudApiService = CrudApiService;
        }
        [Route("api/Crud/Create")]
        [HttpPost]
        public  async Task<JsonResult> create(CreateMode obj)
        {
            HttpContext.Response.ContentType = "application/json";
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ApiCommonResponseModel apiCommonResponse = new ApiCommonResponseModel();
            try 
            {
                object parameter = new
                {
                    Name = obj.Name,
                    Phone = obj.Phone,
                    Email = obj.Email,
                    Gender = obj.Gender
                }; 
                apiCommonResponse =  await _ICrudApiService.USP_CREATE_INS(parameter);
                if (apiCommonResponse.status == 200) 
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiCommonResponse.message = "Success";
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    apiCommonResponse.message = "failed";

                }

            }
            catch(Exception ex) 
            {
               
            }
            return new JsonResult(apiCommonResponse);
        }

    }
}
