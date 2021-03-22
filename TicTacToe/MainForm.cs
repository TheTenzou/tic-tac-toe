using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Game;
using TicTacToe.Game.Field;
using TicTacToe.Game.Players;
using TicTacToe.Game.Players;


namespace TicTacToe
{
    public partial class MainForm : Form
    {
        Button[,] buttons;
        int size = 3;
        
        GameField field;
        IPlayer player; 

        public MainForm()
        {
            InitializeComponent();
            loadButtons();
        }

        private void loadButtons()
        {
            field = new GameField(size);
            if (size <= 3)
            {
                player = new SmartBot(Player.BOT, field);
            }
            else
            {
                player = new Bot(Player.BOT, field);
            }

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
                    buttons[i, j].Tag = new CellCoordinats(i, j);
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

        private void player_click(object sender, EventArgs e)
        {
            Console.WriteLine("Player click");
            Button button = (Button)sender;
            button.BackColor = Color.LawnGreen;
            button.Text = "X";

            CellCoordinats coordiants = (CellCoordinats)button.Tag;

            field.makeMove(new Move(Player.PLAYER, coordiants));

            Player winer = field.whoWin();
            if (winer == Player.PLAYER)
            {
                MessageBox.Show("You won.");
            }
            else if (winer == Player.BOT)
            {
                MessageBox.Show("Bot won.");
            } 
            else if (!field.isMovesLeft())
            {
                MessageBox.Show("Draw.");
            }
            else
            {

                Move botMove = player.getMove();
                field.makeMove(botMove);

                foreach (Control control in this.Controls)
                {
                    if (control.Tag != null)
                    {

                        CellCoordinats cell = (CellCoordinats)control.Tag;
                        if (cell.Equals(botMove.coordinats))
                        {
                            Button botButton = (Button)control;
                            botButton.BackColor = Color.Magenta;
                            botButton.Text = "o";
                        }
                    }
                }

                winer = field.whoWin();
                if (winer == Player.PLAYER)
                {
                    MessageBox.Show("You won.");
                }
                else if (winer == Player.BOT)
                {
                    MessageBox.Show("Bot won.");
                }
                else if (!field.isMovesLeft())
                {
                    MessageBox.Show("Draw.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(textBox1.Text, out int size);
            if (size > 0)
            {
                this.size = size;
            }
            Console.WriteLine(size);
            removeButtons();
            loadButtons();

        }
    }
}
