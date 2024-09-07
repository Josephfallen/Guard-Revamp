using System.ComponentModel;
using Exiled.API.Interfaces;
using GuardRevamp.Roles;

namespace GuardRevamp.Configs
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug messages be shown in the server console.")]
        public bool Debug { get; set; } = false;

        [Description("How many seconds before a spawn wave occurs should it calculate the spawn chance.")]
        public int SpawnWaveCalculation { get; set; } = 10;

        [Description("Options for Guard Captain spawn:")]
        public SpawnManager SpawnManager { get; private set; } = new SpawnManager();

        [Description("Options for Guard Captain:")]
        public GuardCaptain GuardCaptain { get; private set; } = new GuardCaptain();
    }
}
