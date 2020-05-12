using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Framework.Tagset;

namespace Tagger.Framework.Main
{
    public class TagPresenter
    {
        private readonly ITagView _tagger;
        private readonly ITagService _service;
        

        public TagPresenter(ITagView tagger, ITagService service)
        {

        }
    }
}
