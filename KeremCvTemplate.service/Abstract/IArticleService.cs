using KeremCvTemplate.Entites.Dtos;
using KeremCvTemplate.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeremCvTemplate.service.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> GetAsync(int articleId);
        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId);
        Task<IDataResult<ArticleListDto>> GetAllAsync();

        Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto );
        Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName);

        Task<IResult> DeleteAsync(int articleId );
      
     

    }
}
