using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsAppSimpleRPG
{
    public partial class MultiThreadEx : Form
    {
        static int[] p = new int[6];
        static int[] s = new int[6];

        public MultiThreadEx()
        {
            InitializeComponent();

            Thread thread1 = new Thread(() => UpdatePlayer(progressBar1, ref p[1], 1));
            Thread thread2 = new Thread(() => UpdatePlayer(progressBar2, ref p[2], 2));
            Thread thread3 = new Thread(() => UpdatePlayer(progressBar3, ref p[3], 3));
            Thread thread4 = new Thread(() => UpdatePlayer(progressBar4, ref p[4], 4));
            Thread thread5 = new Thread(() => UpdatePlayer(progressBar5, ref p[5], 5));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
        }

        void UpdatePlayer(ProgressBar progressBar, ref int progress, int playerNumber)
        {
            while (progress < 100)
            {
                Random random = new Random();
                int randomInt = random.Next(0, 15);
                int randomSleep = random.Next(100, 1000);
                s[playerNumber] += randomSleep;
                progress += randomInt;
                if (progress > 100) progress = 100;
                int nprogress = progress;

                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke(new Action(() =>
                    {
                        progressBar.Value = nprogress;

                        if (nprogress == 100)
                        {
                            textBox.Invoke(new Action(() => textBox.Text += $"{playerNumber} arrival time : {s[playerNumber]}ms\r\n"));
                        }
                    }));
                }

                // 스레드를 잠시 멈춤
                Thread.Sleep(randomSleep); 
            }
        }
    }
}
