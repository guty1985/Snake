using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        cola cabeza;
        Comida comida;
        Comida comida2;
        int puntaje = 0;
        int rapidez = 5;
        Graphics g;
        int xdir = 0;
        int ydir = 0;
        int cuadro = 10;
        Boolean ejex = true;
        Boolean ejey = true;
        


        public Form1()
        {
            InitializeComponent();
            cabeza = new cola(10, 10);
            comida = new Comida();
            comida2 = new Comida();
            g = canvas.CreateGraphics();
        }

        public void Movimiento()
        {
            cabeza.setxy(cabeza.verx() + xdir, cabeza.very()+ydir);



        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Bucle_Tick(object sender, EventArgs e)
        {

            
            g.Clear(Color.White);
            cabeza.dibujar(g);
            comida.dibujar(g);
            comida2.dibujar(g);
            Movimiento();
            ChoqueCuerpo();
            ChoquePared();
            if (cabeza.interseccion(comida))
            {
                comida.colocar();
                cabeza.meter();
                puntaje++;
                Puntos.Text = puntaje.ToString();
            }

            if (cabeza.interseccion(comida2))
            {

                comida2.colocar();
                cabeza.meter();
                puntaje++;
                Puntos.Text = puntaje.ToString();
            }

            if (puntaje > rapidez)
            {
                if (bucle.Interval > 20)
                {
                    bucle.Interval = bucle.Interval - 20;
                    rapidez = rapidez + 5;
                }     
            }
        }

        public void ChoquePared()
        {
            if (cabeza.verx() < 0 || cabeza.verx() > 770 || cabeza.very() < 0 || cabeza.very() > 380)
            {
                Findejuego();
            }
        }

        public void Findejuego()
        {
            puntaje = 0;
            Puntos.Text = "0";
            ejex = true;
            ejey = true;
            xdir = 0;
            ydir = 0;
            bucle.Interval = 100;
            cabeza = new cola(10, 10);
            comida = new Comida();
            MessageBox.Show("Perdiste");
        }

        public void ChoqueCuerpo()
        {
            cola temp;
            try
            {
                temp = cabeza.verSiguiente().verSiguiente();
            }
            catch (Exception err)
            {
                temp = null;
            }
            while (temp != null)
            {
                if (cabeza.interseccion(temp))
                {
                    Findejuego();
                }
                else
                {
                    temp = temp.verSiguiente();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ejex)
            {
                if (e.KeyCode == Keys.Up)
                {
                    ydir = -cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
                if(e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
            }
            if (ejey)
            {
                if (e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = cuadro;
                    ejex = true;
                    ejey = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -cuadro;
                    ejex = true;
                    ejey = false;
                }
            }
        }

        private void Puntos_Click(object sender, EventArgs e)
        {

        }
    }
}
