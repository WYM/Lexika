using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Dictionary
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.DictionaryPath.Text = Properties.Settings.Default.BasePath;
        }

        private void SaveSetting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BasePath = this.DictionaryPath.Text;
            MessageBox.Show("设置已保存。");
        }
    }
}
