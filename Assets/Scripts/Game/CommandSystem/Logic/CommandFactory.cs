using System;
using Game.CommandSystem.Logic.Commands;
using UnityEngine;

namespace Game.CommandSystem.Logic
{
    public class CommandFactory
    {
        private Character character;
        
        public CommandFactory(Character character)
        {
            this.character = character;
        }
        
        public Command CreateCommand(Type type)
        {
            Command command = new WalkCommand(character); //what should be done about this?

            if (type == typeof(WalkCommand))
            {
                command = new WalkCommand(character);
            }
            else if (type == typeof(LightCommand))
            {
                command = new LightCommand(character);
            }
            else if (type == typeof(TurnLeftCommand))
            {
                command = new TurnLeftCommand(character);
            }
            else if (type == typeof(TurnRightCommand))
            {
                command = new TurnRightCommand(character);
            }
            else if (type == typeof(JumpCommand))
            {
                command = new JumpCommand(character);
            }
            else
            {
                Debug.LogError("Unknown Command");
            }

            return command;
        }
    }
}
