﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Framework.Tagset
{
    public interface ITagsetView: IView
    {
        List<string> CurrentTags { get; set; }
        event EventHandler SaveTagset;
    }

}
