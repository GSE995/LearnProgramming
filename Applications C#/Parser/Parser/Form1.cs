using Parser.Core;
using Parser.Core.TProger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                    new TProgerParse()
                );
            parser.OnCompleted += Parse_OnCompleted;
            parser.OnNeWData += Parse_OneNewDate;
        }

        private void Parse_OneNewDate(object arg1, string[] arg2)
        {
            listTitles.Items.AddRange(arg2);
        }

        private void Parse_OnCompleted(object obj)
        {
            MessageBox.Show("All worker");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            parser.Settings = new TProgerSettings((int)numericStart.Value, (int)numericEnd.Value, inputSection.Text);
            parser.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listTitles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
