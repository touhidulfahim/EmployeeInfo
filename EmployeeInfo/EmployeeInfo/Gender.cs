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
    
    public partial class Gender
    {
        public Gender()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
