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
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Button[,] buttons;
        Random rand = new Random();
        int size = 3;

        public Form1()
        {
            InitializeComponent();
            //resetGame();
            loadButtons();
        }

        private void loadButtons()
        {
            buttons = new Button[size, size];

            int maxSize = Math.Max(this.Size.Width, this.Size.Height);

            int buttonSize = (maxSize - 30) / size;

            for ( int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Height = buttonSize;
                    buttons[i, j].Width = buttonSize;
                    buttons[i, j].Location = new Point(10 + i *buttonSize, 40 + j * buttonSize);
                    buttons[i, j].Text = $"{i} {j}";
                    buttons[i, j].Tag = "cell";
                    //dynamicButton.Font = new Font("Georgia", 16);

                    //dynamicButton.Click += new EventHandler(DynamicButton_Click);

                    Controls.Add(buttons[i, j]);
                }
            }
        }

        private void removeButtons()
        {
            foreach(Control control in this.Controls)
            {
                if (control is Button)
                {
                    if (control.Tag != null)
                    {
                        if (control.Tag.Equals("cell"))
                        {
                            Controls.Remove(control);
                        }
                    }
                }
            }
        }

        private void resetGame()
        {
            foreach (Control element in this.Controls)
            {
                if (element.Tag.Equals("play"))
                {
                    element.Enabled = true;
                    element.Text = "?";
                    element.BackColor = default(Color);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void player_click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            //buttons.Remove(button);
            check(Player.X);
            check(Player.O);
        }

        private void check(Player player) 
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(textBox1.Text, out int size);
            removeButtons();
            loadButtons();
        }
    }
}
