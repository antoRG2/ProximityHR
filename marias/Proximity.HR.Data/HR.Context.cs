﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proximity.HR.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProximityHREntities : DbContext
    {
        public ProximityHREntities()
            : base("name=ProximityHREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    
        public virtual ObjectResult<SkillSet> EmployeeTechFeatureLst(string employeeId)
        {
            var employeeIdParameter = employeeId != null ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SkillSet>("EmployeeTechFeatureLst", employeeIdParameter);
        }
    
        public virtual ObjectResult<SkillSet> EmployeeTechFeatureLst(string employeeId, MergeOption mergeOption)
        {
            var employeeIdParameter = employeeId != null ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SkillSet>("EmployeeTechFeatureLst", mergeOption, employeeIdParameter);
        }
    
        public virtual ObjectResult<SkillSet> EmployeeTechFeature(Nullable<int> employee, Nullable<int> feature, Nullable<int> level, Nullable<bool> teachable, Nullable<bool> desirable, string detail, Nullable<bool> enable, string createdBy, Nullable<System.DateTime> createdDate, string editedBy, Nullable<System.DateTime> editedDate)
        {
            var employeeParameter = employee.HasValue ?
                new ObjectParameter("Employee", employee) :
                new ObjectParameter("Employee", typeof(int));
    
            var featureParameter = feature.HasValue ?
                new ObjectParameter("Feature", feature) :
                new ObjectParameter("Feature", typeof(int));
    
            var levelParameter = level.HasValue ?
                new ObjectParameter("Level", level) :
                new ObjectParameter("Level", typeof(int));
    
            var teachableParameter = teachable.HasValue ?
                new ObjectParameter("Teachable", teachable) :
                new ObjectParameter("Teachable", typeof(bool));
    
            var desirableParameter = desirable.HasValue ?
                new ObjectParameter("Desirable", desirable) :
                new ObjectParameter("Desirable", typeof(bool));
    
            var detailParameter = detail != null ?
                new ObjectParameter("Detail", detail) :
                new ObjectParameter("Detail", typeof(string));
    
            var enableParameter = enable.HasValue ?
                new ObjectParameter("Enable", enable) :
                new ObjectParameter("Enable", typeof(bool));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var editedByParameter = editedBy != null ?
                new ObjectParameter("EditedBy", editedBy) :
                new ObjectParameter("EditedBy", typeof(string));
    
            var editedDateParameter = editedDate.HasValue ?
                new ObjectParameter("EditedDate", editedDate) :
                new ObjectParameter("EditedDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SkillSet>("EmployeeTechFeature", employeeParameter, featureParameter, levelParameter, teachableParameter, desirableParameter, detailParameter, enableParameter, createdByParameter, createdDateParameter, editedByParameter, editedDateParameter);
        }
    
        public virtual ObjectResult<SkillSet> EmployeeTechFeature(Nullable<int> employee, Nullable<int> feature, Nullable<int> level, Nullable<bool> teachable, Nullable<bool> desirable, string detail, Nullable<bool> enable, string createdBy, Nullable<System.DateTime> createdDate, string editedBy, Nullable<System.DateTime> editedDate, MergeOption mergeOption)
        {
            var employeeParameter = employee.HasValue ?
                new ObjectParameter("Employee", employee) :
                new ObjectParameter("Employee", typeof(int));
    
            var featureParameter = feature.HasValue ?
                new ObjectParameter("Feature", feature) :
                new ObjectParameter("Feature", typeof(int));
    
            var levelParameter = level.HasValue ?
                new ObjectParameter("Level", level) :
                new ObjectParameter("Level", typeof(int));
    
            var teachableParameter = teachable.HasValue ?
                new ObjectParameter("Teachable", teachable) :
                new ObjectParameter("Teachable", typeof(bool));
    
            var desirableParameter = desirable.HasValue ?
                new ObjectParameter("Desirable", desirable) :
                new ObjectParameter("Desirable", typeof(bool));
    
            var detailParameter = detail != null ?
                new ObjectParameter("Detail", detail) :
                new ObjectParameter("Detail", typeof(string));
    
            var enableParameter = enable.HasValue ?
                new ObjectParameter("Enable", enable) :
                new ObjectParameter("Enable", typeof(bool));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var editedByParameter = editedBy != null ?
                new ObjectParameter("EditedBy", editedBy) :
                new ObjectParameter("EditedBy", typeof(string));
    
            var editedDateParameter = editedDate.HasValue ?
                new ObjectParameter("EditedDate", editedDate) :
                new ObjectParameter("EditedDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SkillSet>("EmployeeTechFeature", mergeOption, employeeParameter, featureParameter, levelParameter, teachableParameter, desirableParameter, detailParameter, enableParameter, createdByParameter, createdDateParameter, editedByParameter, editedDateParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> EmployeeTechFeat(Nullable<int> employee, Nullable<int> feature, Nullable<int> level, Nullable<bool> teachable, Nullable<bool> desirable, string detail, Nullable<bool> enable, string createdBy, Nullable<System.DateTime> createdDate, string editedBy, Nullable<System.DateTime> editedDate)
        {
            var employeeParameter = employee.HasValue ?
                new ObjectParameter("Employee", employee) :
                new ObjectParameter("Employee", typeof(int));
    
            var featureParameter = feature.HasValue ?
                new ObjectParameter("Feature", feature) :
                new ObjectParameter("Feature", typeof(int));
    
            var levelParameter = level.HasValue ?
                new ObjectParameter("Level", level) :
                new ObjectParameter("Level", typeof(int));
    
            var teachableParameter = teachable.HasValue ?
                new ObjectParameter("Teachable", teachable) :
                new ObjectParameter("Teachable", typeof(bool));
    
            var desirableParameter = desirable.HasValue ?
                new ObjectParameter("Desirable", desirable) :
                new ObjectParameter("Desirable", typeof(bool));
    
            var detailParameter = detail != null ?
                new ObjectParameter("Detail", detail) :
                new ObjectParameter("Detail", typeof(string));
    
            var enableParameter = enable.HasValue ?
                new ObjectParameter("Enable", enable) :
                new ObjectParameter("Enable", typeof(bool));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var editedByParameter = editedBy != null ?
                new ObjectParameter("EditedBy", editedBy) :
                new ObjectParameter("EditedBy", typeof(string));
    
            var editedDateParameter = editedDate.HasValue ?
                new ObjectParameter("EditedDate", editedDate) :
                new ObjectParameter("EditedDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("EmployeeTechFeat", employeeParameter, featureParameter, levelParameter, teachableParameter, desirableParameter, detailParameter, enableParameter, createdByParameter, createdDateParameter, editedByParameter, editedDateParameter);
        }
    
        public virtual ObjectResult<featuresReportByExpertise_Result> featuresReportByExpertise()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<featuresReportByExpertise_Result>("featuresReportByExpertise");
        }
    
        public virtual ObjectResult<averageWorkingYearsReport_Result> averageWorkingYearsReport()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<averageWorkingYearsReport_Result>("averageWorkingYearsReport");
        }
    
        public virtual ObjectResult<Nullable<int>> average()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("average");
        }
    
        public virtual ObjectResult<demographicReport_Result> demographicReport()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<demographicReport_Result>("demographicReport");
        }
    
        public virtual ObjectResult<expirationDatesReport_Result> expirationDatesReport()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<expirationDatesReport_Result>("expirationDatesReport");
        }
    
        public virtual ObjectResult<maritalStatusReport_Result> maritalStatusReport()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<maritalStatusReport_Result>("maritalStatusReport");
        }
    
        public virtual ObjectResult<agesReport_Result> agesReport()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<agesReport_Result>("agesReport");
        }
    }
}
