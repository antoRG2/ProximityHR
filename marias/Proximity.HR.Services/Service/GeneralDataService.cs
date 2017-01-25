using AutoMapper;
using Proximity.HR.Data;
using Proximity.HR.Data.Repository;
using Proximity.HR.Models.Dto;
using Proximity.HR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Services.Service
{
    public class GeneralDataService
    {
        public GeneralDataService()
        {
            MappingBase.Configure();
        }

        public GeneralCollectionDto GetCountries()
        {
            var result = new GeneralCollectionDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<Country>().Get().ToList();
            result.AddRange(from Country country in data 
                            where country.Enabled == true
                            select Mapper.Map<Country, GeneralCollectionItemDto>(country));

            return result;
        }

        public GeneralCollectionDto GetStates(int countryId)
        {
            var result = new GeneralCollectionDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<State>().Find(x => x.Country == countryId).ToList();
            result.AddRange(from State state in data
                            where state.Enabled == true
                            select Mapper.Map<State, GeneralCollectionItemDto>(state));

            return result;
        }

        public GeneralCollectionDto GetCities(int stateId)
        {

            var result = new GeneralCollectionDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<City>().Find(x => x.State == stateId).ToList();
            result.AddRange(from City city in data
                            where city.Enabled == true
                            select Mapper.Map<City, GeneralCollectionItemDto>(city));

            return result;
        }

        public GeneralCollectionDto GetAllCities()
        {

            var result = new GeneralCollectionDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<City>().Get().ToList();
            result.AddRange(from City city in data
                            where city.Enabled == true
                            select Mapper.Map<City, GeneralCollectionItemDto>(city));

            return result;
        }

        public GeneralCollectionDto GetDistricts(int cityId)
        {
            var result = new GeneralCollectionDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<District>().Find(x => x.City == cityId).ToList();
            result.AddRange(from District district in data
                            where district.Enabled == true
                            select Mapper.Map<District, GeneralCollectionItemDto>(district));

            return result;
        }

        public GeneralCollectionDto GetSchooling()
        {
            var result = new GeneralCollectionDto();
            result.Add(new GeneralCollectionItemDto { Value = 1, Display = "Primaria" });
            result.Add(new GeneralCollectionItemDto { Value = 2, Display = "Segundaria" });
            result.Add(new GeneralCollectionItemDto { Value = 3, Display = "Tecnico Profesional" });
            result.Add(new GeneralCollectionItemDto { Value = 4, Display = "Bachiller Universitario" });
            result.Add(new GeneralCollectionItemDto { Value = 5, Display = "Licenciatura" });
            result.Add(new GeneralCollectionItemDto { Value = 6, Display = "Maestria" });
           // result.Add(new GeneralCollectionItemDto { Value = 7, Display = "Doctorado" });

            return result;
        }

        public GeneralCollectionDto GetGenders()
        {
            var result = new GeneralCollectionDto();
            result.Add(new GeneralCollectionItemDto { Value = 1, Display = "Masculino" });
            result.Add(new GeneralCollectionItemDto { Value = 2, Display = "Femenino" });

            return result;
        }

        public GeneralCollectionDto GetMaritalStatus()
        {
            var result = new GeneralCollectionDto();
            result.Add(new GeneralCollectionItemDto { Value = 1, Display = "Soltero (a)" });
            result.Add(new GeneralCollectionItemDto { Value = 2, Display = "Casado (a)" });
            result.Add(new GeneralCollectionItemDto { Value = 3, Display = "Divorciado (a)" });
            result.Add(new GeneralCollectionItemDto { Value = 4, Display = "Viudo (a)" });
            result.Add(new GeneralCollectionItemDto { Value = 5, Display = "Union Libre" });
            
            return result;
        }
    }
}
