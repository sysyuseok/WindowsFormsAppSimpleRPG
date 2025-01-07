using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsAppSimpleRPG
{
    public partial class MyOpenFileDialog : Form
    {
        IDictionary<string, string> IdPw = new Dictionary<string, string>();
        IDictionary<string, string> IdNum = new Dictionary<string, string>();
        public MyOpenFileDialog()
        {
            InitializeComponent();            
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            try
            {
                int sss = 200;


                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // 필터 설정
                    openFileDialog.Filter = string.Join("|", new List<string>
                    {
                        "ALL FILES(*.*)|*.*", "TXT(*.txt)|*.txt",
                        "Bitmap(*.bmp, *.dib)|*.bmp;*.dib",
                        "JPEG(*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif",
                        "TIFF(*.tif, *.tiff)|*.tif;*.tiff",
                        "GIF(*.gif)|*.gif",
                        "PNG(*.png)|*.png"
                    });

                    openFileDialog.AddExtension = false;
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.CheckPathExists = true;
                    openFileDialog.Multiselect = false;
                    openFileDialog.ShowHelp = true;
                    openFileDialog.ShowReadOnly = false;
                    openFileDialog.ReadOnlyChecked = false;
                    openFileDialog.SupportMultiDottedExtensions = true;
                    openFileDialog.Title = "Select a file...";
                    openFileDialog.ValidateNames = true;

                    // 초기 디렉터리 설정
                    string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    openFileDialog.InitialDirectory = Path.Combine(userFolder, "Downloads", "WindowsFormsAppSimpleRPG");

                    // 파일 선택
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog.FileName;
                        //MessageBox.Show($"Selected File: {selectedFilePath}", "File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // 파일 읽기
                string accountFilePath = "accounts.txt";
                if (File.Exists(accountFilePath))
                {
                    using (StreamReader reader = new StreamReader(accountFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // 각 줄을 ','로 나누기
                            string[] parts = line.Split(',');

                            // 결과 등록
                            IdPw[parts[0]] = parts.Length > 1 ? parts[1] : "NULL";
                            IdNum[parts[0]] = parts.Length > 2 ? parts[2] : "NULL";

                        }
                    }
                }
                else
                {
                    MessageBox.Show("accounts.txt 파일을 찾을 수 없습니다.", "파일 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show($"오류가 발생했습니다:");
                MessageBox.Show($"오류가 발생했습니다: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string inputId = textBox_id.Text;
            string inputPw = textBox_pw.Text;
            if (IdPw[inputId] == inputPw)
            {
                MessageBox.Show($"ID : {inputId} \r\nPhone number : {IdNum[inputId]}");
            }
            else
            {
                MessageBox.Show("Wrong Password!!\r\n");
            }
        }

      
    }
}
