using UnityEngine;

using VContainer.Unity;

namespace SpaceGrill.Characters
{
    public interface ICharacterController : IInitializable, ITickable
    {
        Vector3 Acceleration { get; }
        Vector3 Velocity { get; }
        bool IsWalking { get; }
        float Speed { get; }
    }
}
