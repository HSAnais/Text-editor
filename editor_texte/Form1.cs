using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace editor_texte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Text Files (*.txt)|*.txt";
            of.Title = "Fisiere Text";
            if (of.ShowDialog() == DialogResult.Cancel) return;
            richTextBox1.Text = "";
            richTextBox1.Visible = true;
            FileStream strm;
            try
            {
                strm = new FileStream(of.FileName, FileMode.Open, FileAccess.Read);
                StreamReader rdr = new StreamReader(strm);
                while (rdr.Peek() >= 0)
                {
                    string str = rdr.ReadLine();
                    richTextBox1.Text = richTextBox1.Text + " " + str;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening file", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dinamicHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore","http://msdn2.microsoft.com/en-us/default.aspx");
        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.Color = Color.IndianRed;
            fd.ShowApply = true;
            fd.Apply += new EventHandler(ApplyFont);
            if (fd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                this.richTextBox1.Font = fd.Font;
                this.richTextBox1.ForeColor = fd.Color;
            }
        }

        private void ApplyFont(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.Color = Color.DarkBlue;
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.richTextBox1.ForeColor = cd.Color;
        }
    }
}
