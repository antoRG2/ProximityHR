using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;
using System;
using System.Web.Http;

namespace Proximity.HR.Web.Controllers
{
    public class SkillsSetController : ApiController
    {
        private SkillsSetService _service = new SkillsSetService();

        [ActionName("GetEmployeeTechFeatureLst")]
        public GenericResponse<TechnologiesDto> GetEmployeeTechFeatureLst(int UserId)
        {
            var result = new BasicResponse<TechnologiesDto>();

            try
            {
                result.Response = _service.GetEmployeeTechFeaturesLst(UserId);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }
        [ActionName("PostEmployeeTechFeatureLst")]
        public GenericResponse<int> PostEmployeeTechFeatureLst(SkillsSetDto skillSetDto)
        {
            var result = new BasicResponse<int>();
            try
            {
                result.Response = _service.PostEmployeeTechFeatureLst(skillSetDto);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }
            return result;
        }
    }

}