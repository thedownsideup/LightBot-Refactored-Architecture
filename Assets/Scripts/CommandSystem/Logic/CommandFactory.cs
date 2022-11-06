using System;
using CommandSystem.Logic.Commands;
using UnityEngine;

namespace CommandSystem.Logic
{
    public class CommandFactory
    {
        private Character.Character character;
        
        public CommandFactory(Character.Character character)
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
        
        //How about this instead?
        
        public T Create<T>() where T : Command
        {
            return (T)Activator.CreateInstance(typeof(T), character);
        }
    }
}
