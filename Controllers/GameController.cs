using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;
using TicTacToe.Services;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    public GameController(GameService gameService) {
        _gameService = gameService;
    }

    [HttpGet]
    public ActionResult<Game> Get()
    {
        var game = _gameService.CreateNewGame();
        return Ok(game);
    }

    [HttpPost]
    public ActionResult<Game> Post([FromBody] CreateGameRequest request)
    {
        try
        {
            var game = _gameService.MakeMove(request.SquareNumber, request.Id);
            var winner = _gameService.CheckWinner(game.Id);
            GameResponse response = new GameResponse
            {
                Id = game.Id,
                gameBoard = game.gameBoard,
                IsOver = false,
                Winner = ""
            };

            if (winner != "")
            {
                response.IsOver = true;
                response.Winner = winner;
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}