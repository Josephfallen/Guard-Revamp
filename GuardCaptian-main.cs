using System;
using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using Exiled.Events;
using ServerEvent = Exiled.Events.Handlers.Server;
using GuardRevamp.Commands;

namespace GuardRevamp
{
    public class GuardCaptainPlugin : Plugin<Configs.Config>
    {
        public override string Name { get; } = "Guard Revamp";
        public override string Author { get; } = "Joseph_fallen";
        public override string Prefix { get; } = "GuardRevamp";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);

        public static GuardCaptainPlugin Instance;

        private EventHandlers eventHandlers;

        public override void OnEnabled()
        {
            Instance = this;

            // Register the Guard Captain role
            Config.GuardCaptain.Register();

            // Register event handlers
            eventHandlers = new EventHandlers();
            ServerEvent.RoundStarted += eventHandlers.OnRoundStarted;

            // Register commands
            CommandManager.RegisterCommand(new ForceCaptain()); // Register command

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            // Unregister roles and events
            CustomRole.UnregisterRoles();
            ServerEvent.RoundStarted -= eventHandlers.OnRoundStarted;

            // Unregister commands
            CommandManager.UnregisterCommand(new ForceCaptain()); // Unregister command

            eventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}
