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
            int list;
            int[] row;
            int[] colom;
            int[] sq;
           
            for (int i = 0; i < 9; i++)
            {
                row = new int[9];
                colom = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    if (cells[i, j].Text != "" && cells[i, j].Text != "")
                    {
                        int cellrow = Convert.ToInt16(cells[j, i].Text);
                        int cellcolom = Convert.ToInt16(cells[i, j].Text);
                        if (0 < cellrow && cellrow < 10 && !row.Contains(cellrow) &&
                             0 < cellcolom && cellcolom < 10 && !colom.Contains(cellcolom))
                        {
                            row[j] = cellrow;
                            colom[i] = cellcolom;
                            continue;
                        }
                    }
                    MessageBox.Show("Try harder");
                    return;
                }
            }
            for (int k = 1, b1 = 0, d1 = 3, b2 = 0, d2 = 3; k<= 9; k++, b2 += 3, d2 += 3)

            {

                if ((k - 1) % 3 == 0)

                {
                    b2 = 0;
                    d2 = 3; 
                }
                sq = new int[9];
                list = 0;
                
                for (int i = b1; i < d1; i++)

                {
                    for (int j = b2; j < d2; j++)

                    {
                        int cell = Convert.ToInt16(cells[j, i].Text);
                        
                        if (!sq.Contains(cell))

                        {
                            sq[list++] = cell;
                       
                            continue;
                        }
                        
                        MessageBox.Show("Try More...");

                        return;

                    }

                }
                
                if (k % 3 == 0)

                {
                    b1 += 3;

                    d1 += 3;
                }
            }
            
            MessageBox.Show("thats right");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}

