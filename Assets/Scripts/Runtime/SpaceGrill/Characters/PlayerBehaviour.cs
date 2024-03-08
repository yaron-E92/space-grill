using System.Collections.Generic;

using UnityEngine;

using VContainer;

namespace SpaceGrill.Characters
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _walkingAnimationCoefficient = 0.1F;

        //private Collider Collider;

        //readonly Dictionary<PlayerMode, Color> modeToColor = new Dictionary<PlayerMode, Color>()
        //{ {PlayerMode.FreeMovementMode, Color.green }, {PlayerMode.BuilderMode, Color.red } };

        private Animator _animator;

        //private bool IsWalking => _playerController.IsWalking;

        [Inject]
        void Construct(Animator animator)
        {
            _animator = animator;
        }

        // Update is called once per frame
        internal void UpdatePosition(Vector3 velocity)
        {
            //_animator.SetBool("IsWalking", IsWalking);

            //if (IsWalking)
            //{
            //    _animator.SetFloat("Speed", _playerController.Speed * _walkingAnimationCoefficient);
            //}

            transform.Translate(velocity * Time.deltaTime);
        }

        //internal void OnModeToggled(PlayerMode mode)
        //{
        //    gameObject.GetComponent<MeshRenderer>().material.color = modeToColor[mode];
        //}
    }
}
