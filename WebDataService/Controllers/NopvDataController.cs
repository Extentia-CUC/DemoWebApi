using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.OData;
using System.Web.Http.Tracing;
using WebDataModel;
using WebDataService.Models;

namespace WebDataService.Controllers
{
    /// <summary>
    /// NOPV Data controller
    /// </summary>
    public class NopvDataController : ApiController
    {
        private INopvDataRepository _nopvData;
        private readonly ITraceWriter _logger;
        public NopvDataController(INopvDataRepository nopvDataRepo)
        {
            
            _nopvData = nopvDataRepo;
            _logger = GlobalConfiguration.Configuration.Services.GetTraceWriter();
        }

        [Authorize(Roles = "user")]
        /// <summary>
        /// Get all NOPV data
        /// </summary>
        /// <param name="pagingParams">Pagination params</param>
        /// <returns></returns>
        public IHttpActionResult Get([FromUri]PaginationMetadata pagingParams)
        {
            return Ok(new ServiceResponse<NOPVData>(_nopvData.GetAll(), pagingParams));
        }

        /// <summary>
        /// Get NOPV details for given BBL.
        /// </summary>
        /// <param name="id">BBL</param>
        /// <returns></returns>
        public IHttpActionResult Get(string id)
        {
            _logger.Info(Request, this.ControllerContext.ControllerDescriptor.ControllerType.FullName, "Get called.");
            
            NOPVData data = _nopvData.GetDetails(id);
            if(data == null)
            {
                return Content(HttpStatusCode.NotFound, "BBL not found");
            }
            return Ok(data);
        }

        public IHttpActionResult Post([FromBody]NOPVData data)
        {
            try
            {
                var newObject = _nopvData.SaveDetails(data);
                return CreatedAtRoute("DefaultApi", new { id = newObject.BBL }, newObject);
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        //public IHttpActionResult Patch(string id, [FromBody]Delta<NOPVData> nopvData, JsonPatch.JsonPatchDocument<NOPVData> data)
        public IHttpActionResult Patch(string id, [FromBody]JsonPatch.JsonPatchDocument<NOPVData> data)
        {
            try
            {
                var res = _nopvData.UpdateDetails(id, data);
                //NOPVData result = _nopvData.UpdateDetails(id, nopvData);
                return Ok(res);
            }
            catch(Exception e)
            {
                if(e.Message == "BBL not found")
                    return Content(HttpStatusCode.NotFound, "BBL not found");
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

    }
}
