namespace Maker.Rise.Inspector
{
    partial class InspectorUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.FogGradiant = new System.Windows.Forms.TrackBar();
            this.FogDistance = new System.Windows.Forms.TrackBar();
            this.FogDensity = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SceneBrightness = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FogGradiant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FogDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FogDensity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SceneBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // FogGradiant
            // 
            this.FogGradiant.AutoSize = false;
            this.FogGradiant.Dock = System.Windows.Forms.DockStyle.Top;
            this.FogGradiant.Location = new System.Drawing.Point(3, 148);
            this.FogGradiant.Maximum = 10000;
            this.FogGradiant.Name = "FogGradiant";
            this.FogGradiant.Size = new System.Drawing.Size(270, 30);
            this.FogGradiant.TabIndex = 0;
            this.FogGradiant.Scroll += new System.EventHandler(this.FogGradiant_Scroll);
            // 
            // FogDistance
            // 
            this.FogDistance.AutoSize = false;
            this.FogDistance.Dock = System.Windows.Forms.DockStyle.Top;
            this.FogDistance.Location = new System.Drawing.Point(3, 40);
            this.FogDistance.Maximum = 10000;
            this.FogDistance.Name = "FogDistance";
            this.FogDistance.Size = new System.Drawing.Size(270, 30);
            this.FogDistance.TabIndex = 1;
            this.FogDistance.Scroll += new System.EventHandler(this.FogDistance_Scroll);
            // 
            // FogDensity
            // 
            this.FogDensity.AutoSize = false;
            this.FogDensity.Dock = System.Windows.Forms.DockStyle.Top;
            this.FogDensity.Location = new System.Drawing.Point(3, 94);
            this.FogDensity.Maximum = 10000;
            this.FogDensity.Name = "FogDensity";
            this.FogDensity.Size = new System.Drawing.Size(270, 30);
            this.FogDensity.TabIndex = 2;
            this.FogDensity.Scroll += new System.EventHandler(this.FogDensity_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.FogGradiant);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FogDensity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FogDistance);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 181);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fog";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(3, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Density";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(3, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gradiant";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Distance";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.SceneBrightness);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(4, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 73);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scene";
            // 
            // SceneBrightness
            // 
            this.SceneBrightness.AutoSize = false;
            this.SceneBrightness.Dock = System.Windows.Forms.DockStyle.Top;
            this.SceneBrightness.Location = new System.Drawing.Point(3, 40);
            this.SceneBrightness.Maximum = 100;
            this.SceneBrightness.Name = "SceneBrightness";
            this.SceneBrightness.Size = new System.Drawing.Size(270, 30);
            this.SceneBrightness.TabIndex = 6;
            this.SceneBrightness.Scroll += new System.EventHandler(this.SceneBrightness_Scroll);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Brightness";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InspectorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 556);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "InspectorUI";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Rise - Scene Inspector";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.FogGradiant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FogDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FogDensity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SceneBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar FogGradiant;
        private System.Windows.Forms.TrackBar FogDistance;
        private System.Windows.Forms.TrackBar FogDensity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar SceneBrightness;
        private System.Windows.Forms.Label label4;
    }
}

