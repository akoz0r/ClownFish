﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using GameServerInterfaces;
using GameServerInterfaces.Enums;

namespace GameServer.GameService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChessGameService : IChessGameService
    {
        private List<Game> CurrentGames { get; set; }

        public ChessGameService()
        {
            CurrentGames = new List<Game>();
            Task.Run(() => KeepConnectionsAliveLoop());
        }

        private void KeepConnectionsAliveLoop()
        {
            while (true)
            {
                Task.Delay(30 * 1000);
                foreach (var client in CurrentGames.SelectMany(g => g.Listeners))
                {
                    try
                    {
                        client.Ping();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        try
                        {
                            var games = CurrentGames.Where(g => g.Listeners.Any(l => l == client));
                            foreach (var game in games)
                            {
                                game.Listeners.Remove(client);
                            }
                        }
                        catch (Exception ex2)
                        {
                            Console.WriteLine(ex2.Message);
                        }
                    }
                }
            }
        }

        public List<ChessGameDTO> GetGames()
        {
            return CurrentGames.Select(game => game.MapToDTO()).ToList();
        }

        public ChessGameDTO CreateGame(string playerName, ColorEnum ownColorEnum, TimeSpan startTimePerPlayer, TimeSpan extraTimePerMove)
        {
            var game = new Game(playerName, ownColorEnum, startTimePerPlayer, extraTimePerMove);
            CurrentGames.Add(game);
            return game.MapToDTO();
        }

        public void Subscribe(string gameID)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IClientCallbackInterface>();
            var game = CurrentGames.SingleOrDefault(g => g.GameID == gameID);
            if (game != null)
            {
                if (!game.Listeners.Contains(callback))
                    game.Listeners.Add(callback);
            }
        }

        public bool JoinGame(string gameID, string playerName)
        {
            lock (this)
            {
                var matchingGame = CurrentGames.FirstOrDefault(game => game.GameID == gameID && game.GameState == GameState.WaitingForPlayer);
                if (matchingGame != null)
                {
                    matchingGame.PlayerJoining(playerName);
                    SendUpdates(matchingGame);
                    return true;
                }
            }
            return false;
        }

        public bool MakeMove(string gameID, GameMoveDTO moveDTO)
        {
            var matchingGame = CurrentGames.SingleOrDefault(game => game.GameID == gameID);
            if (matchingGame != null)
            {
                try
                {
                    matchingGame.MakeMove(moveDTO);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return false;
        }

        private void SendUpdates(Game game)
        {
            Task.Run(() =>
            {
                foreach (var client in game.Listeners)
                {
                    try
                    {
                        client.GameStateChanged(game.Moves.LastOrDefault(), game.MapToDTO());
                    }
                    catch (Exception ex)
                    {
                        game.Listeners.Remove(client);
                        Debug.WriteLine(ex.Message);
                    }
                }

            });
        }
    }
}
