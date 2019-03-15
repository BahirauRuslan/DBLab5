using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBLab5
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            ClearButton_Click(this, null);
            IEnumerable<string> subjects = DBSubjects.GetInstance().GetAllSubjects();
            FillListBox(subjects);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            mainListBox.Items.Clear();
            AddButton.Enabled = true;
        }

        private void FillListBox(IEnumerable<string> list)
        {
            foreach (string item in list)
            {
                mainListBox.Items.Add(item);
            }
        }

        private void MagicButton_Click(object sender, EventArgs e)
        {
            ClearButton_Click(this, null);
            IEnumerable<string> subjects = DSTableCreator.GetInstance().GetSubjects();
            FillListBox(subjects);
            AddButton.Enabled = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (subjectTextBox.Text != null && subjectTextBox.Text.Length > 1)
            {
                DBSubjects.GetInstance().AddSubject(subjectTextBox.Text);
                ClearButton_Click(this, null);
                ReadButton_Click(this, null);
            }
            subjectTextBox.Text = "";
        }
    }
}
