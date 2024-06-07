using SpaceGrill.Characters;
using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace SpaceGrill
{
    public class GrillScope : LifetimeScope
    {
        [SerializeField]
        private GameObject _sausagePrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Grillable>().WithParameter(_sausagePrefab);
        }
    }
}
