using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.CodeDom;


namespace WindowsFormsAppSimpleRPG
{
    public partial class Exception : Form
    {
        public Exception()
        {
            string[] arr;
            InitializeComponent();
            CopyContentWithOut(out arr);
        }
        void CopyContentWithOut(out string[] arr)
        {
            string content;
            try
            {
                content = File.ReadAllText(@"C:\\Users\\USER\\Downloads\\WindowsFormsAppSimpleRPG\\WindowsFormsAppSimpleRPG\\file.txt");
                MessageBox.Show(content);
            }
            catch
            {
                MessageBox.Show("yuseok");
                //MessageBox.Show("!!WRONG!!");

            }
            finally
            {
                
                int cnt = new int();
                cnt = 0;
                content = File.ReadAllText(@"C:\\Users\\USER\\Downloads\\WindowsFormsAppSimpleRPG\\WindowsFormsAppSimpleRPG\\file.txt");
                for (int i = 0; i < content.Length; i++)
                {
                    if (content[i] == '\n')
                    {
                        cnt++;

                    }
                }
                arr = new string[cnt];


            }
            
        }
    }
}
