
//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
public partial class Technology
{

    public Technology()
    {

        this.Features = new HashSet<Feature>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public string Detail { get; set; }

    public bool Enabled { get; set; }

    public string CreatedBy { get; set; }

    public System.DateTime CreatedDate { get; set; }

    public string EditedBy { get; set; }

    public Nullable<System.DateTime> EditedDate { get; set; }



    public virtual ICollection<Feature> Features { get; set; }

}

}