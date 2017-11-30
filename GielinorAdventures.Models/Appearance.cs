namespace GielinorAdventures.Models
{
    public class Appearance
    {
        public int HairColour { get; set; }

        public int TopColour { get; set; }

        public int TrousersColour { get; set; }

        public int SkinColour { get; set; }

        public int Head { get; set; }

        public int Body { get; set; }

        public bool IsValid => true; // TODO: Implement this

        public int GetSprite(int position)
        {
            switch (position)
            {
                case 0:
                    return Head;

                case 1:
                    return Body;

                case 2:
                    return 3;

                default:
                    return 0;
            }
        }

        public int[] GetSprites()
        {
            return new int[] { Head, Body, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    }
}
