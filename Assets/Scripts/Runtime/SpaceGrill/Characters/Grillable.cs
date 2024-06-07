using SpaceGrill.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SpaceGrill.Characters
{
    public class Grillable : IGrillable
    {
        public int[] GrillProgress { get; private set; } = { 0, 0 };

        private float ParentLocation => _positionOfSausage.y;
        private readonly float Threshold = 0.18f;
        private const int GrillCheckpointSpacing = 100;
        private readonly int ProgressRate = 1;
        private GrillableBehaviour[] _grillableBehaviours;

        private readonly Vector3 _positionOfSausage = new Vector3(0, -2);
        private readonly Quaternion _startingRotationOfSausage = Quaternion.Euler(0, 0, -90);

        private readonly GameObject _sausagePrefab;
        private GameObject _currentSausage;

        private readonly IObjectResolver _container;

        [Inject]
        public Grillable(IObjectResolver container, GameObject sausagePrefab, GameSettings settings)
        {
            _container = container;
            _sausagePrefab = sausagePrefab;
            ProgressRate = settings.GrillProgressRate;
            Threshold = settings.Threshold;
            GrillableBehaviour.DarkeningAmount = settings.GrillDarkeningAmount;
            MakeNewSausage(true);
        }

        public void Tick()
        {
            if (_grillableBehaviours[0].gameObject.transform.position.y <= ParentLocation - Threshold)
            {
                GrillProgress[0] += ProgressRate;
            }
            else if (_grillableBehaviours[1].gameObject.transform.position.y <= ParentLocation - Threshold)
            {
                GrillProgress[1] += ProgressRate;
            }

            if (GrillProgress[0] != 0 && GrillProgress[0] % GrillCheckpointSpacing == 0)
            {
                _grillableBehaviours[0].IncreaseGrill();
            }
            if (GrillProgress[1] != 0 && GrillProgress[1] % GrillCheckpointSpacing == 0)
            {
                _grillableBehaviours[1].IncreaseGrill();
            }

            if(_grillableBehaviours[0].Cooked && _grillableBehaviours[1].Cooked)
            {
                MakeNewSausage(false);
            }
        }

        private void MakeNewSausage(bool isFirstSausage)
        {
            if (!isFirstSausage)
            {
                UnityEngine.Object.Destroy(_currentSausage);
                GrillProgress = new int[] { 0, 0 };
            }
            _currentSausage = _container.Instantiate(_sausagePrefab, _positionOfSausage, _startingRotationOfSausage);
            _grillableBehaviours =
                _currentSausage.GetComponentsInChildren<GrillableBehaviour>();
        }
    }
}
