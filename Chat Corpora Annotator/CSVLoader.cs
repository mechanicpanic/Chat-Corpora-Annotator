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
			//cmdNext.Enabled = true;
			//cmdNext_Click(this, EventArgs.Empty);
			currentStep++;
			ShowStep();
			cmdNext.Visible = true;
			cmdNext.Text = "Finish";
			this.Invalidate();
		}

		private int currentStep;
		private int totalSteps;
		
		public string[] AllFields { get; set; }
		public List<string> SelectedFields { get; set; }
		public string DateFieldKey { get; set; }
		public string SenderFieldKey { get; set; }
		public string TextFieldKey { get; set; }

		private List<IWizardItem> _steps = new List<IWizardItem>();
		public List<IWizardItem> Steps { get { return _steps; } } 

		private bool _fileLoadState = false;
		public bool FileLoadState { get { return _fileLoadState; } set { _fileLoadState = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FileLoadState")); } }

		public event EventHandler HeaderSelected;
		public event EventHandler MetadataAdded;
		public event PropertyChangedEventHandler PropertyChanged;

		public void AddStep(IWizardItem step)
		{
			_steps.Add(step);
			totalSteps = _steps.Count;
		}
		private void ShowStep()
		{
			// Update buttons.
			
			if (currentStep == totalSteps)
				cmdNext.Text = "Finish";
			else
				cmdNext.Text = "Next >";


			stepLabel.Text = Steps[currentStep].HeaderTitle;
			Text = "Step " + (currentStep + 1).ToString() + " of " + totalSteps.ToString();

			panelStep.Controls.Clear();
			UserControl ctrl = (UserControl)Steps[currentStep];
			panelStep.Controls.Add(ctrl);
			panelStep.Invalidate();
		}



		private void cmdNext_Click(object sender, EventArgs e)
		{
			if (currentStep != totalSteps)
		
				
			{
				switch (_steps[currentStep].StepType)
				{
					case "Header":
						this.SelectedFields = _steps[currentStep].GetValues();
						HeaderSelected?.Invoke(this, EventArgs.Empty); 
						break;
					case "Metadata":
						this.DateFieldKey = _steps[currentStep].GetValues()[0];
						this.SenderFieldKey = _steps[currentStep].GetValues()[1];
						this.TextFieldKey = _steps[currentStep].GetValues()[2];
						//currentStep++;
						MetadataAdded?.Invoke(this,EventArgs.Empty);
						cmdNext.Visible = false;
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
		public new void Close()
		{
			
			this.Close();
		}

		public new void Show()
		{
			ShowStep();
			panelStep.Invalidate();
			this.ShowDialog();
		}
	}
		
}
