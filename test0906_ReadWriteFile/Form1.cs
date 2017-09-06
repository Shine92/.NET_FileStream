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

namespace test0906_ReadWriteFile {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Directory.CreateDirectory(@"c:\test123\test456\test789");
        }

        private void button2_Click(object sender, EventArgs e) {
            if (Directory.Exists(@"c:\test123\test456\test789")) {
                Directory.Delete(@"c:\test123\test456\test789");
            }else {
                MessageBox.Show("指定資料夾已經刪除");
            }        
        }

        private void button3_Click(object sender, EventArgs e) {
           //string[] Filelist = Directory.GetFiles(@"D:\simon"); //抓simon資料夾全部資料
           string[] Filelist = Directory.GetFiles(@"D:\simon","*.txt"); //抓simon資料夾txt
            foreach (string Files in Filelist) {
                textBox1.Text += Files + System.Environment.NewLine;
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            string s = textBox2.Text; //寫入檔案是textbox的內容
            Directory.CreateDirectory(@"D:\simon\labStream"); //新增資料夾
            FileStream fs = new FileStream(@"D:\simon\labStream\labStream.txt", FileMode.Create); //新增檔案
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            if (Directory.Exists(@"D:\simon\labStream")) {
                fs.Write(buffer,0,buffer.Length);
                fs.WriteByte(239); fs.WriteByte(187); fs.WriteByte(191); //BOM 讓文字編輯器到這是UTF-8格式
            }
            fs.Close();
        }

        private void button5_Click(object sender, EventArgs e) {

        }
    }
}
