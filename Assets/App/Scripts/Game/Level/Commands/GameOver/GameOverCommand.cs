using App.Scripts.Libs.Patterns.Command.Default;
using UnityEngine;

namespace App.Scripts.Game.Level.Commands.GameOver
{
    public class GameOverCommand : ICommand
    {
        public void Execute()
        {
            Debug.Log("GameOverCommand::Execute");
        }
    }
}