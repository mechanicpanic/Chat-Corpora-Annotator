using System.Collections.Generic;

namespace Chat_Corpora_Annotator.CSV_Wizard
{
    public interface IWizardItem
    {
        string HeaderTitle { get; }
        string StepType { get; }
        List<string> GetValues();
        
    }
}
