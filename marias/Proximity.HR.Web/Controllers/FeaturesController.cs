using Proximity.HR.Data;
using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ReportsDto;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;
using System;
using System.Web.Http;

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
