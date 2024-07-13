using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeGotchi
{
    public partial class Form1 : Form
    {
        int incremento = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            incremento = incremento + 5;
            progressBar1.Increment(10);
            if (incremento == 100)
            {
                bañandose ppal = new bañandose();
                ppal.Show();
                this.Hide();
                timer1.Stop();
            }
        }
    }
}
