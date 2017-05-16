using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
     
    public partial class Form1 : Form
    {
        public object[] game;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             [ ["Armando", "P"], ["Dave", "S"] ]
             */
            game = new object[2];
            game[0] = new Player("Armando", "P");
            game[1] = new Player("Dave", "S");

            rps_game_winner(game);


            /*
             [ ["Armando", "P"], ["Dave", "S"] ],
             [ ["Richard", "R"], ["Michael", "S"] ],
             */
            object[] game1 = new object[2];

            game = new object[2];
            game[0] = new Player("Armando", "P");
            game[1] = new Player("Dave", "S");
            game1[0] = game;

            game = new object[2];
            game[0] = new Player("Richard", "R");
            game[1] = new Player("Michel", "S");
            game1[1] = game;


            object winner = rps_tournament_winner(game1);

            textBox1.Text += "Vencedor....:";
            textBox1.Text += (winner as Player).jogador;
            textBox1.Text += (winner as Player).jogada;
        }

        public object rps_game_winner(object[] game)
        {
            if (game.Length > 2)
                throw new Exception("");

            Player p1 = game[0] as Player;
            Player p2 = game[1] as Player;

            if (p1.jogada.ToUpper().IndexOfAny(new char[] { 'R', 'S', 'P' }) == -1)
                throw new Exception("");

            if (p2.jogada.ToUpper().IndexOfAny(new char[] { 'R', 'S', 'P' }) == -1)
                throw new Exception("");

            if (p1.jogada == "R" && p2.jogada == "S")
                return p1;
            else if (p1.jogada == "S" && p2.jogada == "P")
                return p1;
            else if (p1.jogada == "P" && p2.jogada == "R")
                return p1;

            if (p2.jogada == "R" && p1.jogada == "S")
                return p2;
            else if (p2.jogada == "S" && p1.jogada == "P")
                return p2;
            else if (p2.jogada == "P" && p1.jogada == "R")
                return p2;
            else return p1;

        }

        public object rps_tournament_winner(object[] game)
        {
            if (game.Length == 2 && game[0] is Player)
            {
                return rps_game_winner(game);
            }else
            {
                object[] game_inner = new object[2];
                game_inner[0] = rps_tournament_winner(game[0] as object[]);
                game_inner[1] = rps_tournament_winner(game[1] as object[]);

                return rps_tournament_winner(game_inner);
            }

            
        }

        public class Player
        {
            public string jogador { get; set; }
            public string jogada { get; set; }

            public Player(string _jogador, string _jogada)
            {
                this.jogador = _jogador;
                this.jogada = _jogada;
            }
        }

    }
    
}
