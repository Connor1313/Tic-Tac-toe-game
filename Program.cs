using System;
//Connor Aoun M4 Tic Tac Toe game
//Cmad6f
//2/10/2023
namespace M4
{
    //enum for the different states each point on the board can be.
    public enum States
    {
        Undecided,
        X,
        O,

    }


    class Program
    {
        //struct for the position of each point
        struct Position
        {
            public int row;
            public int column;
            public Position(int row, int column)
            {
                this.row = row;
                this.column = column;
            }
        }
        //main program
        static void Main(string[] args)
        {
            //boolean variable to keep the game going until there is a winner or draw
            bool game = true;
            //constructs a board 1-9 each having an undecided state
            Board[] board;
            board = new Board[]
            {
                new Board(1, States.Undecided),
                new Board(2, States.Undecided),
                new Board(3, States.Undecided),
                new Board(4, States.Undecided),
                new Board(5, States.Undecided),
                new Board(6, States.Undecided),
                new Board(7, States.Undecided),
                new Board(8, States.Undecided),
                new Board(9, States.Undecided),
            };
         
            //tells what each player is
            Console.WriteLine("Player 1 is X, Player 2 is O\n");
            BoardPicture(board);

            //initializes a count so that the game knows when its a draw
            int count = 0;
            //do until game is false
            do
            {
                //player 1s turn
                Player1Turn(board);
                count++;
                //each time checks if there is a winner
                string win1 = checkWinner(board);
                if (win1 == "X")
                {
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Player 1 wins congrats!");
                    BoardPicture(board);
                    game = false;
                    break;
                }
                else if (count >= 8)
                {
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("The game is a draw!");
                    BoardPicture(board);
                    game = false;
                    break;
                }
                if (win1 == "O")
                {
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Player 2 wins congrats!");
                    BoardPicture(board);
                    game = false;
                    break;
                }

                //player 2s turn
                Player2Turn(board);
                count++;
                //each time checks if there is a winner
                string win2 = checkWinner(board);
                if (win2 == "X")
                {
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Player 2 wins congrats!");
                    BoardPicture(board);
                    game = false;
                    break;
                }
                if (win2 == "O")
                {
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Player 2 wins congrats!");
                    BoardPicture(board);
                    game = false;
                    break;
                }

            }
            while (game == true);
            //pauses the program with a readline
            Console.ReadLine();

        }

        //this function prints the board each time it is called
        public static void BoardPicture(Board[] board)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", checkIfEmpty(board, 0), checkIfEmpty(board, 1), checkIfEmpty(board, 2));
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", checkIfEmpty(board, 3), checkIfEmpty(board, 4), checkIfEmpty(board, 5));
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", checkIfEmpty(board, 6), checkIfEmpty(board, 7), checkIfEmpty(board, 8));
            Console.WriteLine("     |     |      ");
        }

        //this function checks if a position on the board is undecided, has an X, or has an O
        //returns a string so that the board can print using this function
        public static string checkIfEmpty(Board[] board, int pos)
        {
            if (board[pos].State == States.Undecided)
            {
                return " ";
            }
            else if (board[pos].State == States.X)
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }

