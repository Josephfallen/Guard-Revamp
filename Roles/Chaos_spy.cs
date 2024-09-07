using System.Collections.Generic;
using Exiled.CustomRoles.API.Features;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using PlayerRoles;

namespace GuardRevamp.Roles
{
    public class ChaosSpy : CustomRole
    {
        public override uint Id { get; set; } = 210;
        public override RoleTypeId Role { get; set; } = RoleTypeId.ChaosConscript;
        public override int MaxHealth { get; set; } = 100;
        public override string Name { get; set; } = "Chaos Spy";
        public override string Description { get; set; } = "A member of the Chaos Insurgency, tasked with gathering intelligence.";
        public override string CustomInfo { get; set; } = "Chaos Spy";
        public override bool IgnoreSpawnSystem { get; set; } = true;

        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.KeycardChaosInsurgency}",
            $"{ItemType.GunCOM15}",
            $"{ItemType.Medkit}"
        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>
        {
            { AmmoType.Nato9, 60 },
        };

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            RoleSpawnPoints = new List<RoleSpawnPoint>
            {
                new RoleSpawnPoint
                {
                    Role = RoleTypeId.ChaosConscript,
                    Chance = 100
                }
            }
        };
    }
}
