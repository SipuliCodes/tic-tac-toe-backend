namespace TicTacToe.Models {
    public class GameBoardSquare(int squareNumber)
    {
        public int SquareNumber { get; } = squareNumber;
        public string SquareSymbol { get; set; } = "";
    }
}
