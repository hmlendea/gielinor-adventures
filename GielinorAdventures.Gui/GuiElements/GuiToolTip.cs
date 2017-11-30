namespace GielinorAdventures.Gui.GuiElements
{
    /// <summary>
    /// Tool tip GUI element.
    /// </summary>
    public class GuiTooltip : GuiElement
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        GuiText text;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuiTooltip"/> class.
        /// </summary>
        public GuiTooltip()
        {
            FontName = "MenuFont";
            Visible = false;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public override void LoadContent()
        {
            text = new GuiText
            {
                Margins = 2
            };

            Children.Add(text);

            base.LoadContent();
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            text.Text = Text;
            text.FontName = FontName;
            text.ForegroundColour = ForegroundColour;
            text.BackgroundColour = BackgroundColour;
            text.Location = Location;
            text.Size = Size;
        }
    }
}
