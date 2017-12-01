using System;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GielinorAdventures.DataAccess.Resources;
using GielinorAdventures.Graphics.CustomSpriteEffects;
using GielinorAdventures.Graphics.Enumerations;
using GielinorAdventures.Graphics.Helpers;
using GielinorAdventures.Primitives;
using GielinorAdventures.Primitives.Mapping;

namespace GielinorAdventures.Graphics
{
    /// <summary>
    /// Sprite.
    /// </summary>
    public class Sprite
    {
        SpriteFont font;
        Texture2D alphaMask;

        string loadedContentFile;
        string loadedAlphaMaskFile;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Sprite"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the tint.
        /// </summary>
        /// <value>The tint.</value>
        public Colour Tint { get; set; }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public float Opacity { get; set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the zoom.
        /// </summary>
        /// <value>The zoom.</value>
        public float Zoom { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        // TODO: Make this a number (Outline size)
        /// <summary>
        /// Gets or sets a value indicating whether the text of the <see cref="Sprite"/> will be outlined.
        /// </summary>
        /// <value><c>true</c> if the text is outlined; otherwise, <c>false</c>.</value>
        public FontOutline FontOutline { get; set; }

        /// <summary>
        /// Gets or sets the text horizontal alignment.
        /// </summary>
        /// <value>The text horizontal alignment.</value>
        public HorizontalAlignment TextHorizontalAlignment { get; set; }

        /// <summary>
        /// Gets or sets the text vertical alignment.
        /// </summary>
        /// <value>The text vertical alignment.</value>
        public VerticalAlignment TextVerticalAlignment { get; set; }

        /// <summary>
        /// Gets or sets the name of the font.
        /// </summary>
        /// <value>The name of the font.</value>
        public string FontName { get; set; }

        /// <summary>
        /// Gets or sets the content file.
        /// </summary>
        /// <value>The content file.</value>
        public string ContentFile { get; set; }

        /// <summary>
        /// Gets or sets the alpha mask path.
        /// </summary>
        /// <value>The alpha mask path.</value>
        public string AlphaMaskFile { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public Point2D Location { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size2D SpriteSize { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        public Scale2D Scale { get; set; }

        /// <summary>
        /// Gets or sets the source rectangle.
        /// </summary>
        /// <value>The source rectangle.</value>
        [XmlIgnore]
        public Rectangle2D SourceRectangle { get; set; }

        /// <summary>
        /// Gets the covered screen area.
        /// </summary>
        /// <value>The covered screen area.</value>
        public Rectangle2D ClientRectangle
        {
            get
            {
                return new Rectangle2D(
                    Location.X,
                    Location.Y,
                    (int)(SourceRectangle.Width * Scale.Horizontal),
                    (int)(SourceRectangle.Height * Scale.Vertical));
            }
        }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <value>The texture.</value>
        [XmlIgnore]
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Gets the texture size.
        /// </summary>
        /// <value>The texture size.</value>
        [XmlIgnore]
        public Size2D TextureSize => new Size2D(Texture.Width, Texture.Height);

        /// <summary>
        /// Gets or sets the fill mode.
        /// </summary>
        /// <value>The fill mode.</value>
        public TextureLayout TextureLayout { get; set; }

        /// <summary>
        /// Gets or sets the animation effect.
        /// </summary>
        /// <value>The animation effect.</value>
        public AnimationEffect AnimationEffect { get; set; }

        /// <summary>
        /// Gets or sets the fade effect.
        /// </summary>
        /// <value>The fade effect.</value>
        public FadeEffect FadeEffect { get; set; }

        /// <summary>
        /// Gets or sets the rotation effect.
        /// </summary>
        /// <value>The rotation effect.</value>
        public RotationEffect RotationEffect { get; set; }

        /// <summary>
        /// Gets or sets the sprite sheet effect.
        /// </summary>
        /// <value>The sprite sheet effect.</value>
        public SpriteSheetEffect SpriteSheetEffect { get; set; }

        /// <summary>
        /// Gets or sets the zoom effect.
        /// </summary>
        /// <value>The zoom effect.</value>
        public ZoomEffect ZoomEffect { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        public Sprite()
        {
            Active = true;

            ContentFile = string.Empty;
            Text = string.Empty;
            FontName = "MenuFont";

            Location = Point2D.Empty;
            SourceRectangle = Rectangle2D.Empty;

            Opacity = 1.0f;
            Zoom = 1.0f;
            Scale = Scale2D.One;
            TextureLayout = TextureLayout.Stretch;

            Tint = Colour.White;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            AnimationEffect?.AssociateSprite(this);
            FadeEffect?.AssociateSprite(this);
            RotationEffect?.AssociateSprite(this);
            SpriteSheetEffect?.AssociateSprite(this);
            ZoomEffect?.AssociateSprite(this);

            if (string.IsNullOrWhiteSpace(Text))
            {
                Text = string.Empty;
            }

            LoadContentFile();
            LoadAlphaMaskFile();

            font = ResourceManager.Instance.LoadSpriteFont("Fonts/" + FontName);

            if (SpriteSize == Size2D.Empty)
            {
                Size2D size = Size2D.Empty;

                if (Texture != null)
                {
                    size.Width = Texture.Width;
                    size.Height = Texture.Height;
                }
                else if (Text != string.Empty)
                {
                    size.Width = (int)font.MeasureString(Text).X;
                    size.Height = (int)font.MeasureString(Text).Y;
                }
                else
                {
                    size.Width = 1;
                    size.Height = 1;
                }

                SpriteSize = size;
            }

            if (SourceRectangle == Rectangle2D.Empty)
            {
                SourceRectangle = new Rectangle2D(Point2D.Empty, SpriteSize);
            }

            RenderTarget2D renderTarget = new RenderTarget2D(
                GraphicsManager.Instance.Graphics.GraphicsDevice,
                SpriteSize.Width, SpriteSize.Height);

            GraphicsManager.Instance.Graphics.GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsManager.Instance.Graphics.GraphicsDevice.Clear(Color.Transparent);

            if (Texture != null)
            {
                GraphicsManager.Instance.SpriteBatch.Begin();
                GraphicsManager.Instance.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);
                GraphicsManager.Instance.SpriteBatch.End();
            }

            Texture = renderTarget;

            GraphicsManager.Instance.Graphics.GraphicsDevice.SetRenderTarget(null);
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            AnimationEffect?.UnloadContent();
            FadeEffect?.UnloadContent();
            RotationEffect?.UnloadContent();
            SpriteSheetEffect?.UnloadContent();
            ZoomEffect?.UnloadContent();
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {
            LoadContentFile();
            LoadAlphaMaskFile();

            AnimationEffect?.Update(gameTime);
            FadeEffect?.Update(gameTime);
            RotationEffect?.Update(gameTime);
            SpriteSheetEffect?.Update(gameTime);
            ZoomEffect?.Update(gameTime);
        }

        /// <summary>
        /// Draws the content.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(SourceRectangle.Width / 2,
                                         SourceRectangle.Height / 2);

            if (!string.IsNullOrEmpty(Text))
            {
                DrawString(spriteBatch, font, StringUtils.WrapText(font, Text, SpriteSize.Width), ClientRectangle.ToXnaRectangle(),
                           TextHorizontalAlignment, TextVerticalAlignment, Tint.ToXnaColor() * Opacity);
            }

            // TODO: Do not do this for every Draw call
            Texture2D textureToDraw = Texture;

            // TODO: Find a better way to do this, because this one doesn't keep the mipmaps
            if (alphaMask != null)
            {
                textureToDraw = TextureBlend(Texture, alphaMask);
            }

            if (TextureLayout == TextureLayout.Stretch)
            {
                float rotation = Rotation;
                float zoom = Zoom;

                if (RotationEffect != null && RotationEffect.Active)
                {
                    rotation += RotationEffect.CurrentRotation;
                }

                if (ZoomEffect != null && ZoomEffect.Active)
                {
                    zoom += ZoomEffect.CurrentZoom;
                }

                spriteBatch.Draw(textureToDraw, new Vector2(Location.X + ClientRectangle.Width / 2, Location.Y + ClientRectangle.Height / 2), SourceRectangle.ToXnaRectangle(),
                    Tint.ToXnaColor() * Opacity, rotation,
                    origin, Scale.ToXnaVector2() * zoom,
                    SpriteEffects.None, 0.0f);
            }
            else if (TextureLayout == TextureLayout.Tile)
            {
                GraphicsDevice gd = GraphicsManager.Instance.Graphics.GraphicsDevice;

                Rectangle rec = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);

                // TODO: Is it ok to End and Begin again? Does it affect performance?
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);

                spriteBatch.Draw(textureToDraw, new Vector2(Location.X, Location.Y), rec, Tint.ToXnaColor() * Opacity);

                spriteBatch.End();
                spriteBatch.Begin();
            }
        }

        void DrawString(SpriteBatch spriteBatch, SpriteFont spriteFont, string text, Rectangle bounds, HorizontalAlignment hAlign, VerticalAlignment vAlign, Color colour)
        {
            Vector2 textOrigin = Vector2.Zero;
            Vector2 totalSize = font.MeasureString(text);

            string[] lines = text.Split('\n');

            if (hAlign == HorizontalAlignment.Centre)
            {
                textOrigin.Y = bounds.Height / 2 - totalSize.Y / 2;
            }
            else if (hAlign == HorizontalAlignment.Bottom)
            {
                textOrigin.Y = bounds.Height - totalSize.Y;
            }

            foreach (string line in lines)
            {
                Vector2 lineSize = font.MeasureString(line);

                if (vAlign == VerticalAlignment.Centre)
                {
                    textOrigin.X = bounds.Width / 2 - lineSize.X / 2;
                }
                else if (vAlign == VerticalAlignment.Right)
                {
                    textOrigin.X = bounds.Width - lineSize.X;
                }

                textOrigin = new Vector2((int)Math.Round(textOrigin.X),
                                         (int)Math.Round(textOrigin.Y));

                if (FontOutline == FontOutline.Around)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            Vector2 pos = new Vector2(Location.X + dx + textOrigin.X,
                                                      Location.Y + dy + textOrigin.Y);

                            // TODO: Do not hardcode the outline colour
                            spriteBatch.DrawString(spriteFont, line, pos, Color.Black);
                        }
                    }
                }
                else if (FontOutline == FontOutline.BottomRight)
                {
                    Vector2 pos = new Vector2(Location.X + 1 + textOrigin.X,
                                              Location.Y + 1 + textOrigin.Y);

                    // TODO: Do not hardcode the outline colour
                    spriteBatch.DrawString(spriteFont, line, pos, Color.Black);
                }

                spriteBatch.DrawString(spriteFont, line, new Vector2(Location.X, Location.Y) + textOrigin, colour);

                textOrigin.Y += lineSize.Y;
            }
        }

