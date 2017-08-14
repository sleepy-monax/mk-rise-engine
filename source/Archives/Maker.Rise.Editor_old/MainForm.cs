using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maker.Rise.Editor
{
    public partial class MainForm : Form
    {
        public MainEditor Editor;
        public MainForm(MainEditor editor)
        {
            InitializeComponent();
            Editor = editor;
            textBoxPath.Text = Application.StartupPath + @"\Projects";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateProject(textBoxName.Name, labelFinalPath.Text);
        }

        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void textBoxName_Click(object sender, EventArgs e)
        {
            textBoxName.SelectAll();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            labelFinalPath.Text = textBoxPath.Text + "\\" + textBoxName.Text;
            buttonNewProject.Enabled = true;
        }

        public void CreateProject(string name, string path)
        {

            IOHelper.DirectoryCopy(@".\ProjectTemplate", path, true);
            Editor.LoadProject(path);
            this.Close();
        }

    }
}
