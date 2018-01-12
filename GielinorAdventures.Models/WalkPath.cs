using NuciXNA.Primitives;

namespace GielinorAdventures.Models
{
    public class WalkPath
    {
        readonly Point2D[] waypointOffsets;

        /// <summary>
        /// Gets or sets the start location.
        /// </summary>
        /// <value>The start location.</value>
        public Point2D StartLocation { get; set; }

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>
        public int Length => waypointOffsets.Length;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalkPath"/> class.
        /// </summary>
        /// <param name="startLocation">Start location.</param>
        /// <param name="waypointOffsets">Waypoint offsets.</param>
        public WalkPath(Point2D startLocation, Point2D[] waypointOffsets)
        {
            StartLocation = startLocation;
            this.waypointOffsets = waypointOffsets;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WalkPath"/> class.
        /// </summary>
        /// <param name="location">Location.</param>
        /// <param name="destination">Destination.</param>
        public WalkPath(Point2D location, Point2D destination)
        {
            StartLocation = destination;
            waypointOffsets = new Point2D[0];
        }

        /// <summary>
        /// Gets the waypoint.
        /// </summary>
        /// <returns>The waypoint.</returns>
        /// <param name="waypointIndex">Waypoint index.</param>
        public Point2D GetWaypoint(int waypointIndex)
        {
            return StartLocation + waypointOffsets[waypointIndex];
        }

        /// <summary>
        /// Gets the waypoint offset.
        /// </summary>
        /// <returns>The waypoint offset.</returns>
        /// <param name="waypointIndex">Waypoint index.</param>
        public Point2D GetWaypointOffset(int waypointIndex)
        {
            if (waypointIndex >= Length)
            {
                return Point2D.Empty;
            }

            return waypointOffsets[waypointIndex];
        }
    }
}
