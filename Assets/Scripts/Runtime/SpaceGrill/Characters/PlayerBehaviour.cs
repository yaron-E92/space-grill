using SpaceGrill.Utility;

using UnityEngine;

using VContainer;

namespace SpaceGrill.Characters
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _walkingAnimationCoefficient = 0.1F;

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

        //private Collider Collider;

        //readonly Dictionary<PlayerMode, Color> modeToColor = new Dictionary<PlayerMode, Color>()
        //{ {PlayerMode.FreeMovementMode, Color.green }, {PlayerMode.BuilderMode, Color.red } };

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
            //_animator.SetBool("IsWalking", IsWalking);

            //if (IsWalking)
            //{
            //    _animator.SetFloat("Speed", _playerController.Speed * _walkingAnimationCoefficient);
            //}

            _rigidBody.velocity = new Vector2(velocity.X, _rigidBody.velocity.y);
            if (isPulsing )
            {
                _rigidBody.AddForce(_pulseForce);
            }

            if (transform.position.y < -5.5f || transform.position.y > 4.5f)
            {
                ((UnityVector2Facade)(transform.position.x, 4.5f)).TranslateUnityTransformToThis(transform);
            }
        }

        //internal void OnModeToggled(PlayerMode mode)
        //{
        //    gameObject.GetComponent<MeshRenderer>().material.color = modeToColor[mode];
        //}
    }
}