        Texture2D TextureBlend(Texture2D source, Texture2D mask)
        {
            Color[] textureBits = new Color[source.Width * source.Height];
            Color[] maskBits = new Color[mask.Width * mask.Height];

            source.GetData(textureBits);
            mask.GetData(maskBits);

            int startX, startY, endX, endY;

            if (mask.Width > source.Width)
            {
                startX = mask.Width - source.Width;
                endX = startX + source.Width;
            }
            else
            {
                startX = source.Width - mask.Width;
                endX = startX + mask.Width;
            }

            if (mask.Height > source.Height)
            {
                startY = mask.Height - source.Height;
                endY = startY + source.Height;
            }
            else
            {
                startY = source.Height - mask.Height;
                endY = startY + mask.Height;
            }

            Parallel.For(startY, endY, y => Parallel.For(startX, endX, x =>
            {
                int indexTexture = x - startX + (y - startY) * source.Width;
                int indexMask = x - startX + (y - startY) * mask.Width;

                textureBits[indexTexture] = Color.FromNonPremultiplied(textureBits[indexTexture].R,
                                                                       textureBits[indexTexture].G,
                                                                       textureBits[indexTexture].B,
                                                                       textureBits[indexTexture].A - 255 + maskBits[indexMask].R);
            }));

            Texture2D blendedTexture = new Texture2D(source.GraphicsDevice, source.Width, source.Height);
            blendedTexture.SetData(textureBits);

            return blendedTexture;
        }

        void LoadContentFile()
        {
            if (loadedContentFile == ContentFile || string.IsNullOrEmpty(ContentFile))
            {
                return;
            }

            Texture = ResourceManager.Instance.LoadTexture2D(ContentFile);

            loadedContentFile = ContentFile;
        }

        void LoadAlphaMaskFile()
        {
            if (loadedAlphaMaskFile == AlphaMaskFile || string.IsNullOrEmpty(AlphaMaskFile))
            {
                return;
            }

            alphaMask = ResourceManager.Instance.LoadTexture2D(AlphaMaskFile);

            loadedAlphaMaskFile = AlphaMaskFile;
        }
    }
}
