
using TicTacToe.Models;

namespace TicTacToe.Services {
    public class GameService
    {
        private readonly List<Game> _games = new();

        public Game CreateNewGame() {
            var game = new Game();
            game.InitializeGameBoard();
            _games.Add(game);
            return game;
        }

        private Game GetGameById(Guid id) {
            return _games.FirstOrDefault(g => g.Id == id);
        }

        public Game MakeMove(int squareNumber, Guid id) {
            if(GetGameById(id).MakeMove(squareNumber)) {
                return GetGameById(id);
            }
            throw new Exception("That square has already been played");
        }

        public string CheckWinner(Guid id) {
            return GetGameById(id).CheckWinner();
        }
    }
}