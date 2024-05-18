using KeremCvTemplate.Data.Abstract;
using KeremCvTemplate.Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using KeremCvTemplate.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeremCvTemplate.Data.Concrete.EntityFramework.Repositories
{
    public class EFArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        public EFArticleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
