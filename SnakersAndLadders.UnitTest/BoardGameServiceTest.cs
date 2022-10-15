using FluentAssertions;
using SnakesAndLadders.Application.Entitites;
using SnakesAndLadders.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
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

            foreach (Player player in players)
            {
                var position = _boardGameService.GetTokenPositionOfPlayer(player);

                position.Should().Be(ExpectedResult);
            }
        }

        /// <summary>
        /// US1/UAT2
        /// Given the token is on square 1
        /// When the token is moved 3 spaces
        /// Then the token is on square 4
        /// <summary>
        [Fact]
        public void TestMoveToken3Spaces()
        {
            const int NumberOfPlayers = 2;
            const int PlayerToMove = 1;
            const int PositionsToMove = 3;
            const int ExpectedResult = 4;

            _boardGameService.Start(NumberOfPlayers);

            Player PlayerOne = _boardGameService.GetPlayer(PlayerToMove);

            PlayerOne = _boardGameService.MoveTokenPosition(PlayerOne, PositionsToMove);

            var positionOfPlayerOne = _boardGameService.GetTokenPositionOfPlayer(PlayerOne);

            positionOfPlayerOne.Should().Be(ExpectedResult);

        }

        /// <summary>
        /// US1/UAT3
        /// Given the token is on square 1
        /// When the token is moved 3 spaces
        /// And then it is moved 4 spaces
        /// Then the token is on square 8
        /// <summary>
        [Fact]
        public void TestMoveToken2Times()
        {
            const int NumberOfPlayers = 2;
            const int PlayerToMove = 1;
            const int FirstPositionsToMove = 3;
            const int SecondPositionsToMove = 4;
            const int ExpectedResult = 8;

            _boardGameService.Start(NumberOfPlayers);

            Player PlayerOne = _boardGameService.GetPlayer(PlayerToMove);

            PlayerOne = _boardGameService.MoveTokenPosition(PlayerOne, FirstPositionsToMove);
            PlayerOne = _boardGameService.MoveTokenPosition(PlayerOne, SecondPositionsToMove);

            var positionOfPlayerOne = _boardGameService.GetTokenPositionOfPlayer(PlayerOne);

            positionOfPlayerOne.Should().Be(ExpectedResult);
        }


        /// <summary>
        /// US2/UAT1
        /// Given the token is on square 97
        /// When the token is moved 3 spaces
        /// Then the token is on square 100
        /// And the player has won the game
        /// </summary>
        /// <summary>
        [Fact]
        public void TestPlayerWinTheGame()
        {
            const int NumberOfPlayers = 2;
            const int PlayerToMove = 1;
            const int ActualSquare = 97;

            _boardGameService.Start(NumberOfPlayers);
            Player PlayerOne = _boardGameService.GetPlayer(PlayerToMove);
            PlayerOne.Token.Position = ActualSquare;

            PlayerOne = _boardGameService.MoveTokenPosition(PlayerOne, 3);

            bool playerOneWin = _boardGameService.CheckIfThePlayerWonTheGame(PlayerOne);

            playerOneWin.Should().BeTrue();

        }
    }
}