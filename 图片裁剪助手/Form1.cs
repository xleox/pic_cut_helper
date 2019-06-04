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

namespace 图片裁剪助手
{
    public partial class Form1 : Form
    {
        string[] picPaths= new String[30000];
        long picNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                textBox1.Text = foldPath;
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                textBox2.Text = foldPath;
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FindFile(DirectoryInfo di)
        {
            FileInfo[] fis = di.GetFiles();
            for (int i = 0; i < fis.Length; i++)
            {
                //Console.WriteLine("文件：" + fis[i].FullName);
                string pciName = fis[i].FullName;
          
                if (pciName.IndexOf(".jpg") > 0 || pciName.IndexOf(".png") > 0 || pciName.IndexOf(".jpeg") > 0)
                    picPaths[picNum++] = fis[i].FullName;
            }
            
            DirectoryInfo[] dis = di.GetDirectories();
            for (int j = 0; j < dis.Length; j++)
            {
                //Console.WriteLine("目录：" + dis[j].FullName);
                FindFile(dis[j]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(textBox1.Text);
            picNum = 0;
            FindFile(di);
            
            for(int i=0;i<picNum;i++)
            {
                Console.WriteLine(picPaths[i]);
            }
        }
    }
}
