
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WassetPortal_DAL.Models
{

using System;
    using System.Collections.Generic;
    
public partial class User_Role
{

    public long UserRoleID { get; set; }

    public Nullable<long> FK_UserID { get; set; }

    public Nullable<int> FK_RoleID { get; set; }

    public Nullable<bool> UserRoleStatus { get; set; }



    public virtual Role Role { get; set; }

    public virtual User User { get; set; }

}

}
