namespace TicTacToe.Models
{
    public class GameResponse
    {
        public Guid Id { get; set; }
        public required GameBoardSquare[] gameBoard { get; set; }
        public bool IsOver { get; set; }
        public required string Winner { get; set; }
    }
}