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
        TextBox[,] cells=new TextBox[9,9];
        
        String[,] b = new String[9, 9];
        public Form1()
        {
            InitializeComponent(); 
            cells = new TextBox[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j] = new TextBox();

                    cells[i, j].Multiline = true;
                    cells[i, j].TextAlign = HorizontalAlignment.Center;
                    cells[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
                    cells[i, j].Font = new Font("Tahoma", 15);
                    tableLayoutPanel1.Controls.Add(cells[i, j], i, j);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            OpenFileDialog x = new OpenFileDialog();
            if (x.ShowDialog() == DialogResult.OK)
            {
                reset();
                string fiie_path = x.FileName;
                StreamReader my_file_reder = new StreamReader(fiie_path);
                string big_text = my_file_reder.ReadToEnd();
               // MessageBox.Show(big_text);
                char[] my_sep = { ' ',  '\r' };
                big_text = big_text.Replace("\n","");
                string[] numbers = big_text.Split(my_sep);

                int index = 0;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (numbers[index] != "0")
                        {
                            cells[j, i].ReadOnly = true;
                            cells[j, i].Text = numbers[index];
                            cells[j, i].BackColor = Color.LightPink;





                        }
                        index++;   
                    }
                }
            }
        }
        private void cells_TextChanged(object sender, EventArgs e)
        { }
        private void reset()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                   
                    {
                        cells[j, i].ReadOnly = false;
                        cells[j, i].Text = "";
                        cells[i, j].TextChanged += new System.EventHandler(this.cells_TextChanged);
                        

                    }
                    
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to get out of the gamet?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Boolean x;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (b[i, j] == "0" && cells[i, j].Text != "")
                    {
                        x = true;

                        for (int k = 0; k < 9; k++)
                        {
                            if (cells[i, k].Text == cells[i, j].Text && k != j)
                            {
                                x = false;
                            }
                        }

                  
                        for (int k = 0; k < 9; k++)
                        {
                            if (cells[k, j].Text == cells[i, j].Text && k != i)
                            {
                                x = false;
                            }
                        }

                        for (int k = 0; k < 3; k++)
                        {
                            for (int d = 0; d < 3; d++)
                            {
                                if (i >= 3 * k && i <= 3 * k + 2 && j >= 3 * d && j <= 3 * d + 2)
                                {
                                    for (int z = 3 * k; z < 3 * k + 2;z++)
                                    {
                                        for (int f = 3 *d; f < 3 * d + 2; f++)
                                        {
                                            if (cells[z, f].Text == cells[i, j].Text && (z != i || m != j))
                                            {
                                                x = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (x == false)
                        {
                            cells[i, j].BackColor = Color.Yellow;
                        }
                        else
                        {
                            cells[i, j].BackColor = Color.Purple;
                        }
                    }
                }
            }
        }
    }

       
    }


