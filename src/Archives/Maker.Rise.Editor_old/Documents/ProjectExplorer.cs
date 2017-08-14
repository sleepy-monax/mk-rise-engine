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
using WeifenLuo.WinFormsUI.Docking;

namespace Maker.Rise.Editor.Documents
{
    public partial class ProjectExplorer : DockContent
    {
        Dictionary<TreeNode, string> pathDic = new Dictionary<TreeNode, string>();

        MainEditor Editor;
        public ProjectExplorer(MainEditor editor)
        {
            Editor = editor;
            InitializeComponent();
        }

        private void ProjectExplorer_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadFolder(string projectName, string path)
        {
            var node = new TreeNode(projectName);
            treeView1.Nodes.Add(node);
            LoadFolder(node, path);
            treeView1.ExpandAll();
        }

        public void LoadFolder(TreeNode rootNode, string path)
        {
            foreach (string file in Directory.GetFiles(path))
            {
                var node = new TreeNode(file.Split('\\').Last());
                rootNode.Nodes.Add(node);
                pathDic.Add(node, file);
            }

            foreach (string dir in Directory.GetDirectories(path))
            {
                var node = new TreeNode(dir.Split('\\').Last());
                node.ForeColor = Color.DarkBlue;
                rootNode.Nodes.Add(node);
                pathDic.Add(node, dir);

                LoadFolder(node, dir);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nodeFilePath = pathDic[e.Node];
            if (File.Exists(nodeFilePath))
            {
                new TextEditor(nodeFilePath, FastColoredTextBoxNS.Language.Lua).Show(Editor.DockHost, DockState.Document);
            }
        }
    }
}
