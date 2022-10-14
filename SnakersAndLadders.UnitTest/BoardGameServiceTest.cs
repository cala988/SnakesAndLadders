using FluentAssertions;
using SnakesAndLadders.Application.Entitites;
using SnakesAndLadders.Application.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SnakersAndLadders.UnitTest
{
    public class BoardGameServiceTest
    {
        private readonly BoardGameService _boardGameService;

        public BoardGameServiceTest()
        {
            _boardGameService = new BoardGameService();
        }


        /// <summary>
        /// US1/UAT1
        /// Given the game is started
        /// When the token is placed on the board
        /// Then the token is on square 1
        /// </summary>
        [Fact]
        public void TestStartGameWithFirstPosition()
        {
            const int NumberOfPlayers = 3;
            const int ExpectedResult = 1;

            _boardGameService.Start(NumberOfPlayers);

            List<Player> players = _boardGameService.GetPlayers();

            foreach(Player player in players)
            {
                var position = _boardGameService.GetTokenPositionOfPlayer(player);

                position.Should().Be(ExpectedResult);
            }
        }
    }
}