﻿using ForumSystem.Data.Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Data.Models
{// implement this interface to use from EF, data will automatically filled from Framework
  public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
  {
    public ApplicationUser()
    {
      // This will prevent UserManager.CreateAsync from causing exception
      this.CreatedOn = DateTime.Now;
      
    }
    public DateTime CreatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    [Index]
    public bool IsDeleted { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool PreserveCreatedOn { get; set; }

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }
  }
}
