using AutoMapper;
using Proximity.HR.Data;
using Proximity.HR.Data.Repository;
using Proximity.HR.Models.Dto;
using Proximity.HR.Service;
using System;
using System.Linq;

namespace Proximity.HR.Services.Service
{
    public class TechnologyService
    {
        public TechnologyService()
        {
            MappingBase.Configure();
        }

        public TechnologiesDto GetTechnologies()
        {
            var result = new TechnologiesDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<Technology>().Get().ToList();
            result.AddRange(from Technology technology in data select Mapper.Map<Technology, TechnologyDto>(technology));

            return result;
        }

        public TechnologiesDto GetTechnologyById(int technologyId)
        {
            var result = new TechnologiesDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<Technology>().Find(x => x.Id == technologyId).ToList();
            result.AddRange(from Technology technology in data select Mapper.Map<Technology, TechnologyDto>(technology));

            return result;
        }

        public TechnologiesDto GetTechnologyByTechnologyName(string technologyName)
        {
            var result = new TechnologiesDto();
            using (var unitOfWork = new UnitOfWork())
            {
                var data = unitOfWork.GetRepositoryInstance<Technology>().Find(x => x.Name == technologyName).ToList();
                result.AddRange(from Technology technology in data select Mapper.Map<Technology, TechnologyDto>(technology));
            }
            return result;
        }

        public int AddTechnology(TechnologyDto technology)
        {
            var technologyToProcess = Mapper.Map<Technology>(technology);
            var unitOfWork = new UnitOfWork();
            var repository = unitOfWork.GetRepositoryInstance<Technology>();

            foreach (var feature in technologyToProcess.Features)
            {
                feature.Enabled = technologyToProcess.Enabled;
                feature.CreatedBy = technologyToProcess.CreatedBy;
                feature.CreatedDate = technologyToProcess.CreatedDate;
                feature.EditedBy = technologyToProcess.EditedBy;
                feature.EditedDate = technologyToProcess.EditedDate;
            }


            repository.Add(technologyToProcess);
            repository.Save();
            return technologyToProcess.Id;
        }

        public bool UpdateTechnology(TechnologyDto technology)
        {
            var repository = new UnitOfWork().GetRepositoryInstance<Technology>();
            var reposTech = repository.Find(x => x.Id == technology.Id).First();
            var mappedTechnology = Mapper.Map<Technology>(technology);
            var featuresToDelete = new System.Collections.Generic.List<Feature> { };

            #region update modified technology
            if (reposTech.Name != mappedTechnology.Name ||
                reposTech.Detail != mappedTechnology.Detail)
            {
                reposTech.Name = mappedTechnology.Name;
                reposTech.Detail = mappedTechnology.Detail;
                reposTech.EditedBy = "admin";
                reposTech.EditedDate = DateTime.Now;
            }
            #endregion

            foreach (var feature in reposTech.Features.ToList())
            {
                var tech = mappedTechnology.Features.FirstOrDefault(x => x.Id == feature.Id);
                if (tech != null)
                {
                    feature.Name = tech.Name;
                    feature.Detail = tech.Detail;
                    feature.EditedBy = "admin";
                    feature.EditedDate = DateTime.Now;
                }
                else
                {
                    featuresToDelete.Add(feature);
                }
            }

            #region Add new features
            foreach (var mapTech in mappedTechnology.Features.Where(x => x.Id == 0).ToList())
            {
                mapTech.Enabled = true;
                mapTech.CreatedBy = "admin";
                mapTech.CreatedDate = DateTime.Now;
                reposTech.Features.Add(mapTech);
            }
            #endregion
            repository.Save();
            repository.Dispose();

            #region features to delete
            if (featuresToDelete.Count > 0)
            { 
                var repFeatures = new UnitOfWork().GetRepositoryInstance<Feature>();
                foreach (var feature in featuresToDelete)
                { 
                    repFeatures.Delete(feature);
                }
                repFeatures.Save();
            }
            #endregion

            return true;
        }

        public bool DeleteTechnology(TechnologyDto technology)
        {
            var technologyToProcess = Mapper.Map<Technology>(technology);
            var unitOfWork = new UnitOfWork();
            var repository = unitOfWork.GetRepositoryInstance<Technology>();
            repository.Delete(technologyToProcess);
            repository.Save();
            return true;
        }
    }
}
