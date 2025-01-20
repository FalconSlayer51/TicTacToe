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
        bool turns = true ;//true=x;fasle=y;
        int turn_count = 0;
        static String Player1,Player2;
        bool against_computer = false;
        public Form1()
        {
            InitializeComponent();
        }

        public static void setPlayernames(String name1,String name2)
        {
            Player1 = name1;
            Player2 = name2;        
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is done by K.Ramesh", "We the Invincible");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please type your names", "you cant play!");
                return ;
            }
            if (textBox1.Text.ToUpper() == "PLAYER1" || textBox2.Text == "PLAYER2")
            {
                MessageBox.Show("you cant play with out specifying names to play it with computer type'computer in player 2 place'", "No you can't do it");
            }
            else
            {
                Button b = (Button)sender;
                if (turns)
                    b.Text = "X";
                else
                    b.Text = "O";

                turns = !turns;

                b.Enabled = false;
                turn_count++;
                check_for_winner();
            }
            if((!turns)&&(against_computer))
            {
                computer_make_move();
            }
        }
        private void computer_make_move()
        {
            try
            {
                Button move = null;

                move = look_for_win_or_block("O");
                if (move == null)
                {
                    move = look_for_win_or_block("X");
                    if (move == null)
                    {
                        move = look_for_corner();
                        if (move == null)
                        {
                            move = look_for_openspace();
                        }
                    }
                }
                move.PerformClick();
            }
            catch { }
        }
        private Button look_for_win_or_block(string mark)
        {
            //horizontall
            if ((button1.Text == mark) && (button2.Text == mark) && (button3.Text == ""))
                return button3;
            if ((button2.Text == mark) && (button3.Text == mark) && (button1.Text == ""))
                return button1;
            if ((button1.Text == mark) && (button3.Text == mark) && (button2.Text == ""))
                return button2;

            if ((button6.Text == mark) && (button5.Text == mark) && (button4.Text == ""))
                return button4;
            if ((button5.Text == mark) && (button4.Text == mark) && (button6.Text == ""))
                return button6;
            if ((button6.Text == mark) && (button4.Text == mark) && (button5.Text == ""))
                return button5;

            if ((button9.Text == mark) && (button8.Text == mark) && (button7.Text == ""))
                return button7;
            if ((button8.Text == mark) && (button7.Text == mark) && (button9.Text == ""))
                return button9;
            if ((button9.Text == mark) && (button7.Text == mark) && (button8.Text == ""))
                return button8;
            
            //vertical finding
            if ((button1.Text == mark) && (button6.Text == mark) && (button9.Text == ""))
                return button9;
            if ((button9.Text == mark) && (button1.Text == mark) && (button6.Text == ""))
                return button6;
            if ((button6.Text == mark) && (button9.Text == mark) && (button1.Text == ""))
                return button1;

            if ((button2.Text == mark) && (button5.Text == mark) && (button8.Text == ""))
                return button8;
            if ((button2.Text == mark) && (button8.Text == mark) && (button5.Text == ""))
                return button5;
            if ((button8.Text == mark) && (button5.Text == mark) && (button2.Text == ""))
                return button2;

            if ((button3.Text == mark) && (button4.Text == mark) && (button7.Text == ""))
                return button7;
            if ((button3.Text == mark) && (button7.Text == mark) && (button4.Text == ""))
                return button4;
            if ((button4.Text == mark) && (button7.Text == mark) && (button3.Text == ""))
                return button3;

            //diagonal
            if ((button1.Text == mark) && (button5.Text == mark) && (button7.Text == ""))
                return button7;
            if ((button1.Text == mark) && (button7.Text == mark) && (button5.Text == ""))
                return button5;
            if ((button5.Text == mark) && (button7.Text == mark) && (button1.Text == ""))
                return button1;

            if ((button3.Text == mark) && (button5.Text == mark) && (button9.Text == ""))
                return button9;
            if ((button3.Text == mark) && (button9.Text == mark) && (button5.Text == ""))
                return button5;
            if ((button5.Text == mark) && (button9.Text == mark) && (button3.Text == ""))
                return button3;

            //last no find
            return null;
        }
        private Button look_for_corner()
        {
            if(button1.Text == "O")
            {
                if (button3.Text == "")
                    return button3;
                if (button7.Text == "")
                    return button7;
                if (button9.Text == "")
                    return button9;
            }
            if (button3.Text == "O")
            {
                if (button7.Text == "")
                    return button7;
                if (button9.Text == "")
                    return button9;
                if (button1.Text == "")
                    return button1;
            }
            if (button9.Text == "O")
            {
                if (button3.Text == "")
                    return button3;
                if (button7.Text == "")
                    return button7;
                if (button1.Text == "")
                    return button1;
            }
            if (button7.Text == "O")
            {
                if (button3.Text == "")
                    return button3;
                if (button9.Text == "")
                    return button9;
                if (button1.Text == "")
                    return button1;
            }
            if (button7.Text == "")
                return button7;
            if (button3.Text == "")
                return button3;
            if (button9.Text == "")
                return button9;
            if (button1.Text == "")
                return button1;


            return null;
        }
        private Button look_for_openspace()
        {
            Button b = null;
            foreach(Control c in Controls)
            {
                b=c as Button;
                if(b != null)
                {
                    if(b.Text == "")
                        return b;
                }
            }
            return null;
        }
        private void check_for_winner()
        {
            bool thereisawinner = false;

            if ((button1.Text == button2.Text && button2.Text == button3.Text) && (!button1.Enabled))
                thereisawinner = true;
            else if ((button4.Text == button5.Text && button5.Text == button6.Text) && (!button4.Enabled))
                thereisawinner = true;
            else if ((button7.Text == button8.Text && button8.Text == button9.Text) && (!button7.Enabled))
                thereisawinner = true;

            if ((button1.Text == button6.Text && button6.Text == button9.Text) && (!button1.Enabled))
                thereisawinner = true;
            else if ((button2.Text == button5.Text && button5.Text == button8.Text) && (!button2.Enabled))
                thereisawinner = true;
            else if ((button3.Text == button4.Text && button4.Text == button7.Text) && (!button3.Enabled))
                thereisawinner = true;

            if ((button1.Text == button5.Text && button5.Text == button7.Text) && (!button1.Enabled))
                thereisawinner = true;
            else if ((button3.Text == button5.Text && button5.Text == button9.Text) && (!button3.Enabled))
                thereisawinner = true;

            try 
            { 
            if (thereisawinner)
            {
                disablebuttons();
                string winner = "";
                if (turns)
                {
                    winner = Player2;
                    Owin_count.Text = (Int32.Parse(Owin_count.Text) + 1).ToString();
                }
                else
                {
                    winner = Player1;
                    Xwin_count.Text = (Int32.Parse(Xwin_count.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " wins", "Khattam tata bye bye");
            }
            else
            {


                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("you bummer its a Draw", "go play again");
                }
             }
           }
            catch { }

        }
        private void disablebuttons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch{ }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turns = true;
            turn_count = 0;
            
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }catch { }
                }
           
        }

        private void button_enter(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                if (b.Enabled)
                {
                    if (turns)
                        b.Text = "X";
                    else
                        b.Text = "O";
                }
            }catch { }
        }

        private void button_leave(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                if (b.Enabled)
                {
                    if (turns)
                        b.Text = "";
                    else
                        b.Text = "";
                }
            }
            catch { }
        }

        private void resetWinCoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Xwin_count.Text = "0";
            Owin_count.Text = "0";
            draw_count.Text = "0";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.ToLower()=="computer")
            {
                against_computer = true;
            }
            else
            {
                against_computer=false;
            }
        }

        protected void setPlayerDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = Player1;
            
            textBox2.Text = "computer";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            textBox1.Text = Player1;
            textBox2.Text = Player2;

        }
    }
}
