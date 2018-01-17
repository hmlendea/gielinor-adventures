using Microsoft.Xna.Framework;
using NuciXNA.Graphics;
using NuciXNA.Graphics.SpriteEffects;
using NuciXNA.Primitives;

using GielinorAdventures.Models.Enumerations;

namespace GielinorAdventures.Gui.MobAnimationEffects
{
    public class HumanSpriteSheetEffect : SpriteSheetEffect
    {
        const int SpellcastFrames = 7;
        const int WalkFrames = 9;
        const int MeleeFrames = 6;
        const int RangedFrames = 13;

        public Action Action { get; set; }

        public Direction Direction { get; set; }

        public HumanSpriteSheetEffect()
        {
            FrameAmount = new Size2D(13, 21);
        }

        public override void UpdateFrame(GameTime gameTime)
        {
            Point2D newFrame = CurrentFrame;

            if (Sprite.Active)
            {
                FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (FrameCounter >= SwitchFrame)
                {
                    FrameCounter = 0;
                    newFrame.X += 1;
                }
            }
            else
            {
                newFrame.X = 0;
            }

            switch (Action)
            {
                case Action.CastingSpellOnNpc:
                case Action.CastingSpellOnGroundItem:
                    if (newFrame.X >= SpellcastFrames)
                    {
                        newFrame.X = 0;
                    }

                    newFrame.Y = 0;
                    break;

                case Action.Idle:
                    newFrame.X = 0;
                    newFrame.Y = 8;
                    break;

                case Action.Walking:
                    if (newFrame.X >= WalkFrames)
                    {
                        newFrame.X = 0;
                    }

                    newFrame.Y = 8;
                    break;

                case Action.Attacking:
                case Action.FightingMelee:
                    if (newFrame.X >= MeleeFrames)
                    {
                        newFrame.X = 0;
                    }

                    newFrame.Y = 12;
                    break;

                case Action.FightingRanged:
                    if (newFrame.X >= RangedFrames)
                    {
                        newFrame.X = 0;
                    }

                    newFrame.Y = 16;
                    break;
            }

            newFrame.Y += (int)Direction;

            CurrentFrame = newFrame;
        }
    }
}
