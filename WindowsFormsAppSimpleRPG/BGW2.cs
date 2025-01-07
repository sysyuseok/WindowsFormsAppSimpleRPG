using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSimpleRPG
{
    public partial class BGW2 : Form
    {
        string path, type;
        

        public BGW2()
        {
            InitializeComponent();
            this.worker = new BackgroundWorker();
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;

            this.worker.DoWork += new DoWorkEventHandler(Worker_Dowork);
            this.worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_Complete);
        }

        void Worker_Dowork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(type))
            {
                e.Result = "경로 또는 확장자가 비어 있습니다.";
                return;
            }

            try
            {
                string[] files = Directory.GetFiles(path, "*" + type, SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    if (bgWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    bgWorker.ReportProgress(i * 100 / files.Length, files[i]);
                }
                e.Result = "완료";
            }
            catch (Exception ex)
            {
                e.Result = "오류: " + ex.Message;
            }
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 파일 경로에서 공통 경로를 제거
            string filePath = e.UserState.ToString();
            string relativePath = GetRelativePath(path, filePath);

            listBox1.Items.Add(relativePath);
        }

        void Worker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("작업이 취소되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Error != null)
            {
                MessageBox.Show("오류 발생: " + e.Error.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(e.Result.ToString(), "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.path = textBox2.Text;
            this.type = textBox1.Text;

            if (Directory.Exists(path))
            {
                worker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("경로가 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }
        }

        // 상대 경로 계산 함수
        private string GetRelativePath(string basePath, string fullPath)
        {
            Uri baseUri = new Uri(basePath.EndsWith("\\") ? basePath : basePath + "\\");
            Uri fullUri = new Uri(fullPath);
            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fullUri).ToString().Replace('/', '\\'));
        }
    }
}
