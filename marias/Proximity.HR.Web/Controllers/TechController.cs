﻿using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;
using System;
using System.Web.Http;

namespace Proximity.HR.Web.Controllers
{
    public class TechController : ApiController
    {
        private TechnologyService _service = new TechnologyService();

        [ActionName("GetTechnologies")]
        public GenericResponse<TechnologiesDto> GetTechnologies()
        {
            var result = new BasicResponse<TechnologiesDto>();

            try
            {
                result.Response = _service.GetTechnologies();
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
        public GenericResponse<TechnologiesDto> GetTechnologiesById(int Id)
        {
            var result = new BasicResponse<TechnologiesDto>();

            try
            {
                result.Response = _service.GetTechnologyById(Id);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetTechnologyByTechnologyName")]
        public GenericResponse<TechnologiesDto> GetTechnologyByTechnologyName(string technology)
        {
            var result = new BasicResponse<TechnologiesDto>();
            try
            {
                result.Response = _service.GetTechnologyByTechnologyName(technology);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

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
    }
}
