using AutoMapper;
using Proximity.HR.Data;
using Proximity.HR.Data.Repository;
using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ReportsDto;
using Proximity.HR.Service;
using System.Linq;

namespace Proximity.HR.Services.Service
{
    public class FeatureService
    {
        public FeatureService()
        {
            MappingBase.Configure();
        }

        public FeaturesDto GetFeactureById(int feactureId)
        {
            var result = new FeaturesDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<Feature>().Find(x => x.Id == feactureId).ToList();
            result.AddRange(from Feature feacture in data select Mapper.Map<Feature, FeatureDto>(feacture));

            return result;
        }

        public FeaturesDto GetFeature()
        {
            var result = new FeaturesDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<Feature>().Get().ToList();
            result.AddRange(from Feature feacture in data select Mapper.Map<Feature, FeatureDto>(feacture));

            return result;
        }

        /*=====================================================================*/
        //public featRepByExpDto GetfeaturesReportByExpertise()
        //{
        //    var result0 = new featRepByExpDto();
        //    var context = new ProximityHREntities();

        //    var data0 = context.featuresReportByExpertise().ToList();
        //    result0.AddRange(from featuresReportByExpertise_Result frbe in data0 select Mapper.Map<featuresReportByExpertise_Result, featuresReportByExpertiseDto>(frbe));
        //    return result0;
        //}

        /*=====================================================================*/

        /*=====================================================================*/
        public FeaturesDto GetFeactureByTechnologyId(int technologyId)
        {
            var result = new FeaturesDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<Feature>().Find(x => x.Technology == technologyId).ToList();
            result.AddRange(from Feature feacture in data select Mapper.Map<Feature, FeatureDto>(feacture));

            return result;
        }

        public int AddFeature(FeatureDto feature)
        {
            var featureToProcess = Mapper.Map<Feature>(feature);
            var unitOfWork = new UnitOfWork();
            var repository = unitOfWork.GetRepositoryInstance<Feature>();
            repository.Add(featureToProcess);
            repository.Save();
            return featureToProcess.Id;
        }

        public bool UpdateFeature(FeatureDto feature)
        {
            var featureToProcess = Mapper.Map<Feature>(feature);
            var unitOfWork = new UnitOfWork();
            var repository = unitOfWork.GetRepositoryInstance<Feature>();
            repository.Edit(featureToProcess);
            repository.Save();
            return true;
        }

        public bool DeleteFeature(FeatureDto feacture)
        {
            var featureToProcess = Mapper.Map<Feature>(feacture);
            var unitOfWork = new UnitOfWork();
            var repository = unitOfWork.GetRepositoryInstance<Feature>();
            repository.Delete(featureToProcess);
            repository.Save();
            return true;
        }
    }
}
