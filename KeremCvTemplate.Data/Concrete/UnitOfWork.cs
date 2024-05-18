using KeremCvTemplate.Data.Abstract;
using KeremCvTemplate.Data.Concrete.EntityFramework.Contexts;
using KeremCvTemplate.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeremCvTemplate.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DetnisContex _DetnisContex;
        private readonly EFArticleRepository _articleRepository;

   
        public IArticleRepository Articles => _articleRepository ?? new EFArticleRepository(_DetnisContex);

     

        public async ValueTask DisposeAsync()
        {
            await _DetnisContex.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _DetnisContex.SaveChangesAsync();
        }
    }
}
