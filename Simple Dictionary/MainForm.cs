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
using System.Threading;
using Microsoft.Win32;

namespace Simple_Dictionary
{

    struct CurrentDic
    {
        public string CurrentDicName;
        public SDictionary CurrentDicRef;
    }

    public partial class MainForm : Form
    {
        CurrentDic Dic;
        string InputedWord;
        int NowIndex;

        public MainForm()
        {
            InitializeComponent();

            //Add the dictionary list to the dropdown list
            string path = Properties.Settings.Default.BasePath;
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var fi in dir.EnumerateDirectories())
            {
                this.DictionarySelecter.Items.Add(fi.Name);
            }
        }

        private void WordInput_Click(object sender, EventArgs e)
        {
            this.WordInput.Text = "";
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        { }

        private void DictionarySelecter_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InputPlaceHolder.Visible = false;
            this.WordInput.Visible = true;
            this.WordInput.ReadOnly = true;
            this.WordInput.Text = "正在载入词典...";
            this.WordsListBox.Items.Clear();
            Dic.CurrentDicName = this.DictionarySelecter.SelectedItem.ToString();
            Dic.CurrentDicRef = new SDictionary(Dic.CurrentDicName);
            this.DictionarySelecter.BeginUpdate();
            foreach (var fi in Dic.CurrentDicRef.WordList)
            {
                this.WordsListBox.Items.Add(fi);
            }
            this.DictionarySelecter.EndUpdate();
            this.WordInput.Text = "请输入想要查询的词汇";
            this.WordInput.ReadOnly = false;
        }

        private void WordInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.WordsRefreshWorker.CancelAsync();
            }
            catch { }
            InputedWord = this.WordInput.Text;
            if (this.WordsRefreshWorker.IsBusy != true)
            {
                this.WordsRefreshWorker.RunWorkerAsync();
            }

        }

        private void WordsRefreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InputedWord != string.Empty)
            {
                NowIndex = WordsListBox.FindString(InputedWord);
            }
        }

        private void WordsRefreshWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (NowIndex != -1)
            {
                this.WordsListBox.SetSelected(NowIndex, true);
            }
            else
            {
                this.WordsListBox.SetSelected(0, false);
            }
        }

        private void OpenExplain()
        {
            string ExplainText = Dic.CurrentDicRef.GetExplain(this.WordsListBox.SelectedItem.ToString());
            this.ExplainBox.Text = ExplainText;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenExplain();
            }
            catch 
            {
                MessageBox.Show("词典中没有所查询的词汇。");
            }
        }

        private void CustomEncodeInput_Click(object sender, EventArgs e)
        {
            this.CustomEncodeInput.Text = "";
        }

        private void WordsListBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.OpenExplain();
            } catch { }
        }

        private void WordInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.OpenExplain();
                }
                catch { 
                    this.ExplainBox.Text = "发生未知错误，无法打开词典解释文件。";
                }
            }
        }

        private void CustomEncodeInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Properties.Settings.Default.DefaultEncode = CustomEncodeInput.Text;
            }
        }

        private void ResetEncode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem FromObject = sender as ToolStripMenuItem;
            Properties.Settings.Default.DefaultEncode = FromObject.AccessibleName.Replace("Setenc_", "");
        }

        private void aSC动漫学园ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            string s = key.GetValue("").ToString();
            System.Diagnostics.Process.Start(s.Substring(0, s.Length - 5), @"http://bbs.ascdm.net/");
        }

        private void OpenSettingForm_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.Show();
        }

        private void ExitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
