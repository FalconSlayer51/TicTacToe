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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Playbutton_Click(object sender, EventArgs e)
        {
            Form1.setPlayernames(textBox1.Text, textBox2.Text);
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.ToString() =="\r")
                Playbutton.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "computer";
            Playbutton.PerformClick();   
        }
    }
}
