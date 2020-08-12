using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prueba_clases;

namespace prueba_clases
{

    public partial class Form1 : Form
    {
        int jugador1 = 0;
        int jugador2 = 0;
        int turno = 1;
        int[,] tictactoe;
        bool ganador;
        public Form1()
        {
            InitializeComponent();
            inicializarvariabls();
        }

        public void inicializarvariabls()
        {
            turno = 1;
            tictactoe = new int[3, 3];
            ganador = false;
            pictureBox3.Image = Properties.Resources.f_0;
            tableLayoutPanel1.Controls.Clear();
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var fichas = new PictureBox();
                    fichas.Image = Properties.Resources.f_0;
                    fichas.Name = string.Format("{0}", i + "_" + j);
                    fichas.Dock = DockStyle.Fill;
                    fichas.Cursor = Cursors.Hand;
                    fichas.SizeMode = PictureBoxSizeMode.StretchImage;
                    fichas.Click += jugar;
                    tableLayoutPanel1.Controls.Add(fichas, j, i);
                    tictactoe[i, j] = 0;
                }
            }
        }

        private void jugar(object sender, EventArgs e)
        {
            var fichaselc = (PictureBox)sender;
            fichaselc.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("f_" + turno);
            string[] Posicion = fichaselc.Name.Split("_".ToCharArray());
            int Fila = Convert.ToInt32(Posicion[0]);
            int Columna = Convert.ToInt32(Posicion[1]);
            tictactoe[Fila, Columna] = turno;
            verificar(Fila, Columna);
            turno = (turno == 1) ? 2 : 1;
        }

        public void verificar(int Fila,int Columna)
        {
            int Ganofilas = 0;
            int GanoColumnas = 0;
            int DiagonalP = 0;
            int DiagonalI = 0;
            int Tamaniotictactoe = 3;

            for (var i = 0; i < Tamaniotictactoe; i++)
            {
                for(var j = 0; j < Tamaniotictactoe; j++)
                {
                    if (i == Fila)
                    {
                        if (tictactoe[i,j] == turno)
                        {
                            Ganofilas++;
                        }
                    }

                    if (j == Columna)
                    {
                        if (tictactoe[i,j] == turno)
                        {
                            GanoColumnas++;
                        }
                    }

                    if (i == j)
                    {
                        if (tictactoe[i, j] == turno)
                        {
                            DiagonalP++;
                        }
                    }

                    if ((i + j) == (Tamaniotictactoe -1))
                    {
                        if (tictactoe[i, j] == turno)
                        {
                            DiagonalI++;
                        }                        }
                    }
                }
            if ((Ganofilas == Tamaniotictactoe) || (GanoColumnas == Tamaniotictactoe) || (DiagonalP == Tamaniotictactoe) || (DiagonalI == Tamaniotictactoe))
            {
                ganador = true;
            }

            if (ganador)
            {
                MessageBox.Show("Ya hay Ganador");
                pictureBox3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("f_" + turno);
                if(turno == 1)
                {
                    jugador1++;
                    label2.Text = jugador1.ToString();
                }
                else
                {
                    jugador2++;
                    label3.Text = jugador2.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicializarvariabls()
        }
    }
}