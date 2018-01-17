using NuciXNA.Graphics.Enumerations;
using NuciXNA.Primitives;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiCombatStyleCard : GuiElement
    {
        GuiImage background;
        GuiImage icon;
        GuiText nameText;

        public bool IsToggled { get; set; }

        public string Icon { get; set; }

        public string CombatStyleName { get; set; }

        public override void LoadContent()
        {
            background = new GuiImage { ContentFile = "Interface/combatcard" };
            icon = new GuiImage();
            nameText = new GuiText
            {
                FontName = "SkillCardFont",
                FontOutline = FontOutline.BottomRight,
                HorizontalAlignment = HorizontalAlignment.Top
            };

            Children.Add(background);
            Children.Add(icon);
            Children.Add(nameText);

            base.LoadContent();
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            background.Size = Size;
            background.Location = Location;

            if (IsToggled)
            {
                background.TintColour = Colour.Red;
            }
            else
            {
                background.TintColour = Colour.White;
            }

            icon.Size = Size;
            icon.Location = Location;
            icon.ContentFile = Icon;

            nameText.Size = new Size2D(Size.Width, 14);
            nameText.Location = new Point2D(ClientRectangle.Left, ClientRectangle.Bottom - nameText.Size.Height);
            nameText.Text = CombatStyleName;
            nameText.ForegroundColour = ForegroundColour;
        }
    }
}
