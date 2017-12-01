using GielinorAdventures.GameLogic.GameManagers;
using GielinorAdventures.Models;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiSkillsPanel : GuiElement
    {
        IGameManager game;

        GuiSkillCard attackCard;
        GuiSkillCard hitpointsCard;
        GuiSkillCard miningCard;
        GuiSkillCard strengthCard;
        GuiSkillCard agilityCard;
        GuiSkillCard smithingCard;
        GuiSkillCard defenceCard;
        GuiSkillCard herbloreCard;
        GuiSkillCard fishingCard;
        GuiSkillCard rangedCard;
        GuiSkillCard thievingCard;
        GuiSkillCard cookingCard;
        GuiSkillCard prayerCard;
        GuiSkillCard craftingCard;
        GuiSkillCard firemakingCard;
        GuiSkillCard magicCard;
        GuiSkillCard fletchingCard;
        GuiSkillCard woodcuttingCard;

        public override void LoadContent()
        {
            attackCard = new GuiSkillCard { SkillIcon = "Icons/Skills/attack" };
            hitpointsCard = new GuiSkillCard { SkillIcon = "Icons/Skills/health" };
            miningCard = new GuiSkillCard { SkillIcon = "Icons/Skills/mining" };
            strengthCard = new GuiSkillCard { SkillIcon = "Icons/Skills/strength" };
            agilityCard = new GuiSkillCard { SkillIcon = "Icons/Skills/agility" };
            smithingCard = new GuiSkillCard { SkillIcon = "Icons/Skills/smithing" };
            defenceCard = new GuiSkillCard { SkillIcon = "Icons/Skills/defence" };
            herbloreCard = new GuiSkillCard { SkillIcon = "Icons/Skills/herblore" };
            fishingCard = new GuiSkillCard { SkillIcon = "Icons/Skills/fishing" };
            rangedCard = new GuiSkillCard { SkillIcon = "Icons/Skills/ranged" };
            thievingCard = new GuiSkillCard { SkillIcon = "Icons/Skills/thieving" };
            cookingCard = new GuiSkillCard { SkillIcon = "Icons/Skills/cooking" };
            prayerCard = new GuiSkillCard { SkillIcon = "Icons/Skills/prayer" };
            craftingCard = new GuiSkillCard { SkillIcon = "Icons/Skills/crafting" };
            firemakingCard = new GuiSkillCard { SkillIcon = "Icons/Skills/firemaking" };
            magicCard = new GuiSkillCard { SkillIcon = "Icons/Skills/magic" };
            fletchingCard = new GuiSkillCard { SkillIcon = "Icons/Skills/fletching" };
            woodcuttingCard = new GuiSkillCard { SkillIcon = "Icons/Skills/woodcutting" };

            Children.Add(attackCard);
            Children.Add(hitpointsCard);
            Children.Add(miningCard);
            Children.Add(strengthCard);
            Children.Add(agilityCard);
            Children.Add(smithingCard);
            Children.Add(defenceCard);
            Children.Add(herbloreCard);
            Children.Add(fishingCard);
            Children.Add(rangedCard);
            Children.Add(thievingCard);
            Children.Add(cookingCard);
            Children.Add(prayerCard);
            Children.Add(craftingCard);
            Children.Add(firemakingCard);
            Children.Add(magicCard);
            Children.Add(fletchingCard);
            Children.Add(woodcuttingCard);

            base.LoadContent();
        }

        public void AssociateGameManager(IGameManager game)
        {
            this.game = game;
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            int spacingX = 1;
            int spacingY = 1;

            // TODO: Ugly fix
            if (game == null)
            {
                return;
            }

            Player player = game.GetPlayer();

            attackCard.CurrentLevel = player.AttackSkill.CurrentLevel;
            attackCard.BaseLevel = player.AttackSkill.BaseLevel;
            attackCard.Experience = player.AttackSkill.Experience;
            attackCard.Location = new Point2D(
                Location.X + (Size.Width - 3 * attackCard.Size.Width - 2 * spacingX) / 2,
                Location.Y + (Size.Width - 3 * attackCard.Size.Width - 2 * spacingX) / 2);

            hitpointsCard.CurrentLevel = player.HitpointsSkill.CurrentLevel;
            hitpointsCard.BaseLevel = player.HitpointsSkill.BaseLevel;
            hitpointsCard.Experience = player.HitpointsSkill.Experience;
            hitpointsCard.Location = new Point2D(
                attackCard.ClientRectangle.Right + spacingX,
                attackCard.ClientRectangle.Top);

            miningCard.CurrentLevel = player.MiningSkill.CurrentLevel;
            miningCard.BaseLevel = player.MiningSkill.BaseLevel;
            miningCard.Experience = player.MiningSkill.Experience;
            miningCard.Location = new Point2D(
                hitpointsCard.ClientRectangle.Right + spacingX,
                hitpointsCard.ClientRectangle.Top);

            strengthCard.CurrentLevel = player.StrengthSkill.CurrentLevel;
            strengthCard.BaseLevel = player.StrengthSkill.BaseLevel;
            strengthCard.Experience = player.StrengthSkill.Experience;
            strengthCard.Location = new Point2D(
                attackCard.ClientRectangle.Left,
                attackCard.ClientRectangle.Bottom + spacingY);

            agilityCard.CurrentLevel = player.AgilitySkill.CurrentLevel;
            agilityCard.BaseLevel = player.AgilitySkill.BaseLevel;
            agilityCard.Experience = player.AgilitySkill.Experience;
            agilityCard.Location = new Point2D(
                strengthCard.ClientRectangle.Right + spacingX,
                strengthCard.ClientRectangle.Top);

            smithingCard.CurrentLevel = player.SmithingSkill.CurrentLevel;
            smithingCard.BaseLevel = player.SmithingSkill.BaseLevel;
            smithingCard.Experience = player.SmithingSkill.Experience;
            smithingCard.Location = new Point2D(
                agilityCard.ClientRectangle.Right + spacingX,
                agilityCard.ClientRectangle.Top);

            defenceCard.CurrentLevel = player.DefenceSkill.CurrentLevel;
            defenceCard.BaseLevel = player.DefenceSkill.BaseLevel;
            defenceCard.Experience = player.DefenceSkill.Experience;
            defenceCard.Location = new Point2D(
                strengthCard.ClientRectangle.Left,
                strengthCard.ClientRectangle.Bottom + spacingY);

            herbloreCard.CurrentLevel = player.HerbloreSkill.CurrentLevel;
            herbloreCard.BaseLevel = player.HerbloreSkill.BaseLevel;
            herbloreCard.Experience = player.HerbloreSkill.Experience;
            herbloreCard.Location = new Point2D(
                defenceCard.ClientRectangle.Right + spacingX,
                defenceCard.ClientRectangle.Top);

            fishingCard.CurrentLevel = player.FishingSkill.CurrentLevel;
            fishingCard.BaseLevel = player.FishingSkill.BaseLevel;
            fishingCard.Experience = player.FishingSkill.Experience;
            fishingCard.Location = new Point2D(
                herbloreCard.ClientRectangle.Right + spacingX,
                herbloreCard.ClientRectangle.Top);

            rangedCard.CurrentLevel = player.RangedSkill.CurrentLevel;
            rangedCard.BaseLevel = player.RangedSkill.BaseLevel;
            rangedCard.Experience = player.RangedSkill.Experience;
            rangedCard.Location = new Point2D(
                defenceCard.ClientRectangle.Left,
                defenceCard.ClientRectangle.Bottom + spacingY);

            thievingCard.CurrentLevel = player.ThievingSkill.CurrentLevel;
            thievingCard.BaseLevel = player.ThievingSkill.BaseLevel;
            thievingCard.Experience = player.ThievingSkill.Experience;
            thievingCard.Location = new Point2D(
                rangedCard.ClientRectangle.Right + spacingX,
                rangedCard.ClientRectangle.Top);

            cookingCard.CurrentLevel = player.CookingSkill.CurrentLevel;
            cookingCard.BaseLevel = player.CookingSkill.BaseLevel;
            cookingCard.Experience = player.CookingSkill.Experience;
            cookingCard.Location = new Point2D(
                thievingCard.ClientRectangle.Right + spacingX,
                thievingCard.ClientRectangle.Top);

            prayerCard.CurrentLevel = player.PrayerSkill.CurrentLevel;
            prayerCard.BaseLevel = player.PrayerSkill.BaseLevel;
            prayerCard.Experience = player.PrayerSkill.Experience;
            prayerCard.Location = new Point2D(
                rangedCard.ClientRectangle.Left,
                rangedCard.ClientRectangle.Bottom + spacingY);

            craftingCard.CurrentLevel = player.CraftingSkill.CurrentLevel;
            craftingCard.BaseLevel = player.CraftingSkill.BaseLevel;
            craftingCard.Experience = player.CraftingSkill.Experience;
            craftingCard.Location = new Point2D(
                prayerCard.ClientRectangle.Right + spacingX,
                prayerCard.ClientRectangle.Top);

            firemakingCard.CurrentLevel = player.FiremakingSkill.CurrentLevel;
            firemakingCard.BaseLevel = player.FiremakingSkill.BaseLevel;
            firemakingCard.Experience = player.FiremakingSkill.Experience;
            firemakingCard.Location = new Point2D(
                craftingCard.ClientRectangle.Right + spacingX,
                prayerCard.ClientRectangle.Top);

            magicCard.CurrentLevel = player.MagicSkill.CurrentLevel;
            magicCard.BaseLevel = player.MagicSkill.BaseLevel;
            magicCard.Experience = player.MagicSkill.Experience;
            magicCard.Location = new Point2D(
                prayerCard.ClientRectangle.Left,
                prayerCard.ClientRectangle.Bottom + spacingY);

            fletchingCard.CurrentLevel = player.FletchingSkill.CurrentLevel;
            fletchingCard.BaseLevel = player.FletchingSkill.BaseLevel;
            fletchingCard.Experience = player.FletchingSkill.Experience;
            fletchingCard.Location = new Point2D(
                magicCard.ClientRectangle.Right + spacingX,
                magicCard.ClientRectangle.Top);

            woodcuttingCard.CurrentLevel = player.WoodcuttingSkill.CurrentLevel;
            woodcuttingCard.BaseLevel = player.WoodcuttingSkill.BaseLevel;
            woodcuttingCard.Experience = player.WoodcuttingSkill.Experience;
            woodcuttingCard.Location = new Point2D(
                fletchingCard.ClientRectangle.Right + spacingX,
                fletchingCard.ClientRectangle.Top);
        }
    }
}
