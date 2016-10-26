﻿namespace ForumSystem.Data.Common.Repository
{
  using Models;
  using System.Data.Entity;
  using System.Linq;



  public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
  {
    public DeletableEntityRepository(DbContext context)
        : base(context)
    {
    }

    public override IQueryable<T> All()
    {
      // all not delited records
      return base.All().Where(x => !x.IsDeleted);
    }

    public IQueryable<T> AllWithDeleted()
    {
      return base.All();
    }
  }
}
