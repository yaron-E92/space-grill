using System;

namespace SpaceGrill.Utility
{
    public class Vector : IVector
    {
        // To avoid unnecessary allocations every time an overriden operator is used
        static readonly Vector OperationsVector = new Vector(1, 1);
        public float X { get; private set; }

        public float Y { get; private set; }

        public float Magnitude => (float)Math.Sqrt((X * X) + (Y * Y));

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector vector &&
                   X == vector.X &&
                   Y == vector.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 373119288;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Vector2({X}, {Y})";
        }

        public void Translate(float x, float y)
        {
            X += x;
            Y += y;
        }

        public void Translate(IVector vector)
        {
            X += vector.X;
            Y += vector.Y;
        }

        public void TranslateToAnotherVector(IVector vector)
        {
            TranslateToCoordinates(vector.X, vector.Y);
        }

        public void TranslateToCoordinates(float x, float y)
        {
            float xTranslation = x - X;
            float yTranslation = y - Y;
            Translate(xTranslation, yTranslation);
        }

        public static Vector operator *(Vector vector, int multiplier)
        {
            return vector * (float) multiplier;
        }

        public static Vector operator *(Vector vector, float multiplier)
        {
            vector.TranslateToCoordinates(vector.X * multiplier,
                vector.Y * multiplier);
            return vector;
        }

        public static Vector operator /(Vector vector, int divider)
        {
            return vector / (float) divider;
        }

        public static Vector operator /(Vector vector, float divider)
        {
            vector.TranslateToCoordinates(vector.X / divider,
                vector.Y / divider);
            return vector;
        }

        /// <summary>
        /// Vector addition with the '+' operator
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns>A vector representing the result</returns>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            OperationsVector.TranslateToCoordinates(vector1.X + vector2.X,
                vector1.Y + vector2.Y);
            return OperationsVector;
        }

        /// <summary>
        /// Vector addition with the '+' operator where the second
        /// vector is implicit (i.e. just 3 floats grouped together).
        /// </summary>
        /// <param name="vector">A vector to add to</param>
        /// <param name="implicitVector">floats representing the additions
        /// to be applied to the vector's components</param>
        /// <returns>A vector representing the result</returns>
        /// <remarks>We have this overload to allow for simple on the
        /// fly and readable additions without having to do a cast which
        /// allocates an unnecessary vector</remarks>
        public static Vector operator +(Vector vector, (float x, float y) implicitVector)
        {
            OperationsVector.TranslateToCoordinates(vector.X + implicitVector.x,
                vector.Y + implicitVector.y);
            return OperationsVector;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return vector1 + (-vector2);
        }

        public static Vector operator -(Vector vector)
        {
            OperationsVector.TranslateToCoordinates(-vector.X,
                -vector.Y);
            return OperationsVector;
        }

        public static implicit operator Vector((float x, float y) floats)
        {
            return new Vector(floats.x, floats.y);
        }

        public static implicit operator Vector((int x, int y) ints)
        {
            return new Vector(ints.x, ints.y);
        }
    }
}