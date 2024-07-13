using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace PokeGotchi
{
    public partial class bañandose : Form
    {
        int segundos = 0;
        Random rnd = new Random();
        int secBañar = 0;
        int k = 0;
        int abrirPokebola = 0;
        public static int puntos=0;
        WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        Point lastPoint;
        public Color StartColor;
        
        public bañandose()
        {
            InitializeComponent();
            Pokemon.Controls.Add(pictureBox4);
            pictureBox4.Location = new Point(35, 140);
            bañandose2.Controls.Add(gotas);
            gotas.Location = new Point(120, 61);
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
            this.BackgroundImage = Properties.Resources.Fondo1;
            progressBar1.EditValue = 100;
          wmp.URL = @"Sound.wav";
            wmp.settings.volume = 30 ;
           wmp.settings.setMode("loop", true);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            abrirPokebola = 1;
            PokeCerrada.Visible = false;
            pictureBox12.Enabled = true;
            pictureBox13.Enabled = true;
            pictureBox14.Enabled = true;
            pictureBox15.Enabled = true;
            Pokebola.Start();
            
            axWindowsMediaPlayer1.URL = "Grito2.wav";
            axWindowsMediaPlayer1.settings.volume = 70;

        }

        private void Pokebola_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (abrirPokebola == 1)
            {
                switch (segundos)
                {
                    case 1:
                        PokeAbierta2.Image = Properties.Resources.OpenPokeball;
                        Pokemon.Visible = true;
                        break;
                    case 2:
                        Pokemon.Image = Properties.Resources.Capturando;
                        break;
                    case 3:                        
                        Pokemon.Image = Properties.Resources.OjosAbiertos;
                        break;
                    case 4:
                        PokeAbierta2.Image = null;
                        Pokebola.Stop();
                        Parpadeo.Start();                    
                        timer1.Start();
                        segundos = 0;
                        break;
                }
            }               
            else 
            {
                switch (segundos)
                {
                    case 1:
                        PokeAbierta2.Image = Properties.Resources.OpenPokeball;
                        break;
                    case 2:
                        Pokemon.Image = Properties.Resources.Capturando;
                        break;
                    case 3:
                        Pokemon.Visible = false;
                        break;
                    case 4:
                        PokeAbierta2.Image = null;
                        Pokebola.Stop();
                        Parpadeo.Stop();                       
                        segundos = 0;
                        abrirPokebola = 0;
                        PokeCerrada.Visible = true;
                        break;
                }
            }               
            
        }

        private void Parpadeo_Tick(object sender, EventArgs e)
        {
            int Num = rnd.Next(1, 25);
            if (Num == 1 && progressBar1.Position > 50 && progressBar2.Position < 50 && progressBar3.Position < 50)
            {
                Pokemon.Image = Properties.Resources.OjosCerrados;
            }
            else if (Num == 1 && progressBar1.Position > 50 && progressBar2.Position > 50 && progressBar3.Position > 50)
            {
                Pokemon.Image = Properties.Resources.HambreOjoCerrado;
            }
            else if (Num == 1 && progressBar1.Position > 50 && progressBar2.Position > 50 && progressBar3.Position < 50)
            {
                Pokemon.Image = Properties.Resources.HambreOjoCerrado;
            }
            else if (Num == 1 && progressBar1.Position > 50 && progressBar2.Position < 50 && progressBar3.Position > 50)
            {
                Pokemon.Image = Properties.Resources.OjosAbiertos;
            }
            else if (Num == 1 && progressBar1.Position < 50 && progressBar2.Position < 50 && progressBar3.Position < 50)
            {
                Pokemon.Image = Properties.Resources.HambreOjoCerrado;
            }
            else if (Num == 1 && progressBar1.Position < 50 && progressBar2.Position > 50 && progressBar3.Position < 50)
            {
                Pokemon.Image = Properties.Resources.HambreOjoCerrado;
            }
            else if (Num == 1 && progressBar1.Position < 50 && progressBar2.Position < 50 && progressBar3.Position > 50)
            {
                Pokemon.Image = Properties.Resources.HambreOjoCerrado;
            }
            else if (Num == 1 && progressBar1.Position < 50 && progressBar2.Position > 50 && progressBar3.Position > 50)
            {
                Pokemon.Image = Properties.Resources.HambreOjoCerrado;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int aumento = rnd.Next(1,4);
            int aumento2 = rnd.Next(1, 4);
            progressBar1.Increment(-1);
            progressBar2.Increment(aumento);
            progressBar3.Increment(aumento2);

            if (progressBar1.Position == 50)
            {
                progressBar1.BackgroundImage = Properties.Resources.Aburrido;
            }
            if (progressBar1.Position > 50 && progressBar2.Position < 50 && progressBar3.Position < 50)
            {
                Pokemon.Image = Properties.Resources.OjosAbiertos;

            }
            else if (progressBar1.Position > 50 && progressBar2.Position > 50 && progressBar3.Position > 50)
            {
                Pokemon.Image = Properties.Resources.Hambre;
                pbMensaje.Image = Properties.Resources.Mensaje;
                label2.Visible = true;
                label2.Text = "TENGO HAMBRE Y ESTOY SUCIO";
                pictureBox4.Image = Properties.Resources.IconoHambre;
                pictureBox5.Image = Properties.Resources.Apestoso;
            }
            else if (progressBar1.Position > 50 && progressBar2.Position > 50 && progressBar3.Position < 50)
            {
                Pokemon.Image = Properties.Resources.Hambre;
                pbMensaje.Image = Properties.Resources.Mensaje;
                label2.Visible = true;
                label2.Text = "TENGO HAMBRE";
                pictureBox4.Image = Properties.Resources.IconoHambre;

            }
            else if (progressBar1.Position > 50 && progressBar2.Position < 50 && progressBar3.Position > 50)
            {
                Pokemon.Image = Properties.Resources.OjosAbiertos;
                pbMensaje.Image = Properties.Resources.Mensaje;
                label2.Visible = true;
                label2.Text = "ESTOY SUCIO";
               
                pictureBox5.Image = Properties.Resources.Apestoso;
            }
            else if (progressBar1.Position < 50 && progressBar2.Position < 50 && progressBar3.Position < 50)
            {
                Pokemon.Image = Properties.Resources.Aburrido;
                pbMensaje.Image = Properties.Resources.Mensaje;
                label2.Visible = true;
                label2.Text = "ESTOY ABURRIDO";
            }
            else if (progressBar1.Position < 50 && progressBar2.Position > 50 && progressBar3.Position < 50)
            {
                Pokemon.Image = Properties.Resources.Aburrido;
                pbMensaje.Image = Properties.Resources.Mensaje;
                label2.Visible = true;
                label2.Text = "ESTOY ABURRIDO Y TENGO HAMBRE";
                pictureBox4.Image = Properties.Resources.IconoHambre;
              
            }
            else if (progressBar1.Position < 50 && progressBar2.Position < 50 && progressBar3.Position > 50)
            {
                Pokemon.Image = Properties.Resources.Aburrido;
                pbMensaje.Image = Properties.Resources.Mensaje;
                label2.Visible = true;
                label2.Text = "ESTOY ABURRIDO Y ESTOY SUCIO";
      
                pictureBox5.Image = Properties.Resources.Apestoso;
            }
            else if (progressBar1.Position < 50 && progressBar2.Position > 50 && progressBar3.Position > 50)
            {
                Pokemon.Image = Properties.Resources.Aburrido;
                pbMensaje.Image = Properties.Resources.Mensaje;
                label2.Visible = true;
                label2.Text = "ESTOY ABURRIDO Y TENGO HAMBRE Y ESTOY SUCIO!!";

                pictureBox4.Image = Properties.Resources.IconoHambre;
                pictureBox5.Image = Properties.Resources.Apestoso;
            }




            if (progressBar1.Position < 50 )
            {

                notifyIcon1.ShowBalloonTip(20000, "PocketGotchi", "Tu Mascota Necesita Atencion !!!",
                ToolTipIcon.Info);

            }
            if ( progressBar2.Position > 50)
            {

                notifyIcon1.ShowBalloonTip(20000, "PocketGotchi", "Tu Mascota Necesita Atencion !!!",
                ToolTipIcon.Info);

            }
            if (progressBar3.Position > 50)
            {

                notifyIcon1.ShowBalloonTip(20000, "PocketGotchi", "Tu Mascota Necesita Atencion !!!",
                ToolTipIcon.Info);

            }

        }

       

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        public void Puntos() 
        {
            int x = rnd.Next(1,7);
            if (x == 1) 
            {
                puntos++;
                labelpuntos.Text = puntos.ToString();
                label1.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Puntos();
            bañandose2.Visible = true;
            bañandose2.Image = Properties.Resources.Bañandose;
            Pokemon.Visible = false;
            pictureBox5.Visible = false;
            Balon.Visible = false;
            Comida.Visible = false;
            pbMensaje.Visible = false;
            PokeAbierta2.Visible = false;
            bañar.Start();
            gotas.Image = Properties.Resources.Agua;
            
        }

        private void bañar_Tick(object sender, EventArgs e)
        {
            switch (secBañar) 
            {
                case 1:
                    gotas.Location = new Point(120, 61);
                    break;
                case 2:
                    gotas.Location = new Point(120, 91);
                    break;
                case 3:
                    gotas.Location = new Point(120, 121);
                    break;
            }
            secBañar++;
            if (secBañar > 4)
            {
                secBañar = 0;
            }
            if (k > 10) 
            {
                limpiar();
                bañar.Stop();
                progressBar3.EditValue = 0;
                bañandose2.Visible = false;
                bañandose2.Image = null;
                Pokemon.Visible = true;
                pictureBox5.Visible = true;
                Balon.Visible = true;
                Comida.Visible = true;
                pbMensaje.Visible = true;
                PokeAbierta2.Visible = true;
                label1.Visible = false;
                gotas.Image = null;
                k = 0;
            }
            k++;
        }

        private void Contador_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
            Balon.Image = null;
            Comida.Image = null;
            Contador.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Parpadeo.Stop();
            timer1.Stop();
            pictureBox12.Enabled = false;
            pictureBox13.Enabled = false;
            pictureBox14.Enabled = false;
            pictureBox15.Enabled = false;
            abrirPokebola = 2;           
            Pokebola.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.Visible = false;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox10.Visible = true;
            pictureBox11.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox9.Visible = true;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (puntos > 5) 
            {
                label4.Location = new Point(-30,-30);
                puntos = puntos - 5;
                labelpuntos.Text = puntos.ToString();
                pictureBox6.Enabled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (puntos > 6)
            {
                label5.Location = new Point(-30, -30);
                puntos = puntos - 7;
                labelpuntos.Text = puntos.ToString();
                pictureBox7.Enabled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (puntos > 6)
            {
                label6.Location = new Point(-30, -30);
                puntos = puntos - 7;
                labelpuntos.Text = puntos.ToString();
                pictureBox8.Enabled = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Fondo2;
            wmp.URL = @"1.mp3";
          wmp.settings.volume = 30;
            wmp.settings.setMode("loop", true);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Fondo3;
           wmp.URL = @"3.mp3";
            wmp.settings.volume = 30;
            wmp.settings.setMode("loop", true);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Fondo4;
           wmp.URL = @"2.mp3";
            wmp.settings.volume = 30;
           wmp.settings.setMode("loop", true);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Fondo1;
            wmp.URL = @"Sound.wav";
           wmp.settings.volume = 30;
            wmp.settings.setMode("loop", true);
        }

        private void butt_Click(object sender, EventArgs e)
        {
            
        }

        private void butt2_Click(object sender, EventArgs e)
        {
            
        }

        private void butt3_Click(object sender, EventArgs e)
        {
           
        }
        public void limpiar() 
        {
            pictureBox5.Image = null;
            pbMensaje.Image = null;
            label2.Visible = false;
            pictureBox4.Image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wmp.controls.pause();
            this.Hide();
        }

        private void mnuMostrarAplicacion_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuCerrarAplicacion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconizarApp_BalloonTipClicked(object sender, EventArgs e)
        {
            
        }

        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            wmp.controls.play();
            this.Show();
        }

        private void Pokemon_Click(object sender, EventArgs e)
        {
            
            axWindowsMediaPlayer2.URL= "Grito2.wav";
            axWindowsMediaPlayer2.settings.volume = 70;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
           lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
{
this.Left += e.X - lastPoint.X;
this.Top += e.Y - lastPoint.Y;
}
}

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            limpiar();
            Pokemon.Image = Properties.Resources.OjosAbiertos;
            Puntos();
            Contador.Start();
            progressBar2.EditValue = 0;
            Comida.Image = Properties.Resources.Comida;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            limpiar();
            Pokemon.Image = Properties.Resources.OjosAbiertos;
            Puntos();
            Contador.Start();
            progressBar1.EditValue = 100;
            Balon.Image = Properties.Resources.Balon;

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Parpadeo.Stop();
            timer1.Stop();
            pictureBox12.Enabled = false;
            pictureBox13.Enabled = false;
            pictureBox14.Enabled = false;
            pictureBox15.Enabled = false;
            abrirPokebola = 2;
            Pokebola.Start();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Puntos();
            bañandose2.Visible = true;
            bañandose2.Image = Properties.Resources.Bañandose;
            Pokemon.Visible = false;
            pictureBox5.Visible = false;
            Balon.Visible = false;
            Comida.Visible = false;
            pbMensaje.Visible = false;
            PokeAbierta2.Visible = false;
            bañar.Start();
            gotas.Image = Properties.Resources.Agua;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
        }
    

