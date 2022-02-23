
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
    
public partial class User
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public User()
    {

        this.User_Role = new HashSet<User_Role>();

        this.UserActions = new HashSet<UserAction>();

    }


    public long UserID { get; set; }

    public string UserName { get; set; }

    public string UserCode { get; set; }

    public string Mobile { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public Nullable<bool> UserStatus { get; set; }

    public Nullable<int> FK_OrgID { get; set; }

    public string Password { get; set; }



    public virtual Hospital Hospital { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<User_Role> User_Role { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UserAction> UserActions { get; set; }

}

}
