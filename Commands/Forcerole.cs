using CommandSystem;

using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace GuardRevamp.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ForceCaptain : ICommand
    {
        public string Command => "forcecaptain";
        public string[] Aliases => new[] { "fcaptain" };
        public string Description => "Forces a player to become the Guard Captain.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("guardrevamp.forcecaptain"))
            {
                response = "You don't have permission to run this command.";
                return false;
            }

            if (arguments.Count != 1)
            {
                response = "Usage: forcecaptain <player>";
                return false;
            }

            Player target = Player.Get(arguments.At(0));
            if (target == null)
            {
                response = "Player not found.";
                return false;
            }

            GuardCaptainPlugin.Instance.Config.GuardCaptain.AddRole(target);
            response = $"Player {target.Nickname} is now the Guard Captain.";
            return true;
        }
    }
}
