using VContainer.Unity;

namespace SpaceGrill.Characters
{
    public interface IGrillable : ITickable
    {
        int[] GrillProgress { get; }
    }
}
