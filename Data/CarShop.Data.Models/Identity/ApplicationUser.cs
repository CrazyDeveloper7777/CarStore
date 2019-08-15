// ReSharper disable VirtualMemberCallInConstructor
namespace CarShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CarShop.Data.Common.Models;
    using CarShop.Data.Models.Ads;
    using CarShop.Data.Models.Vehicles;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
            : this(null)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Ads = new HashSet<Ad>();
            this.Vehicles = new HashSet<Vehicle>();
        }

        public ApplicationUser(string name)
            : base(name)
        {
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        [Phone]
        public string PhoneNumber2 { get; set; }

        [Phone]
        public string PhoneNumber3 { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
