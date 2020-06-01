using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Framework.Services;
using Viewer.Framework.Views;

namespace Viewer.Framework.Presenters
{
    public class SuggestPresenter
    {
        private readonly ISuggesterView _sugg;
        private readonly ISuggestService _service;
    }
}
