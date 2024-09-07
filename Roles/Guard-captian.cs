using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System.Collections.Generic;

namespace GuardRevamp.Roles
{
    [CustomRole(RoleTypeId.FacilityGuard)]
    public class GuardCaptain : CustomRole
    {
        public override uint Id { get; set; } = 120;
        public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;
        public override int MaxHealth { get; set; } = 110;
        public override string Name { get; set; } = "Guard Captain";
        public override string Description { get; set; } = "The leader of the Facility Guards, tasked with maintaining site security.";
        public override string CustomInfo { get; set; } = "Guard Captain";
        public override bool IgnoreSpawnSystem { get; set; } = true;

        public override List<string> Inventory { get; set; } = new List<string>
        {
            ItemType.KeycardMTFPrivate.ToString(),
            ItemType.GunE11SR.ToString(),
            ItemType.GrenadeHE.ToString(),
            ItemType.Radio.ToString(),
            ItemType.ArmorCombat.ToString()
        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>
        {
            { AmmoType.Nato556, 90 },
            { AmmoType.Nato9, 60 }
        };

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            RoleSpawnPoints = new List<RoleSpawnPoint>
            {
                new RoleSpawnPoint
                {
                    Role = RoleTypeId.FacilityGuard,
                    Chance = 100
                }
            }
        };
    }
}
