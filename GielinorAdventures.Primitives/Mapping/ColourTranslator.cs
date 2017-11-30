using System;
using System.Drawing;

namespace GielinorAdventures.Primitives.Mapping
{
    public static class ColourTranslator
    {
        /// <summary>
        /// Converts the colour to hexadecimal.
        /// </summary>
        /// <returns>The hexadecimal code.</returns>
        public static string ToHexadecimal(Colour colour)
        {
            string hexa = string.Format("#{0:X2}{1:X2}{2:X2}", colour.R, colour.G, colour.B);

            return hexa;
        }

        /// <summary>
        /// Creates a colour from a hexadecimal code.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="hexa">Hexadecimal code.</param>
        public static Colour FromHexadecimal(string hexa)
        {
            Colour colour = new Colour();

            if (hexa[0] == '#')
            {
                hexa = hexa.Remove(0, 1);
            }

            if (hexa.Length == 3)
            {
                colour.R = Convert.ToByte(hexa[0] + "" + hexa[0], 16);
                colour.G = Convert.ToByte(hexa[1] + "" + hexa[1], 16);
                colour.B = Convert.ToByte(hexa[2] + "" + hexa[2], 16);
            }
            else if (hexa.Length == 6)
            {
                colour.R = Convert.ToByte(hexa[0] + "" + hexa[1], 16);
                colour.G = Convert.ToByte(hexa[2] + "" + hexa[3], 16);
                colour.B = Convert.ToByte(hexa[4] + "" + hexa[5], 16);
            }
            else
            {
                throw new ArgumentException("Hexadecimal colour '" + hexa + "' is invalid.");
            }

            return colour;
        }

        /// <summary>
        /// Converts the colour to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="colour">Colour.</param>
        public static int ToArgb(Colour colour) => ToArgb(colour.R, colour.G, colour.B, colour.A);

        /// <summary>
        /// Converts the RGB components to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public static int ToArgb(byte r, byte g, byte b) => ToArgb(r, g, b, (byte)255);

        /// <summary>
        /// Converts the RGB components to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public static int ToArgb(int r, int g, int b) => ToArgb((byte)r, (byte)g, (byte)b, (byte)255);

        /// <summary>
        /// Converts the ARGB components to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public static int ToArgb(byte r, byte g, byte b, byte a)
        {
            int argb = (a << 24) |
                       (r << 16) |
                       (g << 8) |
                       b;

            return argb;
        }

        /// <summary>
        /// Converts the ARGB components to a 32 bit integer.
        /// </summary>
        /// <returns>The ARGB integer value.</returns>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public static int ToArgb(int r, int g, int b, int a) => ToArgb((byte)r, (byte)g, (byte)b, (byte)a);

        /// <summary>
        /// Creates a colour from an ARGB integer.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="argb">ARGB integer.</param>
        public static Colour FromArgb(int argb)
        {
            return Color.FromArgb(argb).ToColour();
        }

        /// <summary>
        /// Creates a colour from RGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static Colour FromArgb(byte r, byte g, byte b) => new Colour(r, g, b);

        /// <summary>
        /// Creates a colour from RGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static Colour FromArgb(int r, int g, int b) => new Colour(r, g, b);

        /// <summary>
        /// Creates a colour from ARGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="a">Alpha value.</param>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static Colour FromArgb(byte a, byte r, byte g, byte b) => new Colour(r, g, b, a);

        /// <summary>
        /// Creates a colour from ARGB values.
        /// </summary>
        /// <returns>The colour.</returns>
        /// <param name="a">Alpha value.</param>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static Colour FromArgb(int a, int r, int g, int b) => new Colour(r, g, b, a);
    }
}
