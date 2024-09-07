using CommandSystem;
using System.Collections.Generic;

namespace GuardRevamp
{
    public static class CommandManager
    {
        private static readonly List<ICommand> registeredCommands = new List<ICommand>();

        // Register a new command
        public static void RegisterCommand(ICommand command)
        {
            if (!registeredCommands.Contains(command))
            {
                // Register the command in your system
                registeredCommands.Add(command);
            }
        }

        // Unregister a command
        public static void UnregisterCommand(ICommand command)
        {
            if (registeredCommands.Contains(command))
            {
                // Unregister the command from your system
                registeredCommands.Remove(command);
            }
        }

        // Unregister all commands (useful for disabling the plugin)
        public static void UnregisterAllCommands()
        {
            // Unregister each command
            registeredCommands.Clear();
        }
    }
}
