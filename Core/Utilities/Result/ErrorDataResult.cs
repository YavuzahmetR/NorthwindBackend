﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        //public ErrorDataResult(string message) : base(default, false, message)
        //{
        //kullanılabilecek diğer yönetemler
        //}
        //public ErrorDataResult():base(default,false)
        //{

        //}
    }
}
