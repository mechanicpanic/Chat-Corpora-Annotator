using System.Collections.Generic;

namespace Viewer.CSV_Wizard
{
    public interface IWizardItem
    {
        string HeaderTitle { get; }
        string StepType { get; }
        List<string> GetValues();
        
    }
}
