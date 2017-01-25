using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Proximity.HR.Web.Controllers
{
    public class SkillsController
    {
        private TechnologyService _service = new TechnologyService();

        [ActionName("PostTechnology")]
        public GenericResponse<int> PostTechnology(TechnologyDto technology)
        {
            var result = new BasicResponse<int>();

            try
            {
                result.Response = _service.AddTechnology(technology);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("UpdateTechnology")]
        public GenericResponse<bool> UpdateTechnology(TechnologyDto technology)
        {
            var result = new BasicResponse<bool>();

            try
            {

                result.Response = _service.UpdateTechnology(technology);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Response = false;
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("DeleteTechnology")]
        public GenericResponse<bool> DeleteTechnology(TechnologyDto technology)
        {
            var result = new BasicResponse<bool>();

            try
            {

                result.Response = _service.DeleteTechnology(technology);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Response = false;
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }
    }
}