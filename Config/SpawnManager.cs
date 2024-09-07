using System.ComponentModel;

namespace GuardRevamp.Configs
{
    public class SpawnManager
    {
        [Description("The number of respawn waves before the Guard Captain spawns (set to 0 for immediate spawn).")]
        public int Respawns { get; private set; } = 0;

        [Description("The maximum number of Guard Captains allowed per game.")]
        public int MaxSpawns { get; set; } = 1;

        [Description("Probability of the Guard Captain replacing a Facility Guard on spawn.")]
        public int Probability { get; private set; } = 100;  // 100% chance to replace a guard.

        [Description("The maximum size of a Guard Captain squad.")]
        public int MaxSquad { get; private set; } = 1;
    }
}
