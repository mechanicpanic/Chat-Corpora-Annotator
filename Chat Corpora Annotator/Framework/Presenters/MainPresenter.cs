using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator.Framework
{

    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IIndexService _reader;

        
        public MainPresenter(IMainView view,IIndexService reader)
        {
            this._view = view;
            this._reader = reader;

        }

        public void AddDocumentsToDisplay(int count)
        {
            _reader.LoadSomeDocuments(_view.IndexPath, count);
            _view.DisplayDocuments();
        }

    }


}
