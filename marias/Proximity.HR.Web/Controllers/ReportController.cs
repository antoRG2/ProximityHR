using System;
using System.Web.Http;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;

namespace Proximity.HR.Web.Controllers
{
    public class ReportController : ApiController
    {
        private ReportService _service = new ReportService();


        // GetfeaturesReportByExpertise report
        [HttpGet]
        public GenericResponse<dynamic> GetfeaturesReportByExpertise()
        {
            var result = new BasicResponse<dynamic>();
            try
            {
                result.Response = _service.GetfeaturesReportByExpertise();
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }
            return result;
        }

        // averageWorkingYearsReport report

        [HttpGet]
        public GenericResponse<dynamic> averageWorkingYearsReport()
        {
            var result = new BasicResponse<dynamic>();
            try
            {
                result.Response = _service.averageWorkingYearsReport();
                result.Status = ResponseCode.Success;

            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        // marital status report

        [HttpGet]
        public GenericResponse<dynamic> maritalStatusReport()
        {
            var result = new BasicResponse<dynamic>();
            try
            {
                result.Response = _service.maritalStatusReport();
                result.Status = ResponseCode.Success;

            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        // averageWorkingYearsReport report

        [HttpGet]
        public GenericResponse<dynamic> agesReport()
        {
            var result = new BasicResponse<dynamic>();
            try
            {
                result.Response = _service.agesReport();
                result.Status = ResponseCode.Success;

            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        // averageWorkingYearsReport report

        [HttpGet]
        public GenericResponse<dynamic> demographicReport()
        {
            var result = new BasicResponse<dynamic>();
            try
            {
                result.Response = _service.demographicReport();
                result.Status = ResponseCode.Success;

            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        // averageWorkingYearsReport report

        [HttpGet]
        public GenericResponse<dynamic> expirationDatesReport()
        {
            var result = new BasicResponse<dynamic>();
            try
            {
                result.Response = _service.expirationDatesReport();
                result.Status = ResponseCode.Success;

            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [HttpGet]
        public GenericResponse<dynamic> average()
        {
            var result = new BasicResponse<dynamic>();
            try
            {
                result.Response = _service.average();
                result.Status = ResponseCode.Success;

            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }



        [HttpGet]
        public GenericResponse<dynamic> shittyReport()
        {
            var result = new BasicResponse<dynamic>();
            try
            {
                result.Response = _service.reportShitty();
                result.Status = ResponseCode.Success;
            }
            catch(Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

    }
}
