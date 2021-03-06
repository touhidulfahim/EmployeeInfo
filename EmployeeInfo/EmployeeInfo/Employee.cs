//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeInfo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string SpouseName { get; set; }
        public int GenderId { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int MaritalStatusId { get; set; }
        public int ReligionId { get; set; }
        public int BloodGroupId { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string NationalIdentity { get; set; }
        public string ImagePath { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int PoliceStationId { get; set; }
        public string ZipCode { get; set; }
        public System.DateTime JoiningDate { get; set; }
        public int PositionId { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public decimal Salary { get; set; }
        public string EmpId { get; set; }
    
        public virtual BloodGroup BloodGroup { get; set; }
        public virtual Education Education { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual MaritalStatu MaritalStatu { get; set; }
        public virtual PoliceStation PoliceStation { get; set; }
        public virtual Position Position { get; set; }
        public virtual Religion Religion { get; set; }
        public virtual Role Role { get; set; }
        public virtual Status Status { get; set; }
        public virtual Title Title { get; set; }
    }
}
