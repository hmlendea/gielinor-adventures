using System;

namespace GielinorAdventures.Primitives
{
    /// <summary>
    /// 2D orthogonal coordinates structure.
    /// </summary>
    public struct Point3D : IEquatable<Point3D>
    {
        /// <summary>
        /// Gets or sets the X-axis coordinate.
        /// </summary>
        /// <value>The X-axis coordinate.</value>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y-axis coordinate.
        /// </summary>
        /// <value>The Y-axis coordinate.</value>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the Z-axis coordinate.
        /// </summary>
        /// <value>The Z-axis coordinate.</value>
        public int Z { get; set; }

        /// <summary>
        /// Gets a value indicating whether the coordinates of this <see cref="Point3D"/> are zero.
        /// </summary>
        /// <value><c>true</c> if the coorinates are zero; otherwise, <c>false</c>.</value>
        public bool IsEmpty => X == 0 && Y == 0;

        /// <summary>
        /// Gets a <see cref="Point3D"/> with the coordinates of zero.
        /// </summary>
        /// <value>The orthogonal centre point.</value>
        public static Point3D Empty => new Point3D(0, 0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D"/> structure.
        /// </summary>
        /// <param name="x">The X-axis coordinate.</param>
        /// <param name="y">The Y-axis coordinate.</param>
        /// <param name="z">The Z-axis coordinate.</param>
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Point3D"/> is equal to the current <see cref="Point3D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Point3D"/> to compare with the current <see cref="Point3D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Point3D"/> is equal to the current <see cref="Point3D"/>;
        /// otherwise, <c>false</c>.</returns>
        public bool Equals(Point3D other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(X, other.X) &&
                   Equals(Y, other.Y) &&
                   Equals(Z, other.Z);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Point3D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Point3D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="Point3D"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Point3D)obj);
        }

        /// <summary>
        /// Adds the coordinates of a <see cref="Point3D"/> to those of another <see cref="Point3D"/>,
        /// yielding a new <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to add.</param>
        /// <param name="other">The second <see cref="Point3D"/> to add.</param>
        /// <returns>The <see cref="Point3D"/> whose coordinates are the sum of the coordinates of <c>source</c> and <c>other</c>.</returns>
        public static Point3D operator +(Point3D source, Point3D other)
        => new Point3D(source.X + other.X,
                       source.Y + other.Y,
                       source.Z + other.Z);

        /// <summary>
        /// Subtracts the coordinates of a <see cref="Point3D"/> from those of another <see cref="Point3D"/>,
        /// yielding a new <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to subtract.</param>
        /// <param name="other">The second <see cref="Point3D"/> to subtract.</param>
        /// <returns>The <see cref="Point3D"/> whose coordinates are the sum of the coordinates of <c>source</c> and <c>other</c>.</returns>
        public static Point3D operator -(Point3D source, Point3D other)
        => new Point3D(source.X - other.X,
                       source.Y - other.Y,
                       source.Z - other.Z);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Point3D"/> is equal to another specified <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to compare.</param>
        /// <param name="other">The second <see cref="Point3D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Point3D source, Point3D other)
        => source.Equals(other);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Point3D"/> is not equal to
        /// another specified <see cref="Point3D"/>.
        /// </summary>
        /// <param name="source">The first <see cref="Point3D"/> to compare.</param>
        /// <param name="other">The second <see cref="Point3D"/> to compare.</param>
        /// <returns><c>true</c> if <c>source</c> and <c>other</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Point3D source, Point3D other)
        => !(source == other);

        /// <summary>
        /// Serves as a hash function for a <see cref="Point3D"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^
                        Y.GetHashCode() ^
                        Z.GetHashCode();
            }
        }
    }
}
