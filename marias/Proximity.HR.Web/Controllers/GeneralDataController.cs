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
    public class GeneralDataController : ApiController
    {
        private GeneralDataService _service = new GeneralDataService();

        [ActionName("GetCountries")]
        public GenericResponse<GeneralCollectionDto> GetCountries()
        {
            var result = new BasicResponse<GeneralCollectionDto>();

            try
            {
                result.Response = _service.GetCountries();
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetStates")]
        public GenericResponse<GeneralCollectionDto> GetStates(int countryId)
        {
            var result = new BasicResponse<GeneralCollectionDto>();

            try
            {
                result.Response = _service.GetStates(countryId);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetCities")]
        public GenericResponse<GeneralCollectionDto> GetCities(int stateId)
        {
            var result = new BasicResponse<GeneralCollectionDto>();

            try
            {
                result.Response = _service.GetCities(stateId);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetAllCities")]
        public GenericResponse<GeneralCollectionDto> GetAllCities()
        {
            var result = new BasicResponse<GeneralCollectionDto>();

            try
            {
                result.Response = _service.GetAllCities();
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetDistricts")]
        public GenericResponse<GeneralCollectionDto> GetDistricts(int cityId)
        {
            var result = new BasicResponse<GeneralCollectionDto>();

            try
            {
                result.Response = _service.GetDistricts(cityId);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetSchooling")]
        public GenericResponse<GeneralCollectionDto> GetSchooling()
        {
            var result = new BasicResponse<GeneralCollectionDto>();

            try
            {
                result.Response = _service.GetSchooling();
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetGenders")]
        public GenericResponse<GeneralCollectionDto> GetGenders()
        {
            var result = new BasicResponse<GeneralCollectionDto>();

            try
            {
                result.Response = _service.GetGenders();
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetMaritalStatus")]
        public GenericResponse<GeneralCollectionDto> GetMaritalStatus()
        {
            var result = new BasicResponse<GeneralCollectionDto>();

            try
            {
                result.Response = _service.GetMaritalStatus();
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
