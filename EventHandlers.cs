using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MEC;
using PlayerRoles;
using Respawning;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuardRevamp
{
    internal sealed class EventHandlers
    {
        private int Respawns = 0;
        private CoroutineHandle calculationCoroutine;

        public void OnRoundStarted()
        {
            Respawns = 0;

            if (calculationCoroutine.IsRunning)
                Timing.KillCoroutines(calculationCoroutine);

            calculationCoroutine = Timing.RunCoroutine(SpawnCalculation());
        }

        private IEnumerator<float> SpawnCalculation()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(1f);

                if (Round.IsEnded)
                    break;

                // Check if a spawn wave is about to happen.
                if (Math.Round(Respawn.TimeUntilSpawnWave.TotalSeconds, 0) != GuardCaptainPlugin.Instance.Config.SpawnWaveCalculation)
                    continue;

                if (Respawn.NextKnownTeam == SpawnableTeamType.NineTailedFox)
                {
                    // Ensure Guard Captain spawns, replacing one Facility Guard.
                    var facilityGuards = Player.List.Where(p => p.Role == RoleTypeId.FacilityGuard).ToList();
                    if (facilityGuards.Any())
                    {
                        var guardToReplace = facilityGuards.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                        if (guardToReplace != null)
                        {
                            GuardCaptainPlugin.Instance.Config.GuardCaptain.AddRole(guardToReplace);
                        }
                    }
                }
            }
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            // Check if it's time to replace a guard with Guard Captain.
            if (ev.NextKnownTeam == SpawnableTeamType.NineTailedFox)
            {
                List<Player> guards = new List<Player>(ev.Players);
                Player captainCandidate = guards.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                if (captainCandidate != null)
                {
                    ev.Players.Remove(captainCandidate);
                    GuardCaptainPlugin.Instance.Config.GuardCaptain.AddRole(captainCandidate);
                }
            }

            Respawns++;
        }
    }
}
