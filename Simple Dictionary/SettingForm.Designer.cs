﻿namespace Simple_Dictionary
{
    partial class SettingForm
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
            this.SaveSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DictionaryPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveSetting
            // 
            this.SaveSetting.Location = new System.Drawing.Point(292, 55);
            this.SaveSetting.Name = "SaveSetting";
            this.SaveSetting.Size = new System.Drawing.Size(75, 23);
            this.SaveSetting.TabIndex = 0;
            this.SaveSetting.Text = "应用";
            this.SaveSetting.UseVisualStyleBackColor = true;
            this.SaveSetting.Click += new System.EventHandler(this.SaveSetting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "默认词典路径：";
            // 
            // DictionaryPath
            // 
            this.DictionaryPath.Location = new System.Drawing.Point(15, 28);
            this.DictionaryPath.Name = "DictionaryPath";
            this.DictionaryPath.Size = new System.Drawing.Size(352, 21);
            this.DictionaryPath.TabIndex = 2;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 91);
            this.Controls.Add(this.DictionaryPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveSetting);
            this.Name = "SettingForm";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DictionaryPath;
    }
}