namespace GielinorAdventures.Models
{
    public class Skill
    {
        public Skill()
        {
            CurrentLevel = 1;
            BaseLevel = 1;
        }

        public Skill(int level, int experience)
        {
            CurrentLevel = level;
            BaseLevel = level;
            Experience = experience;
        }

        public Skill(int currentLevel, int baseLevel, int experience)
        {
            CurrentLevel = currentLevel;
            BaseLevel = baseLevel;
            Experience = experience;
        }

        public int CurrentLevel { get; set; }

        public int BaseLevel { get; set; }

        public int Experience { get; set; }
    }
}
