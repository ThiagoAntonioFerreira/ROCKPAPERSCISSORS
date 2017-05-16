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
        public object[] jogo;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**Exemplos....**/

            /*
             [ ["Armando", "P"], ["Dave", "S"] ]
             */
            jogo = new object[2];
            jogo[0] = new Player("Armando", "P");
            jogo[1] = new Player("Dave", "S");

            object winner = rps_tournament_winner(jogo);
            textBox1.Text += "Vencedor....:";
            textBox1.Text += (winner as Player).jogador + " ";
            textBox1.Text += (winner as Player).jogada;

            /*
             [ ["Armando", "P"], ["Dave", "S"] ],
             [ ["Richard", "R"], ["Michael", "S"] ],
             */
            object[] jogo1 = new object[2];

            jogo = new object[2];
            jogo[0] = new Player("Armando", "P");
            jogo[1] = new Player("Dave", "S");
            jogo1[0] = jogo;

            jogo = new object[2];
            jogo[0] = new Player("Richard", "R");
            jogo[1] = new Player("Michel", "S");
            jogo1[1] = jogo;


            winner = rps_tournament_winner(jogo1);
            textBox1.Text += Environment.NewLine;
            textBox1.Text += "Vencedor Jogo 1....:";
            textBox1.Text += (winner as Player).jogador + " ";
            textBox1.Text += (winner as Player).jogada;


            /*
             [
                    [
                        [ ["Armando", "R"], ["Dave", "S"] ],
                        [ ["Richard", "S"],  ["Michael", "S"] ],
                    ],
                    [
                        [ ["Allen", "P"], ["Omer", "S"] ],
                        [ ["David", "R"], ["Richard", "S"] ]
                    ]
                ]
             */
            object[] jogo2 = new object[2];

            jogo = new object[2];
            jogo[0] = new Player("João", "R");
            jogo[1] = new Player("Jose", "S");
            jogo2[0] = jogo;

            jogo = new object[2];
            jogo[0] = new Player("Cleber", "S");
            jogo[1] = new Player("Maria", "S");
            jogo2[1] = jogo;

            jogo = new object[2];
            jogo[0] = new Player("Michel", "P");
            jogo[1] = new Player("Joana", "S");
            jogo2[0] = jogo;

            jogo = new object[2];
            jogo[0] = new Player("Daniel", "R");
            jogo[1] = new Player("Ricardo", "S");
            jogo2[1] = jogo;


            winner = rps_tournament_winner(jogo2);
            textBox1.Text += Environment.NewLine;
            textBox1.Text += "Vencedor Jogo 2....:";
            textBox1.Text += (winner as Player).jogador + " ";
            textBox1.Text += (winner as Player).jogada;


        }

        public object rps_game_winner(object[] game)
        {
            if (game.Length > 2)
                throw new WrongNumberOfPlayersError("Numero de Jogadores inválido");

            Player p1 = game[0] as Player;
            Player p2 = game[1] as Player;

            if (p1.jogada.ToUpper().IndexOfAny(new char[] { 'R', 'S', 'P' }) == -1)
                throw new NoSuchStrategyError("Estratégia inválida");

            if (p2.jogada.ToUpper().IndexOfAny(new char[] { 'R', 'S', 'P' }) == -1)
                throw new NoSuchStrategyError("Estratégia inválida");

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


        public class NoSuchStrategyError : Exception
        {
            public NoSuchStrategyError()
            {
            }

            public NoSuchStrategyError(string message)
                : base(message)
            {
            }

        }

        public class WrongNumberOfPlayersError : Exception
        {
            public WrongNumberOfPlayersError()
            {
            }

            public WrongNumberOfPlayersError(string message)
                : base(message)
            {
            }

        }
    }
    
}
