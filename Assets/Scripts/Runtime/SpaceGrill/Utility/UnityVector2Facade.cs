using UnityEngine;

namespace SpaceGrill.Utility
{
    public class UnityVector2Facade : Vector
    {
        private UnityVector2Facade(Vector2 vector)
            :base(vector.x, vector.y)
        {
        }

        public static Vector FromUnityVector(Vector2 vector)
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
    }
}
