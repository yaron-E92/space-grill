using SpaceGrill.Characters;
using SpaceGrill.Settings;
using SpaceGrill.Utility;

using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace SpaceGrill
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private GameSettings settings;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_animator);
            builder.RegisterComponent(_player);
            builder.RegisterInstance(settings);
            builder.RegisterInstance(settings.physicsSettings);
            builder.Register<UnityInputFacade>(Lifetime.Singleton).As<IPlayerInput>();
            builder.RegisterEntryPoint<PlayerController>(Lifetime.Singleton).As<ICharacterController>();
            builder.RegisterComponentInHierarchy<PlayerBehaviour>().WithParameter(_animator);
        }
    }
}
