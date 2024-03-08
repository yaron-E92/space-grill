using UnityEngine;

namespace SpaceGrill.Utility
{
    public class UnityVector2Facade : Vector
    {
        // To avoid unnecessary allocations every time an overriden operator is used
        static readonly UnityVector2Facade OperationsVector = new UnityVector2Facade(1, 1);

        private UnityVector2Facade(Vector2 vector)
            :base(vector.x, vector.y)
        {
        }

        private UnityVector2Facade(float x, float y)
            : base(x, y)
        {
        }

        public static UnityVector2Facade FromUnityVector(Vector2 vector)
        {
            return new UnityVector2Facade(vector);
        }

        /// <summary>
        /// Translate the <paramref name="transform"/>'s position
        /// <see cref="Vector3"/> to the X-Y coordinates of this vector
        /// </summary>
        /// <param name="transform"></param>
        public void TranslateUnityTransformToThis(Transform transform)
        {
            Vector3 transformPosition = transform.position;
            float xTranslation = X - transformPosition.x;
            float yTranslation = Y - transformPosition.y;
            transform.Translate(xTranslation, yTranslation, 0);
        }

        /// <summary>
        /// Translate the <paramref name="transform"/>'s position
        /// <see cref="Vector3"/> by the X-Y coordinates of this vector
        /// </summary>
        /// <param name="transform"></param>
        public void TranslateUnityTransformByThis(Transform transform)
        {
            transform.Translate(X, Y, 0);
        }

        public static UnityVector2Facade operator *(UnityVector2Facade vector, float multiplier)
        {
            vector.TranslateToCoordinates(vector.X * multiplier,
                vector.Y * multiplier);
            return vector;
        }

        public static implicit operator UnityVector2Facade((float x, float y) floats)
        {
            return new UnityVector2Facade(floats.x, floats.y);
        }
    }
}
