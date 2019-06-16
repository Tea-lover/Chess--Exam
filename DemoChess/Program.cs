using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Chess.Chess;

namespace DemoChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Chess.Chess chess = new Chess.Chess();
            List<String> list;

            while(true)
            {
                list = chess.GetAllMoves();
                Console.Clear();
                
                    
                Console.WriteLine(chess.fen);
                //Console.WriteLine(ChessToAscii(chess));
                Print(ChessToAscii(chess));
                Console.WriteLine("Press 'q' to quit \n Press Enter and computer will make a move, or enter one of the following moves");
                if (list.Count == 0)
                {
                    Console.WriteLine("Mate! You loose.");
                    Console.WriteLine("press Enter to quit");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(chess.IsCheck() ? "CHECK" : "");

                    foreach (string moves in list)
                        Console.Write(moves + "\t");

                    Console.WriteLine();

                    string move = Console.ReadLine();
                    if (move == "q") break;
                    if (move == "")
                        move = list[random.Next(list.Count)];

                    chess = chess.Move(move);
                }
            }
        }

        static string ChessToAscii (Chess.Chess chess)
        {
            string text = "  +-----------------+\n";
            for (int y = 7; y >= 0; y--)
            {
                text += y + 1;
                text += " | ";
                for (int x = 0; x < 8; x++)
                    text += chess.GetFigureAt(x, y) + " ";
                text += "|\n";
            }
            text += "  +-----------------+\n";
            text += "   a b c d e f g h\n";
            return text;
        }

        static void Print(string text)
        {
            ConsoleColor oldForeColor = Console.ForegroundColor;
            foreach(char x in text)
            {
                if (x >= 'a' && x <= 'z')
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (x >= 'A' && x <= 'Z')
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(x);
            }
            Console.ForegroundColor = oldForeColor;
        }



    }
 
}

