﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Services.Data
{
    public interface ISketchDataModel : ISqliteBase
    {
        string Title { get; set; }
        string Abstract { get; set; }

    }
}
