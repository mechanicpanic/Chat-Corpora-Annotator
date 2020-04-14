using Chat_Corpora_Annotator.CSV_Wizard;
using Chat_Corpora_Annotator.Framework;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chat_Corpora_Annotator
{
	public partial class CSVLoader : Form, ICSVView
	{
		public CSVLoader()
		{
			InitializeComponent();
		}

		private int currentStep;
		private int totalSteps;
		private List<IWizardItem> steps;
		public string[] AllFields { get; set; }
		public List<string> SelectedFields { get; set; }
		public string DateFieldKey { get; set; }
		public string SenderFieldKey { get; set; }
		public string TextFieldKey { get; set; }


		public event Action DataLoaded;
		public event Action HeaderFinished;

		public void ShowError(string errorMessage)
		{
			throw new NotImplementedException();
		}

		private void ShowStep()
		{
			// Update buttons.
			cmdPrev.Visible = (currentStep != 0);
			if (currentStep == totalSteps)
				cmdNext.Text = "Finish";
			else
				cmdNext.Text = "Next >";


			stepLabel.Text = steps[currentStep].HeaderTitle;
			Text = "Step " + (currentStep + 1).ToString() + " of " + totalSteps.ToString();

			panelStep.Controls.Clear();
			UserControl ctrl = (UserControl)steps[currentStep];
			panelStep.Controls.Add(ctrl);
		}



		private void cmdNext_Click(object sender, EventArgs e)
		{
			if (currentStep == totalSteps)
			{
				DataLoaded();

			}
			else
			{
				switch (steps[currentStep].StepType)
				{
					case "Header":
						this.SelectedFields = steps[currentStep].GetValues();
						break;
					case "Metadata":
						this.DateFieldKey = steps[currentStep].GetValues()[0];
						this.SenderFieldKey = steps[currentStep].GetValues()[1];
						this.TextFieldKey = steps[currentStep].GetValues()[2];
						HeaderFinished();
						cmdNext.Enabled = false;
						break;		

				}
				currentStep++;
				ShowStep();
			}

		}
		private void cmdPrev_Click(object sender, EventArgs e)
		{
			//currentStep--;
			//ShowStep();
			MessageBox.Show("Broken!");
		}
		public CSVLoader(List<IWizardItem> steps)
		{
			this.steps = steps;
			currentStep = 0;
			totalSteps = steps.Count;
		}
		public void Close()
		{
			this.Close();
		}
	}
		
}
