﻿using SnakesAndLadders.Application.Entitites;

namespace SnakesAndLadders.Application.Interfaces
{
    public interface IBoardGameService
    {
        public void Start(int numberOfPlayers);

        public List<Player> GetPlayers();

        public int GetTokenPositionOfPlayer(Player player);

        public Player MoveTokenPosition(Player player, int position);

        public Player GetPlayer(int playerNumber);

        public bool CheckIfThePlayerWonTheGame(Player player);
    }
}