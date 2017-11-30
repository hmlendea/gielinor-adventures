using Microsoft.Xna.Framework;

using GielinorAdventures.Primitives;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiSkillsPanel : GuiElement
    {
        GuiSkillCard attackCard;
        GuiSkillCard healthCard;
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
            healthCard = new GuiSkillCard { SkillIcon = "Icons/Skills/health" };
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
            Children.Add(healthCard);
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

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            int spacingX = 1;
            int spacingY = 1;

            attackCard.Location = new Point2D(
                Location.X + (Size.Width - 3 * attackCard.Size.Width - 2 * spacingX) / 2,
                Location.Y + (Size.Width - 3 * attackCard.Size.Width - 2 * spacingX) / 2);
            healthCard.Location = new Point2D(
                attackCard.ClientRectangle.Right + spacingX,
                attackCard.ClientRectangle.Top);
            miningCard.Location = new Point2D(
                healthCard.ClientRectangle.Right + spacingX,
                healthCard.ClientRectangle.Top);
            strengthCard.Location = new Point2D(
                attackCard.ClientRectangle.Left,
                attackCard.ClientRectangle.Bottom + spacingY);
            agilityCard.Location = new Point2D(
                strengthCard.ClientRectangle.Right + spacingX,
                strengthCard.ClientRectangle.Top);
            smithingCard.Location = new Point2D(
                agilityCard.ClientRectangle.Right + spacingX,
                agilityCard.ClientRectangle.Top);
            defenceCard.Location = new Point2D(
                strengthCard.ClientRectangle.Left,
                strengthCard.ClientRectangle.Bottom + spacingY);
            herbloreCard.Location = new Point2D(
                defenceCard.ClientRectangle.Right + spacingX,
                defenceCard.ClientRectangle.Top);
            fishingCard.Location = new Point2D(
                herbloreCard.ClientRectangle.Right + spacingX,
                herbloreCard.ClientRectangle.Top);
            rangedCard.Location = new Point2D(
                defenceCard.ClientRectangle.Left,
                defenceCard.ClientRectangle.Bottom + spacingY);
            thievingCard.Location = new Point2D(
                rangedCard.ClientRectangle.Right + spacingX,
                rangedCard.ClientRectangle.Top);
            cookingCard.Location = new Point2D(
                thievingCard.ClientRectangle.Right + spacingX,
                thievingCard.ClientRectangle.Top);
            prayerCard.Location = new Point2D(
                rangedCard.ClientRectangle.Left,
                rangedCard.ClientRectangle.Bottom + spacingY);
            craftingCard.Location = new Point2D(
                prayerCard.ClientRectangle.Right + spacingX,
                prayerCard.ClientRectangle.Top);
            firemakingCard.Location = new Point2D(
                craftingCard.ClientRectangle.Right + spacingX,
                prayerCard.ClientRectangle.Top);
            magicCard.Location = new Point2D(
                prayerCard.ClientRectangle.Left,
                prayerCard.ClientRectangle.Bottom + spacingY);
            fletchingCard.Location = new Point2D(
                magicCard.ClientRectangle.Right + spacingX,
                magicCard.ClientRectangle.Top);
            woodcuttingCard.Location = new Point2D(
                fletchingCard.ClientRectangle.Right + spacingX,
                fletchingCard.ClientRectangle.Top);
        }
    }
}
