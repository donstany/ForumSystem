using ForumSystem.Data.Common.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Data.Models
{
  public class Tag : AuditInfo, IDeletableEntity
  {

    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    [Index()]
    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }

  }
}
