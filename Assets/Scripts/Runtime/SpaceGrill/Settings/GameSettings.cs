using UnityEngine;

namespace SpaceGrill.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public PhysicsSettings physicsSettings;

        public int GrillProgressRate;
        public float GrillDarkeningAmount;
        public float Threshold;
    }
}
