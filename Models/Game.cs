
namespace TicTacToe.Models {
    public class Game {
        public Guid Id { get; } = Guid.NewGuid();
        private int _timesPlayed { get; set; } = 0;
        public GameBoardSquare[] gameBoard { get; } = new GameBoardSquare[9];
        private string _playTurn { get; set; } = "X";

        public void InitializeGameBoard() {
            for(int i = 0; i < 9; i++){
                gameBoard[i] = new GameBoardSquare(i);
            }
        }

        public bool MakeMove(int squareNumber) {
            if(gameBoard[squareNumber].SquareSymbol == "") {
                _timesPlayed++;
                gameBoard[squareNumber].SquareSymbol = _playTurn;
                if (_playTurn == "X") _playTurn = "O";
                else _playTurn = "X";
                return true;
            }
            return false;
        }

        public string CheckWinner()
        {
            string winner = "";

            if (_timesPlayed < 5)
            {
                return winner;
            }

            for (int i = 0; i < 7; i += 3)
            {
                if (!string.IsNullOrEmpty(gameBoard[i].SquareSymbol) &&
                    gameBoard[i].SquareSymbol == gameBoard[i + 1].SquareSymbol &&
                    gameBoard[i].SquareSymbol == gameBoard[i + 2].SquareSymbol)
                {
                    return gameBoard[i].SquareSymbol;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(gameBoard[i].SquareSymbol) &&
                    gameBoard[i].SquareSymbol == gameBoard[i + 3].SquareSymbol &&
                    gameBoard[i].SquareSymbol == gameBoard[i + 6].SquareSymbol)
                {
                    return gameBoard[i].SquareSymbol;
                }
            }

            if (!string.IsNullOrEmpty(gameBoard[0].SquareSymbol) &&
                gameBoard[0].SquareSymbol == gameBoard[4].SquareSymbol &&
                gameBoard[0].SquareSymbol == gameBoard[8].SquareSymbol)
            {
                return gameBoard[0].SquareSymbol;
            }

            if (!string.IsNullOrEmpty(gameBoard[2].SquareSymbol) &&
                gameBoard[2].SquareSymbol == gameBoard[4].SquareSymbol &&
                gameBoard[2].SquareSymbol == gameBoard[6].SquareSymbol)
            {
                return gameBoard[2].SquareSymbol;
            }

            if (_timesPlayed <= 9)
            {
                winner = "draw";
            }

            return winner;
        }
    }
}