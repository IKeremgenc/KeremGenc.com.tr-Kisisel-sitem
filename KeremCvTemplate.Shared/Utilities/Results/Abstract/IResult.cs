﻿using KeremCvTemplate.Shared.Entities.Concrete;
using KeremCvTemplate.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeremCvTemplate.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;} // ResultStatus.Success // ResultStatus.Error
        public string Message { get;}
        public Exception Exception { get;}
        public IEnumerable<ValidationError> ValidationErrors { get; set; } // ValidationErrors.Add
    }
}
