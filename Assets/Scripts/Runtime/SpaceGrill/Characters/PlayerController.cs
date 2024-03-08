using SpaceGrill.Settings;
using SpaceGrill.Utility;
using System;

using VContainer;

namespace SpaceGrill.Characters
{
    public class PlayerController : ICharacterController
    {
        private Vector _acceleration;
        private Vector _velocity;
        private readonly PlayerBehaviour _playerBehaviour;
        private readonly PhysicsSettings _physicsSettings;

        /// <summary>
        /// Max speed of the player.
        /// </summary>
        private float MaxXSpeed => _playerBehaviour.MaxXSpeed;

        private float _speed;
        private AccelerationFlags _isAccelerating;

        public IVector Acceleration => _acceleration;

        public IVector Velocity => _velocity;
        public bool IsMoving => _isAccelerating.InX || _isAccelerating.InY;

        public float Speed => _speed;

        //public PlayerMode Mode { get; private set; } = PlayerMode.FreeMovementMode;

        //public delegate void ColorSwap(PlayerMode mode);
        //public event ColorSwap ModeToggled;

        private IPlayerInput _playerInput;

        private readonly CameraBehaviour _cameraBehaviour;

        [Inject]
        public PlayerController(PlayerBehaviour playerBehaviour,
                                PhysicsSettings physicsSettings,
                                IPlayerInput playerInput)
        {
            _playerBehaviour = playerBehaviour;
            //ModeToggled += _playerBehaviour.OnModeToggled;
            _physicsSettings = physicsSettings;
            _playerInput = playerInput;
        }

        public void Initialize()
        {
            _velocity = new Vector(0, 0);
            _acceleration = new Vector(0, 0);
        }

        public void Tick()
        {
            FreeMovementTick();
        }

        private void FreeMovementTick()
        {
            ProcessMovement();
            _playerBehaviour.UpdateVelocity(_velocity, _playerInput.IsSpacePressed);
        }

        private void ProcessMovement()
        {
            GetAccelarationFromInput();

            CheckWhetherAccelerating();

            _velocity.Translate(_acceleration * _playerBehaviour.DeltaTime);
            if (!_isAccelerating.InX)
            {
                _velocity.TranslateToCoordinates(0, _velocity.Y);
            }

            float currentSpeed = _velocity.Magnitude;
            _speed = Math.Min(currentSpeed, MaxXSpeed);

            if (_speed != currentSpeed)
            {
                _velocity *= _speed / currentSpeed;
            }
            else if (currentSpeed < _physicsSettings.VelocityThreshold)
            {
                _velocity.TranslateToCoordinates(0, 0);
            }
        }

        private void GetAccelarationFromInput()
        {
            float xAccelrationInput =
                _playerInput.GetHorizontalAxis * _physicsSettings.AccelerationCoefficient;
            _acceleration.TranslateToCoordinates(xAccelrationInput, 0);
        }

        private void CheckWhetherAccelerating()
        {
            _isAccelerating.InX = Math.Abs(_acceleration.X) >= _physicsSettings.AccelerationThreshold;
            _isAccelerating.InY = Math.Abs(_acceleration.Y) >= _physicsSettings.AccelerationThreshold;
        }
    }
}
