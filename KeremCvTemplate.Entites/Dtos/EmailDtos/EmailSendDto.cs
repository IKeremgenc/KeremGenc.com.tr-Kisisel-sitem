﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeremCvTemplate.Entites.Dtos.EmailDtos
{
    public class EmailSendDto
    {
        [DisplayName("İsminiz")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(60, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Telefon No")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(20, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır.")]
        [MinLength(10, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır.")]
        public string Phone { get; set; }

        [DisplayName("E-Posta Adresiniz")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır.")]
        [MinLength(10, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır.")]
        public string Email { get; set; }



        [DisplayName("Mesajınız")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(1500, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır.")]
        [MinLength(20, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır.")]
        public string Message { get; set; }

        public DateTime DateTime { get; set; }
    }
}
