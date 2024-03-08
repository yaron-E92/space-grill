using SpaceGrill.Settings;
using SpaceGrill.Utility;
using UnityEngine;

using VContainer;

namespace SpaceGrill.Characters
{
    public class PlayerController : ICharacterController
    {
        private Vector3 _acceleration;
        private Vector3 _velocity;
        private readonly PlayerBehaviour _playerBehaviour;
        private readonly PhysicsSettings _physicsSettings;

        /// <summary>
        /// Max speed of the player.
        /// </summary>
        [SerializeField]
        private float _maxSpeed = 10;

        private float _speed;
        private AccelerationFlags _isAccelerating;

        public Vector3 Acceleration => _acceleration;

        public Vector3 Velocity => _velocity;
        public bool IsWalking => _isAccelerating.InX || _isAccelerating.InZ;

        public float Speed => _speed;

        //public PlayerMode Mode { get; private set; } = PlayerMode.FreeMovementMode;

        //public delegate void ColorSwap(PlayerMode mode);
        //public event ColorSwap ModeToggled;

        private IPlayerInput _playerInput;

        private readonly CameraBehaviour _cameraBehaviour;

        [Inject]
        public PlayerController(PlayerBehaviour playerBehaviour,
                                PhysicsSettings physicsSettings,
                                IPlayerInput playerInput,
                                CameraBehaviour cameraBehaviour)
        {
            _playerBehaviour = playerBehaviour;
            //ModeToggled += _playerBehaviour.OnModeToggled;
            _physicsSettings = physicsSettings;
            _playerInput = playerInput;
            _cameraBehaviour = cameraBehaviour;
        }

        public void Initialize()
        {
            _velocity = Vector3.zero;
            _acceleration = Vector3.zero;
        }

        public void Tick()
        {
            //if (Mode == PlayerMode.FreeMovementMode)
            //{
                FreeMovementTick();
            //}

            //else if (Mode == PlayerMode.BuilderMode)
            //{
            //    BuilderTick();
            //}
        }

        private void FreeMovementTick()
        {
            //if (_playerInput.IsBPressed)
            //{
            //    //Mode = PlayerMode.BuilderMode;
            //    //ModeToggled?.Invoke(Mode);
            //    _velocity = Vector3.zero;
            //}
            //else
            //{
                ProcessMovement();
                _playerBehaviour.UpdatePosition(_velocity);
            //}
        }

        private void ProcessMovement()
        {
            GetAccelarationFromInput();

            CheckWhetherAccelerating();

            _velocity.x += _acceleration.x * Time.deltaTime;
            if (!_isAccelerating.InX)
            {
                _velocity.x -= Math.Sign(_velocity.x) * _physicsSettings.FrictionCoefficient;
                if (Math.Abs(_velocity.x) < _physicsSettings.VelocityThreshold)
                {
                    _velocity.x = 0;
                }
            }
            _velocity.z += _acceleration.z * Time.deltaTime;
            if (!_isAccelerating.InZ)
            {
                _velocity.z -= Math.Sign(_velocity.z) * _physicsSettings.FrictionCoefficient;
                if (Math.Abs(_velocity.z) < _physicsSettings.VelocityThreshold)
                {
                    _velocity.z = 0;
                }
            }

            _speed = Math.Min(_velocity.magnitude, _maxSpeed);

            _velocity = _velocity.normalized * _speed;
        }

        private void GetAccelarationFromInput()
        {
            _acceleration.x = _playerInput.GetHorizontalAxis * _physicsSettings.AccelerationCoefficient;
            _acceleration.z = _playerInput.GetVerticalAxis * _physicsSettings.AccelerationCoefficient;
        }

        private void CheckWhetherAccelerating()
        {
            _isAccelerating.InX = Math.Abs(_acceleration.x) >= _physicsSettings.AccelerationThreshold;
            _isAccelerating.InY = Math.Abs(_acceleration.y) >= _physicsSettings.AccelerationThreshold;
            _isAccelerating.InZ = Math.Abs(_acceleration.z) >= _physicsSettings.AccelerationThreshold;
        }

        private bool IsAcceleratingInDirection(char direction)
        {
            float element = direction switch
            {
                'x' => _acceleration.x,
                'z' => _acceleration.z,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
            };
            return Math.Abs(element) >= _physicsSettings.AccelerationThreshold;
        }
    }
}
