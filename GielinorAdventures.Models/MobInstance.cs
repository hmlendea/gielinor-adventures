using System;
using System.Collections.Generic;

using NuciXNA.Primitives;

using GielinorAdventures.Infrastructure;
using GielinorAdventures.Models.Enumerations;

namespace GielinorAdventures.Models
{
    public abstract class MobInstance : GameEntityInstance
    {
        int combatLevel;
        int mobSprite;
        int[][] mobSprites;
        bool[] activatedPrayers;
        PathHandler pathHandler;
        // viewArea

        protected Dictionary<long, int> totalDamageTable;
        protected Dictionary<long, int> meleeDamageTable;
        protected Dictionary<long, int> rangeDamageTable;

        MobInstance CombatOpponent { get; set; }

        public CombatState LastCombatState { get; private set; }

        public int CombatLevel
        {
            get
            {
                return combatLevel;
            }
            set
            {
                combatLevel = value;
                HasAppearanceChanged = true;
            }
        }

        public int AppearanceId { get; private set; }

        public long CombatTime { get; private set; }

        public int HitsMade { get; set; }

        public int LastDamage { get; set; }

        public int MobSprite
        {
            get
            {
                return mobSprite;
            }
            set
            {
                mobSprite = value;
                HasSpriteChanged = true;
            }
        }

        public long LastMovementTime { get; private set; }

        public bool HasAppearanceChanged { get; private set; }

        public bool HasMoved { get; set; }

        public bool HasSpriteChanged { get; set; }

        public bool IsBusy { get; set; }

        public bool IsInCombat
        {
            get
            {
                return (mobSprite == 8 || mobSprite == 9) && CombatOpponent != null;
            }
        }

        public bool IsRemoved { get; protected set; }

        public bool WarnedToMove { get; set; }

        public MobInstance()
        {
            mobSprites = new int[][] {
                new int[] { 3, 2, 1 },
                new int[] { 4, -1, 0 },
                new int[] { 5, 6, 7 }
            };
            mobSprite = 1;
            combatLevel = 3;
            HasAppearanceChanged = true;
            AppearanceId = 0;
            LastMovementTime = Helper.CurrentTimeMillis();
            activatedPrayers = new bool[14];
            LastCombatState = CombatState.Waiting;

            pathHandler = new PathHandler(this);

            totalDamageTable = new Dictionary<long, int>();
            meleeDamageTable = new Dictionary<long, int>();
            rangeDamageTable = new Dictionary<long, int>();
        }

        public void UpdateKillStealing(long index, int damage, AttackType attackType)
        {
            if (totalDamageTable.ContainsKey(index))
            {
                totalDamageTable[index] += damage;
            }
            else
            {
                totalDamageTable.Add(index, damage);
            }

            switch (attackType)
            {
                case AttackType.Melee:
                    if (meleeDamageTable.ContainsKey(index))
                    {
                        meleeDamageTable[index] += damage;
                        return;
                    }

                    meleeDamageTable.Add(index, damage);
                    break;

                case AttackType.Ranged:
                    if (rangeDamageTable.ContainsKey(index))
                    {
                        rangeDamageTable[index] += damage;
                        return;
                    }

                    rangeDamageTable.Add(index, damage);
                    break;
            }
        }

        public abstract void Remove();

        public void ResetCombat()
        {
            throw new NotImplementedException();
        }

        public void ResetPath()
        {
            pathHandler.ResetPath();
        }

        public bool IsAtObject()
        {
            throw new NotImplementedException();
        }

        public bool IsPrayerActivated(int prayerIndex)
        {
            return activatedPrayers[prayerIndex];
        }

        public void TogglePrayer(int prayerIndex, bool toggleStatus)
        {
            activatedPrayers[prayerIndex] = toggleStatus;
        }

        public void UpdateAppearanceId()
        {
            if (HasAppearanceChanged)
            {
                AppearanceId += 1;
            }
        }

        public void UpdateCombatTime()
        {
            CombatTime = Helper.CurrentTimeMillis();
        }

        public void UpdateLocation()
        {
            pathHandler.UpdateLocation();
        }

        public void UpdateMovementTime()
        {
            LastMovementTime = Helper.CurrentTimeMillis();
        }

        public override void SetLocation(Point2D location)
        {
            SetLocation(location, false);
        }

        public void SetLocation(Point2D location, bool teleported)
        {
            if (!teleported)
            {
                UpdateSprite(location);
                HasMoved = true;
            }

            UpdateMovementTime();
            WarnedToMove = false;
            base.SetLocation(location);
        }

        public bool FinishedPath()
        {
            return pathHandler.FinishedPath();
        }

        public void SetPath(WalkPath path)
        {
            pathHandler.SetPath(path);
        }

        protected void UpdateSprite(Point2D newLocation)
        {
            try
            {
                Point2D index = new Point2D(
                    Location.X - newLocation.X + 1,
                    Location.Y - newLocation.Y + 1);

                MobSprite = mobSprites[index.X][index.Y];
            }
            catch (Exception ex)
            {
                // TODO: Use logger
                Console.WriteLine(ex);
            }
        }
    }
}
