using System;

using GielinorAdventures.Primitives;

namespace GielinorAdventures.Models
{
    public class GameEntityInstance
    {
        // world

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        public int Index { get; set; }

        public Point2D Location { get; private set; }

        public virtual void SetLocation(Point2D location)
        {
            throw new NotImplementedException();
            Location = location;
        }

        public bool IsWithinRange(GameEntityInstance other, int radius)
        {
            return IsWithinRange(other.Location, radius);
        }

        public bool IsWithinRange(Point2D location, int radius)
        {
            Point2D difference = new Point2D(
                Math.Abs(Location.X - location.X),
                Math.Abs(Location.Y - location.Y));

            return difference.X <= radius && difference.Y <= radius;
        }

        public Point2D? NextStep(Point2D myLocation, GameEntityInstance other)
        {
            if (myLocation == other.Location)
            {
                return myLocation;
            }

            Point2D newLocation = myLocation;
            bool myXblocked = false;
            bool myYblocked = false;

            if (myLocation.X > other.Location.X)
            {
                // Check right tiles left wall
                myXblocked = IsBlocking(other, new Point2D(myLocation.X - 1, myLocation.Y), 8);
                newLocation.X = myLocation.X - 1;
            }
            else if (myLocation.X < other.Location.X)
            {
                // Check left tiles right wall
                myXblocked = IsBlocking(other, new Point2D(myLocation.X + 1, myLocation.Y), 2);
                newLocation.X = myLocation.X + 1;
            }

            if (myLocation.Y > other.Location.Y)
            {
                // Check top tiles bottom wall
                myYblocked = IsBlocking(other, new Point2D(myLocation.X, myLocation.Y - 1), 4);
                newLocation.Y = myLocation.Y - 1;
            }
            else if (myLocation.Y < other.Location.Y)
            {
                // Check bottom tiles top wall
                myYblocked = IsBlocking(other, new Point2D(myLocation.X, myLocation.Y + 1), 1);
                newLocation.Y = myLocation.Y + 1;
            }

            // If both directions are blocked OR we are going straight and the direction is blocked
            if ((myXblocked && myYblocked) ||
                (myXblocked && myLocation.Y == newLocation.Y) ||
                (myYblocked && myLocation.X == newLocation.X))
            {
                return null;
            }

            bool newXblocked = false;
            bool newYblocked = false;

            if (newLocation.X > myLocation.X)
            {
                // Check destination tiles right wall
                newXblocked = IsBlocking(other, newLocation, 2);
            }
            else if (newLocation.X < myLocation.X)
            {
                // Check destination tiles left wall
                newXblocked = IsBlocking(other, newLocation, 8);
            }

            if (newLocation.Y > myLocation.Y)
            {
                // Check destination tiles top wall
                newYblocked = IsBlocking(other, newLocation, 1);
            }
            else if (newLocation.Y < myLocation.Y)
            {
                // Check destination tiles bottom wall
                newYblocked = IsBlocking(other, newLocation, 4);
            }

            // If both directions are blocked OR we are going straing and the direction is blocked
            if ((newXblocked && newYblocked) ||
                (newXblocked && myLocation.Y == newLocation.Y) ||
                (myYblocked && myLocation.X == newLocation.X)) // TODO: Check: myYblocked or newYblocked
            {
                return null;
            }

            // If only one direction is blocked, but it blocks both tiles
            if ((myXblocked && newXblocked) ||
                (myYblocked && newYblocked))
            {
                return null;
            }

            return newLocation;
        }

        bool IsBlocking(GameEntityInstance other, Point2D location, int bit)
        {
            return IsMapBlocking(other, location, (byte)bit);
        }

        bool IsMapBlocking(GameEntityInstance other, Point2D location, byte bit)
        {
            throw new NotImplementedException();

            byte val = 0; // Requires the world member

            if ((val & bit) != 0)
            {
                return true;
            }

            if ((val & 16) != 0)
            {
                return true;
            }

            if ((val & 32) != 0)
            {
                return true;
            }

            // val & 64 and type
            throw new NotImplementedException();

            return false;
        }

        bool IsObjectBlocking(GameEntityInstance other, Point2D location, byte bit)
        {
            throw new NotImplementedException();
        }

        bool IsNextTo(GameEntityInstance other)
        {
            Point2D? currentLocation = Location;

            while (currentLocation != other.Location)
            {
                currentLocation = NextStep((Point2D)currentLocation, other);

                if (currentLocation == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
