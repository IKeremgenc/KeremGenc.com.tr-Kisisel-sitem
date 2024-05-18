using KeremCvTemplate.Entites.Concrete;
using KeremCvTemplate.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KeremCvTemplate.Entites.Dtos
{
    public class UserListDto:DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
