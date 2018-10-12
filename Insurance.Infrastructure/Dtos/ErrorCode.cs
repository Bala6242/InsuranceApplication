﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Dtos
{
    public class ErrorCode
    {
        public ErrorCode(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public int Code { get; private set; }
        public string Message { get; private set; }
    }
}
