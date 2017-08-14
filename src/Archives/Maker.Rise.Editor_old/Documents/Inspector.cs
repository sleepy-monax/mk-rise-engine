using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Maker.Rise.Editor.Documents
{
    public partial class Inspector : DockContent
    {
        private MainEditor mainEditor;
        
        public Inspector(MainEditor mainEditor)
        {
            InitializeComponent();
            this.mainEditor = mainEditor;
        }

        private void Inspector_Load(object sender, EventArgs e)
        {
            
        }
    }
}
