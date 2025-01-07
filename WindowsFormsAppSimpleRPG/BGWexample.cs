using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsAppSimpleRPG
{
    public partial class BGWexample : Form
    {
        public BGWexample()
        {
            
            InitializeComponent();
            
            this.worker = new BackgroundWorker();
            //BackgroundWorker의 ReportProgress() 메소드 활용 여부, 보통 true
            this.worker.WorkerReportsProgress = true;
            //CancelAsync()로 BackgroundWorker를 멈출 수 있게 할지, 보통 true
            this.worker.WorkerSupportsCancellation = true;

            //BackgroundWorker가 UI thread와 별개로 수행할 메소드
            this.worker.DoWork += new DoWorkEventHandler(Worker_Dowork);
            // ReportProgress() 메소드가 수행될 때 실행될 메소드
            this.worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            // ReportProgress()가 100으로 호출되면 마지막에 한 번 실행되는 메소드
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_Complete);

            
        }
        void Worker_Dowork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(30);
                this.worker.ReportProgress(i);
            }
        }
        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        void Worker_Complete(object sender, EventArgs e)
        {
            MessageBox.Show("100% Complete!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //while (true)
            //{
            //    progressBar1.Value += 1;
            //    textBox1.Text=progressBar1.Value.ToString();
            //    for(int i = 0; i < 10; i++)
            //    {
            //        progressBar1.Value++;
            //        progressBar1.Value--;
            //    }
            //    if (progressBar1.Value >= 100) break;

            //}

            this.worker.RunWorkerAsync();
        }
    }
}
