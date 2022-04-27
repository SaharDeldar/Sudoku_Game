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
namespace sodoco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox t = new TextBox();
                    tableLayoutPanel1.Controls.Add(t, i, j);
                    t.Multiline = true;
                    t.TextAlign = HorizontalAlignment.Center;
                    t.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
                    t.Font=new Font("Tahoma", 25);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            if(x.ShowDialog()==DialogResult.OK)
            {
                string fiie_path = x.FileName;
                
                StreamReader my_file_reder = new StreamReader(fiie_path);
               string big_text = my_file_reder.ReadToEnd();
                MessageBox.Show(big_text);
                char[] my_sep = { ' ', '\n' };
                string[] numbers = big_text.Split(my_sep);
            }
        }
    }
}
