﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
