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
    public class SkillsSetService
    {
        public SkillsSetService()
        {
            MappingBase.Configure();
        }
        public TechnologiesDto GetEmployeeTechFeaturesLst(int employeeId)
        {   
            var result0 = new SkillsSetDto();
            using (var context = new ProximityHREntities())
            {
                var data0 = context.EmployeeTechFeatureLst(employeeId.ToString()).ToList();
                result0.AddRange(from SkillSet skillSet in data0 select Mapper.Map<SkillSet, SkillSetDto>(skillSet));
            
            }
            var result = new TechnologiesDto();
            var unitOfWork = new UnitOfWork();
            var data = unitOfWork.GetRepositoryInstance<Technology>().Get().ToList();
            result.AddRange(from Technology technology in data orderby technology.Name select Mapper.Map<Technology, TechnologyDto>(technology));

            foreach (TechnologyDto  tdto in result){
                foreach (FeatureDto ft in tdto.Features){ 
                   foreach (SkillSetDto  tdtso in result0) {
                       if (ft.Id == tdtso.Feature) {
                           ft.Level = tdtso.Level;
                           ft.Desirable = tdtso.Desirable;
                           ft.Teachable = tdtso.Teachable;
                       }
                   }
                }
            }

            return result;
        }

        public int PostEmployeeTechFeatureLst(SkillsSetDto skillSetDto)
        {
            int data=-1;
            foreach (var Feats in skillSetDto)
            {
                using (var context = new ProximityHREntities())
                {
                    
                    data = Convert.ToInt32(context.EmployeeTechFeat(Feats.Employee, Feats.Feature, Feats.Level, Feats.Teachable, Feats.Desirable, null, true, Feats.EditedBy, null, Feats.EditedBy, null).FirstOrDefault().Value);
                    if(data ==11 || data ==22){
                        throw new System.ArgumentException("ERROR:  EmployeeId=" + Feats.Employee + " FeatureID= "+Feats.Feature + "Show wrong data");
                    }
                
                }  
            }
            return data;
        }
    }
}
