using System;
using UnityEngine;

namespace SpaceGrill.Settings
{
    [Serializable]
    public class PhysicsSettings
    {
        [SerializeField]
        private float _accelerationCoefficient = 10F;
        [SerializeField]
        private float _accelerationThreshold = 0.001F;
        [SerializeField]
        public float VelocityThreshold = 0.01f;

        public float AccelerationCoefficient => _accelerationCoefficient;

        public float AccelerationThreshold => _accelerationThreshold;
    }
}
