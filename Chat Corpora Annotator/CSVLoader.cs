using Viewer.CSV_Wizard;
using Viewer.Framework.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace Viewer
{
	public partial class CSVLoader : Form, ICSVView
	{ 
		//private readonly ApplicationContext _context;
		public CSVLoader()
		{
			InitializeComponent();
			currentStep = 0;
			this.PropertyChanged += CSVLoader_PropertyChanged;
		}

		private void CSVLoader_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			cmdNext.Enabled = true;
			//cmdNext_Click(this, EventArgs.Empty);
			this.Invalidate();
		}

		private int currentStep;
		private int totalSteps;
		private List<IWizardItem> steps = new List<IWizardItem>();
		public string[] AllFields { get; set; }
		public List<string> SelectedFields { get; set; }
		public string DateFieldKey { get; set; }
		public string SenderFieldKey { get; set; }
		public string TextFieldKey { get; set; }

		public List<IWizardItem> Steps { get { return steps; } }

		private bool _fileLoadState = false;
		public bool FileLoadState { get { return _fileLoadState; } set { _fileLoadState = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FileLoadState")); } }

		public event Action HeaderSelected;
		public event Action MetadataAdded;
		public event PropertyChangedEventHandler PropertyChanged;

		public void AddStep(IWizardItem step)
		{
			steps.Add(step);
			totalSteps = steps.Count;
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
			panelStep.Invalidate();
		}



		private void cmdNext_Click(object sender, EventArgs e)
		{
			if (currentStep != totalSteps)
		
				
			{
				switch (steps[currentStep].StepType)
				{
					case "Header":
						this.SelectedFields = steps[currentStep].GetValues();
						HeaderSelected();
						break;
					case "Metadata":
						this.DateFieldKey = steps[currentStep].GetValues()[0];
						this.SenderFieldKey = steps[currentStep].GetValues()[1];
						this.TextFieldKey = steps[currentStep].GetValues()[2];
						MetadataAdded();
						cmdNext.Enabled = false;
						break;

					

				}
				currentStep++;
				ShowStep();
			}
			else
			{
				Close();
			}

		}
		private void cmdPrev_Click(object sender, EventArgs e)
		{
			//currentStep--;
			//ShowStep();
			MessageBox.Show("Broken!");
		}

		public new void Close()
		{
			this.Close();
		}

		public new void Show()
		{
			ShowStep();
			panelStep.Invalidate();
			ShowDialog();
		}
	}
		
}