        //this function asks for user input, makes sure it is an integer 1-9 and returns it
        public static int choice()
        {
            var choice = 0;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
               if (choice > 0 && choice < 10)
               {
                     return choice;
               }
            }
            return -1;
        }

        //this function does the turn for player1
        public static void Player1Turn(Board[] board)
        {
            //loops until the player enters correct inpupt
            bool turn = true;
            do
            {
                //tells the player how the board is labeled and asks for input
                Console.WriteLine("The board is labeled 1-9");
                Console.WriteLine("Player 1 where would you like to go: ");
                int player1Choice = choice();
                //if input is not invalid it chekcs the state
                if (player1Choice != -1)
                {
                    //if the state is undecided it sets it to X since player1 is X
                    if (board[player1Choice - 1].State == States.Undecided)
                    {
                        //prints board and ends turn
                        board[player1Choice - 1].State = States.X;
                        BoardPicture(board);
                        turn = false;
                    }
                    //tells the user their input is incorrect
                    else if (board[player1Choice - 1].State == States.X)
                    {
                        Console.WriteLine("Please enter a valid number 1-9 in an empty spot.");
                        continue;
                    }
                    //tells the user their input is incorrect
                    else
                    {
                        Console.WriteLine("Please enter a valid number 1-9 in an empty spot.");
                        continue;
                    }
                }
                //asks the user to enter a correct input
                else
                {
                    Console.WriteLine("Please enter a valid number 1-9");
                    continue;
                }

            }//end of loop
            while (turn == true);
        }
        public static void Player2Turn(Board[] board)
        {
            //loops until the player enters correct inpupt
            bool turn = true;
            do
            {
                //tells the player how the board is labeled and asks for input
                Console.WriteLine("The board is labeled 1-9");
                Console.WriteLine("Player 2 where would you like to go: ");
                int player2Choice = choice();
                //if input is not invalid it chekcs the state
                if (player2Choice != -1)
                {
                    //if the state is undecided it sets it to X since player1 is X
                    if (board[player2Choice - 1].State == States.Undecided)
                    {
                        board[player2Choice - 1].State = States.O;
                        BoardPicture(board);
                        turn = false;
                    }
                    //tells the user their input is incorrect
                    else if (board[player2Choice - 1].State == States.X)
                    {
                        Console.WriteLine("Please enter a valid number 1-9 in an empty spot.");
                        continue;
                    }
                    //tells the user their input is incorrect
                    else
                    {
                        Console.WriteLine("Please enter a valid number 1-9 in an empty spot.");
                        continue;
                    }
                }
                //asks the user to enter a correct input
                else
                {
                    Console.WriteLine("Please enter a valid number 1-9");
                    continue;
                }

            }//end of loop
            while (turn == true);
        }
        //this function checks who the winner is and returns the winner or returns to keep playing
        public static string checkWinner(Board[] board)
        {
            //all paths from top left
            if ((board[0].State == board[1].State) && (board[0].State == board[2].State) && (board[0].State != States.Undecided) && (board[1].State != States.Undecided) && (board[2].State != States.Undecided))
            {
                return checkIfEmpty(board, 0);
            }
            if ((board[0].State == board[3].State) && (board[0].State == board[6].State) && (board[0].State != States.Undecided) && (board[3].State != States.Undecided) && (board[6].State != States.Undecided))
            {
                return checkIfEmpty(board, 0);
            }
            if ((board[0].State == board[4].State) && (board[0].State == board[8].State) && (board[0].State != States.Undecided) && (board[4].State != States.Undecided) && (board[8].State != States.Undecided))
            {
                return checkIfEmpty(board, 0);
            }

            //middle row
            if ((board[1].State == board[4].State) && (board[1].State == board[7].State) && (board[1].State != States.Undecided) && (board[4].State != States.Undecided) && (board[7].State != States.Undecided)) 
            {
                return checkIfEmpty(board, 0);
            }

            //right row
            if ((board[2].State == board[5].State) && (board[2].State == board[8].State) && (board[2].State != States.Undecided) && (board[5].State != States.Undecided) && (board[8].State != States.Undecided))
            {
                return checkIfEmpty(board, 0);
            }

            //top left diagonal
            if ((board[0].State == board[4].State) && (board[0].State == board[8].State) && (board[0].State != States.Undecided) && (board[4].State != States.Undecided) && (board[8].State != States.Undecided) )
            {
                return checkIfEmpty(board, 0);
            }

            //top right diagonal
            if ((board[2].State == board[4].State) && (board[2].State == board[6].State) && (board[2].State != States.Undecided) && (board[4].State != States.Undecided) && (board[6].State != States.Undecided))
            {
                return checkIfEmpty(board, 0);
            }

            //middle row
            if ((board[3].State == board[4].State) && (board[3].State == board[5].State) && (board[3].State != States.Undecided) && (board[4].State != States.Undecided) && (board[5].State != States.Undecided))
            {
                return checkIfEmpty(board, 0);
            }

            //bottom row
            if ((board[6].State == board[7].State) && (board[6].State == board[8].State) && (board[6].State != States.Undecided) && (board[7].State != States.Undecided) && (board[8].State != States.Undecided))
            {
                return checkIfEmpty(board, 0);
            }

            //iterates through the loop to check if the game should still be played or if its over
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i].State == States.Undecided);
                    return "keep playing";
            }
            return "draw";
            
        }
    }
       
    // this class initalizes an object Board with a position and a state
    public class Board
    {

        private int _boardPosition;
        private States _state;

        //constructs the object
        public Board(int position, States state)
        {
            _boardPosition = position;
            _state = state;
        }
        //getter and setter for position
        public int BoardPosition
        {
            get
            {
                return _boardPosition;
            }
            set
            {
                _boardPosition = value;
            }
        }
        //getter and setter for the state of the position
        public States State
        {
            get
            {
                return _state;
            }
            set
            { 
                _state = value; 
            }
        }
    }

}
