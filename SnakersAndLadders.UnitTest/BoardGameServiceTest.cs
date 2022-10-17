using FluentAssertions;
using Moq;
using SnakesAndLadders.Application.Entitites;
using SnakesAndLadders.Application.Interfaces;
using SnakesAndLadders.Application.Services;
using System.Collections.Generic;
using Xunit;

namespace SnakersAndLadders.UnitTest
{
    public class BoardGameServiceTest
    {
        private readonly IBoardGameService _boardGameService;

        public BoardGameServiceTest()
        {
            _boardGameService = new BoardGameService(new DieService());
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

            PlayerOne = _boardGameService.MovePlayerTokenPosition(PlayerOne, PositionsToMove);

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

            PlayerOne = _boardGameService.MovePlayerTokenPosition(PlayerOne, FirstPositionsToMove);
            PlayerOne = _boardGameService.MovePlayerTokenPosition(PlayerOne, SecondPositionsToMove);

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
            const int SquaresToMove = 3;

            _boardGameService.Start(NumberOfPlayers);
            Player PlayerOne = _boardGameService.GetPlayer(PlayerToMove);
            PlayerOne.Token.Position = ActualSquare;

            PlayerOne = _boardGameService.MovePlayerTokenPosition(PlayerOne, SquaresToMove);

            bool playerOneWin = _boardGameService.CheckIfThePlayerWonTheGame(PlayerOne);

            playerOneWin.Should().BeTrue();
        }


        /// <summary>
        /// US2/UAT2
        /// Given the token is on square 97
        /// When the token is moved 4 spaces
        /// Then the token is on square 97
        /// And the player has not won the game
        /// <summary>
        [Fact]
        public void TestPlayerIsInSamePositionAndNotWinTheGame()
        {
            const int NumberOfPlayers = 2;
            const int PlayerToMove = 1;
            const int InitialSquarePosition = 97;
            const int SquaresToMove = 4;

            _boardGameService.Start(NumberOfPlayers);
            Player PlayerOne = _boardGameService.GetPlayer(PlayerToMove);
            PlayerOne.Token.Position = InitialSquarePosition;

            PlayerOne = _boardGameService.MovePlayerTokenPosition(PlayerOne, SquaresToMove);

            PlayerOne.Token.Position.Should().Be(InitialSquarePosition);

            bool playerOneWin = _boardGameService.CheckIfThePlayerWonTheGame(PlayerOne);

            playerOneWin.Should().BeFalse();
        }

        /// <summary>
        /// US3/UAT1
        /// Given the game is started
        /// When the player rolls a die
        /// Then the result should be between 1-6 inclusiveGiven the game is started
        /// <summary>
        [Fact]
        public void TestRollDieBetweenTwoNumbers()
        {
            const int NumberOfPlayers = 2;
            const int MinimunNumber = 1;
            const int MaximunNumber = 6;

            _boardGameService.Start(NumberOfPlayers);

            for (int i = 0; i < 100; i++)
            {
                int number = _boardGameService.RollDie();
                number.Should().BeInRange(MinimunNumber, MaximunNumber);
            }
        }

        /// <summary>
        /// US3/UAT2
        /// Given the player rolls a 4
        /// When they move their token
        /// Then the token should move 4 spaces
        /// </summary>
        [Fact]
        public void TestRollDieTwoMovements()
        {
            const int NumberOfPlayers = 2;
            const int rollNumer = 4;
            const int ExpectedResult = 5;
            const int PlayerOne = 1;

            var mockDieService = new Mock<IDieService>();
            mockDieService.Setup(x => x.Roll()).Returns(rollNumer);
            var gameService = new BoardGameService(mockDieService.Object);
            
            gameService.Start(NumberOfPlayers);
            var playerOne = gameService.GetPlayer(PlayerOne);

            gameService.PlayGameTurn(playerOne);

            var player = gameService.GetPlayer(PlayerOne);

            player.GetTokenPosition().Should().Be(ExpectedResult);
        }


        [Fact]
        public void TestTokenIsInSnakePosition()
        {
            const int NumberOfPlayers = 2;
            const int SnakePosition = 16;
            const int PlayerToMove = 1;
            const int FinalSnakePosition = 6;

            _boardGameService.Start(NumberOfPlayers);
            var player = _boardGameService.GetPlayer(PlayerToMove);
            player = _boardGameService.MovePlayerTokenPosition(player, SnakePosition);

            player.GetTokenPosition().Should().Be(FinalSnakePosition);
        }

    }
}