using System;
using System.Web.Http;
using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;

namespace Proximity.HR.Web.Controllers
{
    public class FeaturesController : ApiController
    {
        private FeatureService _service = new FeatureService();

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
        public GenericResponse<bool> UpdateFeature(FeatureDto feature)
        {
            var result = new BasicResponse<bool>();

            try
            {
                result.Response = _service.UpdateFeature(feature);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

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

        [ActionName("GetFeat")]
        public GenericResponse<FeaturesDto> GetFeat()
        {
            var result = new BasicResponse<FeaturesDto>();

            try
            {
                result.Response = _service.GetFeature();
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }


        /*=====================================================================*/
        //[HttpGet]
        //public GenericResponse<featRepByExpDto> GetfeaturesReportByExpertise()
        //{
        //    var result = new BasicResponse<featRepByExpDto>();
        //    try
        //    {
        //        result.Response = _service.GetfeaturesReportByExpertise();
        //        result.Status = ResponseCode.Success;
        //    }
        //    catch (Exception e)
        //    {
        //        result.Status = ResponseCode.Error;
        //        result.Exception = e;
        //    }
        //    return result;
        //}




    }
}
