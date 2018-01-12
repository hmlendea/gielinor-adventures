using System.Collections.Generic;

using NuciXNA.Primitives;

using GielinorAdventures.Input.Enumerations;
using GielinorAdventures.Input.Events;
using GielinorAdventures.Settings;

namespace GielinorAdventures.Gui.GuiElements
{
    /// <summary>
    /// Button GUI element.
    /// </summary>
    public class GuiButton : GuiElement
    {
        public Size2D ButtonTileSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the button.
        /// </summary>
        /// <value>The size of the button.</value>
        public Size2D ButtonSize => new Size2D(
            Size.Width / ButtonTileSize.Width,
            Size.Height / ButtonTileSize.Height);

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        public string Icon { get; set; }

        public string Texture { get; set; }

        protected List<GuiImage> images;
        GuiImage icon;
        GuiText text;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuiButton"/> class.
        /// </summary>
        public GuiButton()
        {
            Texture = "Interface/button";
            FontName = "ButtonFont";
            ButtonTileSize = new Size2D(GameDefines.GUI_TILE_SIZE, GameDefines.GUI_TILE_SIZE);
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public override void LoadContent()
        {
            icon = new GuiImage();
            images = new List<GuiImage>();
            text = new GuiText();

            for (int x = 0; x < ButtonSize.Width; x++)
            {
                GuiImage image = new GuiImage { SourceRectangle = CalculateSourceRectangle(x) };

                images.Add(image);
            }

            Children.AddRange(images);
            Children.Add(text);

            if (!string.IsNullOrWhiteSpace(Icon))
            {
                Children.Add(icon);
            }

            base.LoadContent();
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            for (int i = 0; i < images.Count; i++)
            {
                images[i].ContentFile = Texture;
                images[i].Location = new Point2D(Location.X + i * ButtonTileSize.Width, Location.Y);
                images[i].SourceRectangle = CalculateSourceRectangle(i);
            }

            text.Text = Text;
            text.ForegroundColour = ForegroundColour;
            text.FontName = FontName;
            text.Location = Location;
            text.Size = Size;

            icon.ContentFile = Icon;
            icon.Location = new Point2D(
                Location.X + (Size.Width - icon.Size.Width) / 2,
                Location.Y + (Size.Height - icon.Size.Height) / 2);
        }

        /// <summary>
        /// Fired by the Clicked event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        protected override void OnClicked(object sender, MouseButtonEventArgs e)
        {
            base.OnClicked(sender, e);

            if (e.Button != MouseButton.LeftButton)
            {
                return;
            }

            //AudioManager.Instance.PlaySound("Interface/click");
        }

        /// <summary>
        /// Fired by the MouseMoved event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        protected override void OnMouseEntered(object sender, MouseEventArgs e)
        {
            base.OnMouseMoved(sender, e);

            //AudioManager.Instance.PlaySound("Interface/select");
        }

        protected virtual Rectangle2D CalculateSourceRectangle(int x)
        {
            int sx = 1;

            if (ButtonSize.Width == 1)
            {
                sx = 3;
            }
            else if (x == 0)
            {
                sx = 0;
            }
            else if (x == ButtonSize.Width - 1)
            {
                sx = 2;
            }

            if (Hovered)
            {
                sx += 4;
            }

            return new Rectangle2D(sx * ButtonTileSize.Width, 0,
                                   ButtonTileSize.Width, ButtonTileSize.Height);
        }
    }
}
