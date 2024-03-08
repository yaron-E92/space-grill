using UnityEngine;

using VContainer;

namespace SpaceGrill.Utility
{
    public class CameraBehaviour : MonoBehaviour
    {
        private GameObject _followedGameObject;

        private GameObject _player;

        private Vector3 _updatedPosition;

        [Inject]
        public void Construct(GameObject player)
        {
            _followedGameObject = player;
            _player = player;
            _updatedPosition = transform.position;
        }

        // Update is called once per frame
        public void Update()
        {
            _updatedPosition.x = _followedGameObject.transform.position.x;
            _updatedPosition.z = _followedGameObject.transform.position.z - 15;
            transform.position = _updatedPosition;
        }

        public void FollowObject(GameObject objectToFollow)
        {
            _followedGameObject = objectToFollow;
        }

        public void AttachBackToPlayer()
        {
            _followedGameObject = _player;
        }
    }
}
