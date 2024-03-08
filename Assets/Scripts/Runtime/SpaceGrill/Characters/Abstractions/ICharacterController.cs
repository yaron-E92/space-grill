using SpaceGrill.Utility;

using VContainer.Unity;

namespace SpaceGrill.Characters
{
    public interface ICharacterController : IInitializable, ITickable
    {
        IVector Acceleration { get; }
        IVector Velocity { get; }
        bool IsMoving { get; }
        float Speed { get; }
    }
}
