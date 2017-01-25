using AutoMapper;
using Proximity.HR.Data;
using Proximity.HR.Data.Repository;
using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ReportsDto;
using Proximity.HR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Proximity.HR.Services.Service
{
    public class ReportService
    {
        public ReportService()
        {
            MappingBase.Configure();
        }

        // GetfeaturesReportByExpertise Report
        public List<dynamic> GetfeaturesReportByExpertise()
        {
            
            var context = new ProximityHREntities();

            var data = context.featuresReportByExpertise().ToList<dynamic>();
            
            return data;
        }

        // averageWorkingYears Report
        public List<dynamic> averageWorkingYearsReport()
        {
            var context = new ProximityHREntities();

            var data = context.averageWorkingYearsReport().ToList<dynamic>();

            return data;
        }

        // average
        public dynamic average()
        {
            var context = new ProximityHREntities();

            var data = context.average();

            return data;

        }

        // report marital status
        public List<dynamic> maritalStatusReport()
        {
            var context = new ProximityHREntities();

            var data = context.maritalStatusReport().ToList<dynamic>();

            return data;
        }

        // report ages 
        public List<dynamic> agesReport()
        {
            var context = new ProximityHREntities();

            var data = context.agesReport().ToList<dynamic>();

            return data;
        }

        // report demographic
        public List<dynamic> demographicReport()
        {
            var context = new ProximityHREntities();

            var data = context.demographicReport().ToList<dynamic>();

            return data;
        }

        // report expiration dates
        public List<dynamic> expirationDatesReport()
        {
            var context = new ProximityHREntities();

            var data = context.expirationDatesReport().ToList<dynamic>();

            return data;
        }



        // using linq
        public List<dynamic> reportShitty()
        {
           
            var context = new ProximityHREntities();

            var query = from sk in context.SkillSets
                         join e in context.Employees on sk.Employee equals e.Id
                         join f in context.Features on sk.Feature equals f.Id
                         orderby sk.Level descending, e.FullName descending

                         select new featuresReportByExpertiseDto
                         {
                            EMPLOYEE = e.FullName,
                            FEATURE = f.Name,
                            LEVEL = sk.Level
                         };
            
           var result = query.ToList<dynamic>();
           
            return result;
        }
        
    }
}
