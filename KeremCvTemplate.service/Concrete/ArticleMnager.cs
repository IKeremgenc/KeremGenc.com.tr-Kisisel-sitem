using AutoMapper;
using KeremCvTemplate.Data.Abstract;
using KeremCvTemplate.Entites.Concrete;
using KeremCvTemplate.Entites.Dtos;
using KeremCvTemplate.service.Abstract;
using KeremCvTemplate.Shared.Utilities.Results.Abstract;
using KeremCvTemplate.Shared.Utilities.Results.ComplexTypes;
using KeremCvTemplate.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ArticleMnager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleMnager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
          
            article.CreatedDate = DateTime.Now;



          
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Başarılı İşlem");
        }

     

    

        public async Task<IResult> DeleteAsync(int articleId )
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Silindi");
            }
            return new Result(ResultStatus.Error,"Silinirken Hata Oluştu");
        }

        public async Task<IDataResult<ArticleListDto>> GetAllAsync()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {

                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "İşlem Başarısız", null);
        }

        public async Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(article);
                return new DataResult<ArticleUpdateDto>(ResultStatus.Success, articleUpdateDto);
            }
            else
            {
                return new DataResult<ArticleUpdateDto>(ResultStatus.Error, "İşlem Hatalı", null);
            }
        }

        public async Task<IDataResult<ArticleDto>> GetAsync(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
            if (article != null)
            {

                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error,"İşlem Başarısız", null);
        }

     

    

        public async Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto)
        {
            var oldArticle = await _unitOfWork.Articles.GetAsync(a => a.Id == articleUpdateDto.Id);
            var article = _mapper.Map<ArticleUpdateDto, Article>(articleUpdateDto, oldArticle);
      
            article.CreatedDate = DateTime.Now;
            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "İşlem Başarılı");
        }

     
    }
}
