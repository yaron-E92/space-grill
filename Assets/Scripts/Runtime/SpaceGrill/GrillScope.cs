using SpaceGrill.Characters;
using SpaceGrill.Utility;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SpaceGrill
{
    public class GrillScope : LifetimeScope
    {
        [SerializeField]
        private GameObject _sausagePrefab;

        [SerializeField]
        private ScoreTrackerBehaviour _scoreTrackerBehaviour;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_scoreTrackerBehaviour);
            builder.RegisterEntryPoint<Grillable>().WithParameter(_sausagePrefab)
                .WithParameter(_scoreTrackerBehaviour);
        }
    }
}
