﻿using Viewer.CSV_Wizard;
using Viewer.Framework.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace Viewer
{
	public partial class CSVLoader : Form, ICSVView
	{ 
		
		public CSVLoader()
		{
			InitializeComponent();
			currentStep = 0;
			//this.PropertyChanged += CSVLoader_PropertyChanged;
			
		}

		//private void CSVLoader_PropertyChanged(object sender, PropertyChangedEventArgs e)
		//{
		//	//currentStep++;
		//	ShowStep();
		//	cmdNext.Visible = true;
		//	//cmdNext.Text = "Finish";
		//	this.Invalidate();
		//}

		private int currentStep;
		private int totalSteps;
		
		public string[] AllFields { get; set; }
		public List<string> SelectedFields { get; set; }
		public string DateFieldKey { get; set; }
		public string SenderFieldKey { get; set; }
		public string TextFieldKey { get; set; }

		private List<IWizardItem> _steps = new List<IWizardItem>();
		public List<IWizardItem> Steps { get { return _steps; } }


		public void CorpusIndexed()
		{
			cmdNext_Click(this, EventArgs.Empty);
		}
		public event EventHandler HeaderSelected;
		public event EventHandler MetadataAdded;
		public event EventHandler ReadyToShow;

		public void AddStep(IWizardItem step)
		{
			
			_steps.Add(step);
			
			totalSteps = _steps.Count;
		}
		private void ShowStep()
		{
			
			
			if (currentStep == totalSteps-1)
				cmdNext.Text = "Finish";
			else
				cmdNext.Text = "Next >";


			stepLabel.Text = Steps[currentStep].HeaderTitle;
			Text = "Step " + (currentStep + 1).ToString() + " of " + totalSteps.ToString();

			panelStep.Controls.Clear();
			UserControl ctrl = (UserControl)Steps[currentStep];
			panelStep.Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;
			panelStep.Invalidate();
		}



		private void cmdNext_Click(object sender, EventArgs e)
		{
			switch (_steps[currentStep].StepType)
			{
				case "Header":
					this.SelectedFields = _steps[currentStep].GetValues();
					HeaderSelected?.Invoke(this, EventArgs.Empty);
					currentStep++;
					ShowStep();
					break;
				case "Metadata":
					
					
					this.DateFieldKey = _steps[currentStep].GetValues()[0];
					this.SenderFieldKey = _steps[currentStep].GetValues()[1];
					this.TextFieldKey = _steps[currentStep].GetValues()[2];

					cmdNext.Visible = false;
					currentStep++;
					ShowStep();
					MetadataAdded?.Invoke(this, EventArgs.Empty);
					break;
				case "Loading":
					currentStep++;
					cmdNext.Visible = true;
					ShowStep();
					break;
				case "DataLoaded":
					ReadyToShow?.Invoke(this, EventArgs.Empty);
					CloseView();
					break;
			}


		}
		public void CloseView()
		{
			_steps.Clear();
			this.Close();
		}

		public new void ShowView()
		{
			ShowStep();
			panelStep.Invalidate();
			this.ShowDialog();
		}
	}
		
}