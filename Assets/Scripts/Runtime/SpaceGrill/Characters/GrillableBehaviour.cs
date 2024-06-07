using UnityEngine;
using VContainer;

namespace SpaceGrill
{
    public class GrillableBehaviour : MonoBehaviour
    {
        public static float DarkeningAmount { get; set; } = 0.01f;
        public bool Cooked { get; private set; } = false;

        private SpriteRenderer _renderer;

        [Inject]
        void Construct()
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void IncreaseGrill()
        {
            Color color = _renderer.color;
            if (color != Color.black)
            {
                color.r -= DarkeningAmount;
                color.g -= DarkeningAmount;
                color.b -= DarkeningAmount;
                _renderer.color = color.r >=0 ? color : Color.black;
            }
            else
            {
                Cooked = true;
            }
        }
    }
}
