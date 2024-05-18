﻿using KeremCvTemplate.Entites.Concrete;
using KeremCvTemplate.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KeremCvTemplate.Entites.Dtos
{
    public class ArticleListDto:DtoGetBase
    {
        public IList<Article> Articles { get; set; }
        public int? CategoryId { get; set; }
       
    }
}
