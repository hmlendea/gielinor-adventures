using System.Collections.Generic;
using System.Linq;

using GielinorAdventures.DataAccess.DataObjects;
using GielinorAdventures.Models;
using GielinorAdventures.Models.Enumerations;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.GameLogic.Mapping
{
    /// <summary>
    /// Player mapping extensions for converting between entities and domain models.
    /// </summary>
    static class PlayerMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="playerEntity">Player entity.</param>
        internal static Player ToDomainModel(this PlayerEntity playerEntity)
        {
            Player player = new Player
            {
                Id = playerEntity.Id,
                Name = playerEntity.Name,
                World = playerEntity.World,
                Location = new Point2D(playerEntity.LocationX, playerEntity.LocationY),
                Energy = playerEntity.Energy,
                CombatStyle = (CombatStyle)playerEntity.CombatStyle,

                Bank = playerEntity.Bank.ToDomainModels(),
                Inventory = playerEntity.Inventory.ToDomainModels(),

                AttackSkill = new Skill(
                    playerEntity.AttackLevelCurrent,
                    playerEntity.AttackLevelBase,
                    playerEntity.AttackExperience),
                HitpointsSkill = new Skill(
                    playerEntity.HitpointsLevelCurrent,
                    playerEntity.HitpointsLevelBase,
                    playerEntity.HitpointsExperience),
                MiningSkill = new Skill(
                    playerEntity.MiningLevelCurrent,
                    playerEntity.MiningLevelBase,
                    playerEntity.MiningExperience),
                StrengthSkill = new Skill(
                    playerEntity.StrengthLevelCurrent,
                    playerEntity.StrengthLevelBase,
                    playerEntity.StrengthExperience),
                AgilitySkill = new Skill(
                    playerEntity.AgilityLevelCurrent,
                    playerEntity.AgilityLevelBase,
                    playerEntity.AgilityExperience),
                SmithingSkill = new Skill(
                    playerEntity.SmithingLevelCurrent,
                    playerEntity.SmithingLevelBase,
                    playerEntity.SmithingExperience),
                DefenceSkill = new Skill(
                    playerEntity.DefenceLevelCurrent,
                    playerEntity.DefenceLevelBase,
                    playerEntity.DefenceExperience),
                HerbloreSkill = new Skill(
                    playerEntity.HerbloreLevelCurrent,
                    playerEntity.HerbloreLevelBase,
                    playerEntity.HerbloreExperience),
                FishingSkill = new Skill(
                    playerEntity.FishingLevelCurrent,
                    playerEntity.FishingLevelBase,
                    playerEntity.FishingExperience),
                RangedSkill = new Skill(
                    playerEntity.RangedLevelCurrent,
                    playerEntity.RangedLevelBase,
                    playerEntity.RangedExperience),
                ThievingSkill = new Skill(
                    playerEntity.ThievingLevelCurrent,
                    playerEntity.ThievingLevelBase,
                    playerEntity.ThievingExperience),
                CookingSkill = new Skill(
                    playerEntity.CookingLevelCurrent,
                    playerEntity.CookingLevelBase,
                    playerEntity.CookingExperience),
                PrayerSkill = new Skill(
                    playerEntity.PrayerLevelCurrent,
                    playerEntity.PrayerLevelBase,
                    playerEntity.PrayerExperience),
                CraftingSkill = new Skill(
                    playerEntity.CraftingLevelCurrent,
                    playerEntity.CraftingLevelBase,
                    playerEntity.CraftingExperience),
                FiremakingSkill = new Skill(
                    playerEntity.FiremakingLevelCurrent,
                    playerEntity.FiremakingLevelBase,
                    playerEntity.FiremakingExperience),
                MagicSkill = new Skill(
                    playerEntity.MagicLevelCurrent,
                    playerEntity.MagicLevelBase,
                    playerEntity.MagicExperience),
                FletchingSkill = new Skill(
                    playerEntity.FletchingLevelCurrent,
                    playerEntity.FletchingLevelBase,
                    playerEntity.FletchingExperience),
                WoodcuttingSkill = new Skill(
                    playerEntity.WoodcuttingLevelCurrent,
                    playerEntity.WoodcuttingLevelBase,
                    playerEntity.WoodcuttingExperience)
            };

            return player;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="player">Player.</param>
        internal static PlayerEntity ToEntity(this Player player)
        {
            PlayerEntity playerEntity = new PlayerEntity
            {
                Id = player.Id,
                Name = player.Name,
                World = player.World,
                LocationX = player.Location.X,
                LocationY = player.Location.Y,
                Energy = player.Energy,
                CombatStyle = (int)player.CombatStyle,

                Bank = player.Bank.ToEntities().ToList(),
                Inventory = player.Inventory.ToEntities().ToList(),

                AttackLevelCurrent = player.AttackSkill.CurrentLevel,
                AttackLevelBase = player.AttackSkill.BaseLevel,
                AttackExperience = player.AttackSkill.Experience,

                HitpointsLevelCurrent = player.HitpointsSkill.CurrentLevel,
                HitpointsLevelBase = player.HitpointsSkill.BaseLevel,
                HitpointsExperience = player.HitpointsSkill.Experience,

                MiningLevelCurrent = player.MiningSkill.CurrentLevel,
                MiningLevelBase = player.MiningSkill.BaseLevel,
                MiningExperience = player.MiningSkill.Experience,

                StrengthLevelCurrent = player.StrengthSkill.CurrentLevel,
                StrengthLevelBase = player.StrengthSkill.BaseLevel,
                StrengthExperience = player.StrengthSkill.Experience,

                AgilityLevelCurrent = player.AgilitySkill.CurrentLevel,
                AgilityLevelBase = player.AgilitySkill.BaseLevel,
                AgilityExperience = player.AgilitySkill.Experience,

                SmithingLevelCurrent = player.SmithingSkill.CurrentLevel,
                SmithingLevelBase = player.SmithingSkill.BaseLevel,
                SmithingExperience = player.SmithingSkill.Experience,

                DefenceLevelCurrent = player.DefenceSkill.CurrentLevel,
                DefenceLevelBase = player.DefenceSkill.BaseLevel,
                DefenceExperience = player.DefenceSkill.Experience,

                HerbloreLevelCurrent = player.HerbloreSkill.CurrentLevel,
                HerbloreLevelBase = player.HerbloreSkill.BaseLevel,
                HerbloreExperience = player.HerbloreSkill.Experience,

                FishingLevelCurrent = player.FishingSkill.CurrentLevel,
                FishingLevelBase = player.FishingSkill.BaseLevel,
                FishingExperience = player.FishingSkill.Experience,

                RangedLevelCurrent = player.RangedSkill.CurrentLevel,
                RangedLevelBase = player.RangedSkill.BaseLevel,
                RangedExperience = player.RangedSkill.Experience,

                ThievingLevelCurrent = player.ThievingSkill.CurrentLevel,
                ThievingLevelBase = player.ThievingSkill.BaseLevel,
                ThievingExperience = player.ThievingSkill.Experience,

                CookingLevelCurrent = player.CookingSkill.CurrentLevel,
                CookingLevelBase = player.CookingSkill.BaseLevel,
                CookingExperience = player.CookingSkill.Experience,

                PrayerLevelCurrent = player.PrayerSkill.CurrentLevel,
                PrayerLevelBase = player.PrayerSkill.BaseLevel,
                PrayerExperience = player.PrayerSkill.Experience,

                CraftingLevelCurrent = player.CraftingSkill.CurrentLevel,
                CraftingLevelBase = player.CraftingSkill.BaseLevel,
                CraftingExperience = player.CraftingSkill.Experience,

                FiremakingLevelCurrent = player.FiremakingSkill.CurrentLevel,
                FiremakingLevelBase = player.FiremakingSkill.BaseLevel,
                FiremakingExperience = player.FiremakingSkill.Experience,

                MagicLevelCurrent = player.MagicSkill.CurrentLevel,
                MagicLevelBase = player.MagicSkill.BaseLevel,
                MagicExperience = player.MagicSkill.Experience,

                FletchingLevelCurrent = player.FletchingSkill.CurrentLevel,
                FletchingLevelBase = player.FletchingSkill.BaseLevel,
                FletchingExperience = player.FletchingSkill.Experience,

                WoodcuttingLevelCurrent = player.WoodcuttingSkill.CurrentLevel,
                WoodcuttingLevelBase = player.WoodcuttingSkill.BaseLevel,
                WoodcuttingExperience = player.WoodcuttingSkill.Experience
            };

            return playerEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="playerEntities">Player entities.</param>
        internal static IEnumerable<Player> ToDomainModels(this IEnumerable<PlayerEntity> playerEntities)
        {
            IEnumerable<Player> players = playerEntities.Select(playerEntity => playerEntity.ToDomainModel());

            return players;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="players">Players.</param>
        internal static IEnumerable<PlayerEntity> ToEntities(this IEnumerable<Player> players)
        {
            IEnumerable<PlayerEntity> playerEntities = players.Select(player => player.ToEntity());

            return playerEntities;
        }
    }
}
