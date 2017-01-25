using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proximity.HR.Web.Controllers
{
    public class FeatureController : ApiController
    {
        private FeatureService _service = new FeatureService();

        [ActionName("GetTechnologiesById")]
        public GenericResponse<FeaturesDto> GetTechnologiesById(int Id)
        {
            var result = new BasicResponse<FeaturesDto>();

            try
            {
                result.Response = _service.GetFeactureById(Id);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("PostFeature")]
        public GenericResponse<int> PostFeature(FeatureDto Feature)
        {
            var result = new BasicResponse<int>();

            try
            {
                result.Response = _service.AddFeature(Feature);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("UpdateFeature")]
        public GenericResponse<bool> UpdatePostFeature(FeatureDto Feature)
        {
            var result = new BasicResponse<bool>();

            try
            {

                result.Response = _service.UpdateFeature(Feature);
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

        [ActionName("DeleteFeature")]
        public GenericResponse<bool> DeleteFeature(FeatureDto Feature)
        {
            var result = new BasicResponse<bool>();

            try
            {

                result.Response = _service.DeleteFeature(Feature);
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
