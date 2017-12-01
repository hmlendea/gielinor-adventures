using GielinorAdventures.Models.Enumerations;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.Models
{
    public class Player
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string World { get; set; }

        public Point2D Location { get; set; }

        public int Energy { get; set; }

        public CombatStyle CombatStyle { get; set; }

        public Skill AttackSkill { get; set; }
        public Skill HitpointsSkill { get; set; }
        public Skill MiningSkill { get; set; }
        public Skill StrengthSkill { get; set; }
        public Skill AgilitySkill { get; set; }
        public Skill SmithingSkill { get; set; }
        public Skill DefenceSkill { get; set; }
        public Skill HerbloreSkill { get; set; }
        public Skill FishingSkill { get; set; }
        public Skill RangedSkill { get; set; }
        public Skill ThievingSkill { get; set; }
        public Skill CookingSkill { get; set; }
        public Skill PrayerSkill { get; set; }
        public Skill CraftingSkill { get; set; }
        public Skill FiremakingSkill { get; set; }
        public Skill MagicSkill { get; set; }
        public Skill FletchingSkill { get; set; }
        public Skill WoodcuttingSkill { get; set; }

        public int CombatLevel
        {
            get
            {
                double attack = AttackSkill.BaseLevel + StrengthSkill.BaseLevel;
                double defense = DefenceSkill.BaseLevel + HitpointsSkill.BaseLevel;
                double mage = (PrayerSkill.BaseLevel + MagicSkill.BaseLevel) / 8D;


                if (attack < (RangedSkill.BaseLevel * 1.5D))
                {
                    return (int)((defense / 4D) + (RangedSkill.BaseLevel * 0.375D) + mage);
                }

                return (int)((attack / 4D) + (defense / 4D) + mage);
            }
        }
    }
}
