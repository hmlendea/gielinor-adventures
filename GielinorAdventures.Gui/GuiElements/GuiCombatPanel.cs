using System;

using GielinorAdventures.Models.Enumerations;
using GielinorAdventures.Primitives;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiCombatPanel : GuiElement
    {
        const int Spacing = 12;

        GuiText combatLevelText;

        GuiCombatStyleCard controlledStyleCard;
        GuiCombatStyleCard aggressiveStyleCard;
        GuiCombatStyleCard accurateStyleCard;
        GuiCombatStyleCard defensiveStyleCard;

        public GuiCombatPanel()
        {
            ForegroundColour = Colour.Gold;
        }

        public override void LoadContent()
        {
            combatLevelText = new GuiText { Size = new Size2D(Size.Width, 24) };
            controlledStyleCard = new GuiCombatStyleCard
            {
                Size = new Size2D(72, 48),
                CombatStyleName = "Controlled",
                Icon = "Icons/CombatStyles/controlled"
            };
            aggressiveStyleCard = new GuiCombatStyleCard
            {
                Size = new Size2D(72, 48),
                CombatStyleName = "Aggressive",
                Icon = "Icons/CombatStyles/aggressive"
            };
            accurateStyleCard = new GuiCombatStyleCard
            {
                Size = new Size2D(72, 48),
                CombatStyleName = "Accurate",
                Icon = "Icons/CombatStyles/accurate"
            };
            defensiveStyleCard = new GuiCombatStyleCard
            {
                Size = new Size2D(72, 48),
                CombatStyleName = "Defensive",
                Icon = "Icons/CombatStyles/defensive"
            };

            Children.Add(combatLevelText);
            Children.Add(controlledStyleCard);
            Children.Add(aggressiveStyleCard);
            Children.Add(accurateStyleCard);
            Children.Add(defensiveStyleCard);

            base.LoadContent();
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            combatLevelText.Size = new Size2D(Size.Width, combatLevelText.Size.Height);
            combatLevelText.Location = new Point2D(Location.X, Location.Y + Spacing);
            combatLevelText.ForegroundColour = ForegroundColour;

            controlledStyleCard.Location = new Point2D(
                Location.X + (Size.Width - controlledStyleCard.Size.Width * 2 - Spacing) / 2,
                combatLevelText.ClientRectangle.Bottom + Spacing);
            aggressiveStyleCard.Location = new Point2D(
                controlledStyleCard.ClientRectangle.Right + Spacing,
                controlledStyleCard.ClientRectangle.Top);
            accurateStyleCard.Location = new Point2D(
                controlledStyleCard.ClientRectangle.Left,
                controlledStyleCard.ClientRectangle.Bottom + Spacing);
            defensiveStyleCard.Location = new Point2D(
                accurateStyleCard.ClientRectangle.Right + Spacing,
                accurateStyleCard.ClientRectangle.Top);

            controlledStyleCard.ForegroundColour = ForegroundColour;
            aggressiveStyleCard.ForegroundColour = ForegroundColour;
            accurateStyleCard.ForegroundColour = ForegroundColour;
            defensiveStyleCard.ForegroundColour = ForegroundColour;

            /*
            if (gameManager != null) // TODO: Ugly fix
            {
                combatLevelText.Text = $"Combat Level: {client.CurrentPlayer.CombatLevel}";

                controlledStyleCard.IsToggled = false;
                aggressiveStyleCard.IsToggled = false;
                accurateStyleCard.IsToggled = false;
                defensiveStyleCard.IsToggled = false;

                switch (gameManager.CombatStyle)
                {
                    case CombatStyle.Controlled:
                        controlledStyleCard.IsToggled = true;
                        break;

                    case CombatStyle.Aggressive:
                        aggressiveStyleCard.IsToggled = true;
                        break;

                    case CombatStyle.Accurate:
                        accurateStyleCard.IsToggled = true;
                        break;

                    case CombatStyle.Defensive:
                        defensiveStyleCard.IsToggled = true;
                        break;
                }
            }
            */
        }

        protected override void RegisterEvents()
        {
            controlledStyleCard.Clicked += ControlledStyleCard_Clicked;
            aggressiveStyleCard.Clicked += AggressiveStyleCard_Clicked;
            accurateStyleCard.Clicked += AccurateStyleCard_Clicked;
            defensiveStyleCard.Clicked += DefensiveStyleCard_Clicked;
        }

        protected override void UnregisterEvents()
        {
            controlledStyleCard.Clicked -= ControlledStyleCard_Clicked;
            aggressiveStyleCard.Clicked -= AggressiveStyleCard_Clicked;
            accurateStyleCard.Clicked -= AccurateStyleCard_Clicked;
            defensiveStyleCard.Clicked -= DefensiveStyleCard_Clicked;
        }

        void ControlledStyleCard_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        void AggressiveStyleCard_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        void AccurateStyleCard_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        void DefensiveStyleCard_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
