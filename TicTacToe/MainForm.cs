using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainForm : Form
    {
        Button[,] buttons;
        int size = 3;

        public MainForm()
        {
            InitializeComponent();
            //resetGame();
            loadButtons();
        }

        private void loadButtons()
        {
            buttons = new Button[size, size];

            int maxSize = Math.Min(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);

            int buttonSize = maxSize / size;

            Console.WriteLine(size);
            for ( int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Height = buttonSize;
                    buttons[i, j].Width = buttonSize;
                    buttons[i, j].Location = new Point(10 + i *buttonSize, 40 + j * buttonSize);
                    buttons[i, j].Text = "?";
                    buttons[i, j].Tag = "cell";
                    buttons[i, j].Font = new Font("Georgia", 16);

                   buttons[i, j].Click += new EventHandler(player_click);

                    Controls.Add(buttons[i, j]);
                }
            }
        }

        private void removeButtons()
        {
            for (int i = 0; i < this.Controls.Count; )
            {
                if (this.Controls[i].Tag != null)
                    this.Controls.Remove(this.Controls[i]);
                else
                    i++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void player_click(object sender, EventArgs e)
        {
            Console.WriteLine("Player click");
            Button button = (Button)sender;
            button.BackColor = Color.LawnGreen;
            button.Text = "X";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(textBox1.Text, out size);
            Console.WriteLine(size);
            removeButtons();
            loadButtons();
        }
    }
}
