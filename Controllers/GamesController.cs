using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicToeAPI.Models;
using TicToeAPI.Data;
using System.Net;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TicToeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
            private readonly AppDbContext dbContext;

            public GamesController(AppDbContext context)
            {
                dbContext = context;
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Game>>> GetGames()
            {
                return await dbContext.TicToeGames.ToListAsync();
             }

            [HttpPost]
            public ActionResult<Game> Create()
            {
            Random rnd = new Random();
            var game = new Game
            {      
                    Board = "000000000",
                    CurrentPlayer = 1,
                    IsOver = false,
                    Winner = 0
            };

                dbContext.TicToeGames.Add(game);
                dbContext.SaveChanges();

                return game;
            }

            [HttpGet("{id}")]
            public ActionResult<Game> Get(int id)
            {
                var game = dbContext.TicToeGames.Find(id);

                if (game == null)
                {
                    return NotFound();
                }

                return game;
            }

            [HttpPut("{id}")]
            public ActionResult<Game> Play(int id, int positionFromNullToEight)
            {
                var game = dbContext.TicToeGames.Find(id);

                if (game == null)
                {
                    return NotFound("There is no game with this id");
                }
                if (game.IsOver==true)
                {
                    if (game.Winner == 0)
                        return BadRequest("This game ended in a draw. Start a new game.");
                    return BadRequest($"This game's over. {game.Winner} player won. Start a new game.");
                }
                if (positionFromNullToEight>8 || positionFromNullToEight < 0)
                {
                    return BadRequest("Error: Wrong move");
                }
                var board = game.Board.ToCharArray();
                if (board[positionFromNullToEight] != '0')
                {
                    return BadRequest("Error: This move already taken");
                }
                board[positionFromNullToEight] = game.CurrentPlayer == 1 ? 'X' : 'O';
                game.Board = new string(board);
                //Проверяем завершена ли игра по горизонтали
                if ((board[0] == board[1] && board[1]== board[2] && board[2]!='0')
                      || (board[3] == board[4] && board[4] == board[5] && board[5] != '0')
                      || (board[6] == board[7] && board[7] == board[8] && board[8] != '0'))
                {
                    game.IsOver = true;
                    game.Winner = game.CurrentPlayer; 
                }
                //Проверяем завершена ли игра по диагонали
                if ((board[0] == board[3] && board[3] == board[6] && board[6] != '0')
                  || (board[1] == board[4] && board[4] == board[7] && board[7] != '0')
                  || (board[2] == board[5] && board[5] == board[8] && board[8] != '0'))
                {
                    game.IsOver = true;
                    game.Winner = game.CurrentPlayer;
                }
                int end = 0;
                //Проверяем есть ли еще ходы или игра завершена в ничью
                foreach (char i in board)
                { 
                   if (i == '0') end ++;
                 }
                if (end == 0)
                {
                    game.IsOver = true; 
                }

            game.CurrentPlayer = game.CurrentPlayer == 1 ? 2 : 1;
            dbContext.SaveChanges();

                return game;
            }
            
    }

}

