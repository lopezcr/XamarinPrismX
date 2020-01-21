﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrismX.Model
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
