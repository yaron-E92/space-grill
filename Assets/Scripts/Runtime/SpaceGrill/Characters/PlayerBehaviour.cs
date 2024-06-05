using SpaceGrill.Utility;
using System;
using UnityEngine;

using VContainer;

namespace SpaceGrill.Characters
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private const float ScreenWidthMinusPlayerRadius = 9.5f;
        private const float ScreenHeightMinusPlayerRadius = 4.5f;
        private const float PlayerDiameter = 1.0f;

        /// <summary>
        /// Max speed of the player.
        /// </summary>
        [SerializeField]
        private float _maxXSpeed = 10;

        public float MaxXSpeed => _maxXSpeed;

        public float DeltaTime => Time.deltaTime;

        private Rigidbody2D _rigidBody;

        [SerializeField]
        private float _pulseMagnitude = 500;

        private Vector2 _pulseForce;

        private Animator _animator;

        [Inject]
        void Construct(Animator animator)
        {
            _animator = animator;
            _rigidBody = GetComponent<Rigidbody2D>();
            _pulseForce = new Vector2(0, _pulseMagnitude);
        }

        // Update is called once per frame
        internal void UpdateVelocity(Vector velocity, bool isPulsing)
        {
            _rigidBody.velocity = new Vector2(velocity.X, _rigidBody.velocity.y);
            if (isPulsing)
            {
                _rigidBody.AddForce(_pulseForce);
            }

            if (transform.position.y < -ScreenHeightMinusPlayerRadius - PlayerDiameter || transform.position.y > ScreenHeightMinusPlayerRadius)
            {
                ((UnityVector2Facade)(transform.position.x, ScreenHeightMinusPlayerRadius)).TranslateUnityTransformToThis(transform);
            }

            if (transform.position.x < -ScreenWidthMinusPlayerRadius || transform.position.x > ScreenWidthMinusPlayerRadius)
            {

                ((UnityVector2Facade)(Math.Sign(transform.position.x) * ScreenWidthMinusPlayerRadius, transform.position.y)).TranslateUnityTransformToThis(transform);
            }
        }
    }
}
