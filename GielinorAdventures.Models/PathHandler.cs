using System;

using GielinorAdventures.Primitives;

namespace GielinorAdventures.Models
{
    public class PathHandler
    {
        public WalkPath Path { get; private set; }

        int currentWaypoint;
        MobInstance mob;
        // world

        public PathHandler(MobInstance mob)
        {
            this.mob = mob;
            ResetPath();
        }

        public void SetPath(Point2D startLocation, Point2D waypointOffsets)
        {
            WalkPath path = new WalkPath(startLocation, waypointOffsets);
            SetPath(path);
        }

        public void SetPath(WalkPath path)
        {
            currentWaypoint = -1;
            Path = path;
        }

        public void UpdateLocation()
        {
            if (!FinishedPath())
            {
                SetNextPosition();
            }
        }

        public bool FinishedPath()
        {
            if (Path == null)
            {
                return true;
            }

            if (Path.Length > 0)
            {
                return AtWaypoint(Path.Length - 1);
            }

            return AtStart();
        }

        public void ResetPath()
        {
            Path = null;
            currentWaypoint = -1;
        }

        protected bool AtStart()
        {
            return Path.StartLocation == mob.Location;
        }

        protected bool AtWaypoint(int waypoint)
        {
            return Path.GetWaypoint(waypoint).X == mob.Location.X &&
                   Path.GetWaypoint(waypoint).Y == mob.Location.Y;
        }

        protected Point2D GetNextPosition(Point2D start, Point2D destination)
        {
            try
            {
                Point2D location = start;

                bool myXblocked = false;
                bool myYblocked = false;

                if (start.X > destination.X)
                {
                    // Check right tiles left wall
                    myXblocked = IsBlocking(new Point2D(start.X - 1, start.Y), 8);
                    location.X = start.X - 1;
                }
                else if (start.X < destination.X)
                {
                    // Check left tiles right wall
                    myXblocked = IsBlocking(new Point2D(start.X + 1, start.Y), 2);
                    location.X = start.X + 1;
                }

                if (start.Y > destination.Y)
                {
                    // Check top tiles bottom wall
                    myYblocked = IsBlocking(new Point2D(start.X, start.Y - 1), 4);
                    location.Y = start.Y - 1;
                }
                else if (start.Y < destination.Y)
                {
                    // Check bottom tiles top wall
                    myYblocked = IsBlocking(new Point2D(start.X, start.Y + 1), 1);
                    location.Y = start.Y + 1;
                }

                // If both directions are blocked OR we are going straight and the direction is blocked
                if ((myXblocked && myYblocked) ||
                    (myXblocked && start.Y == destination.Y) ||
                    (myYblocked && start.X == destination.X))
                {
                    return CancelLocation();
                }

                bool newXblocked = false;
                bool newYblocked = false;

                if (location.X > start.X)
                {
                    // Check destination tiles right wall
                    newXblocked = IsBlocking(location, 2);
                }
                else if (location.X < start.X)
                {
                    // Check destination tiles left wall
                    newXblocked = IsBlocking(location, 8);
                }

                if (location.Y > start.Y)
                {
                    // Check destination tiles top wall
                    newYblocked = IsBlocking(location, 1);
                }
                else if (location.Y < start.Y)
                {
                    // Check destination tiles bottom wall
                    newYblocked = IsBlocking(location, 4);
                }

                // If both directions are blocked OR we are going straight and the direction is blocked
                if ((newXblocked && newYblocked) ||
                    (newXblocked && start.Y == location.Y) ||
                    (myYblocked && newYblocked))
                {
                    return CancelLocation();
                }

                // If only one direction is blocked, but it blocks both tiles
                if ((myXblocked && newXblocked) ||
                    (myYblocked && newYblocked))
                {
                    return CancelLocation();
                }

                return location;
            }
            catch (Exception ex)
            {
                // TODO: Use logger
                Console.WriteLine(ex);
            }

            return start;
        }

        protected void SetNextPosition()
        {
            Point2D newLocation = new Point2D(-1, -1);

            if (currentWaypoint == -1)
            {
                if (AtStart())
                {
                    currentWaypoint = 0;
                }
                else
                {
                    newLocation = GetNextPosition(mob.Location, Path.StartLocation);
                }
            }

            if (currentWaypoint > -1)
            {
                if (AtWaypoint(currentWaypoint))
                {
                    currentWaypoint += 1;
                }

                if (currentWaypoint < Path.Length)
                {
                    newLocation = GetNextPosition(mob.Location, Path.GetWaypoint(currentWaypoint));
                }
                else
                {
                    ResetPath();
                }
            }

            if (newLocation.X > -1 && newLocation.Y > -1)
            {
                mob.SetLocation(newLocation);
            }
        }

        Point2D CancelLocation()
        {
            ResetPath();

            Point2D location = new Point2D(-1, -1);

            return location;
        }

        bool IsBlocking(Point2D location, int bit)
        {
            TileValue tileValue;
            throw new NotImplementedException();

            return IsBlocking(tileValue.MapValue, (byte)bit) ||
                   IsBlocking(tileValue.ObjectValue, (byte)bit);
        }

        bool IsBlocking(byte val, byte bit)
        {
            if ((val & bit) != 0)
            {
                // There is a wall in the way
                return true;
            }

            if ((val & 16) != 0)
            {
                // There is a diagonal wall here: \
                return true;
            }

            if ((val & 32) != 0)
            {
                // There is a diagonal wall here: /
                return true;
            }

            if ((val & 64) != 0)
            {
                // This tile is unwalkable
                return true;
            }

            return false;
        }
    }
}
