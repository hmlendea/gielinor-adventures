using NuciXNA.Primitives;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiToggleButton : GuiButton
    {
        public bool Toggled { get; set; }

        public Colour ToggleColour { get; set; }

        public GuiToggleButton()
        {
            ToggleColour = Colour.DarkRed;
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            for (int i = 0; i < images.Count; i++)
            {
                if (Toggled)
                {
                    images[i].TintColour = ToggleColour;
                }
                else
                {
                    images[i].TintColour = Colour.White;
                }
            }
        }

        protected override Rectangle2D CalculateSourceRectangle(int x)
        {
            Rectangle2D rect = base.CalculateSourceRectangle(x);

            if (Toggled && !Hovered)
            {
                return new Rectangle2D(rect.X + 4 * ButtonTileSize.Width, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                return rect;
            }
        }
    }
}
