﻿namespace Unity
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGO = new System.Windows.Forms.Button();
            this.btnGoHierarchical = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(36, 52);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(387, 23);
            this.btnGO.TabIndex = 0;
            this.btnGO.Text = "ContainerControlledLifetimeManager";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnGoHierarchical
            // 
            this.btnGoHierarchical.Location = new System.Drawing.Point(36, 114);
            this.btnGoHierarchical.Name = "btnGoHierarchical";
            this.btnGoHierarchical.Size = new System.Drawing.Size(387, 23);
            this.btnGoHierarchical.TabIndex = 1;
            this.btnGoHierarchical.Text = "HierarchicalLifetimeManager";
            this.btnGoHierarchical.UseVisualStyleBackColor = true;
            this.btnGoHierarchical.Click += new System.EventHandler(this.btnGoHierarchical_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 450);
            this.Controls.Add(this.btnGoHierarchical);
            this.Controls.Add(this.btnGO);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnGoHierarchical;
    }
}

