﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.BusinessServices
{
    public interface IServiceWrapper
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }
    }

    public interface IServiceWrapper<out T> : IServiceWrapper
    {
        T Data { get; }
    }
}
