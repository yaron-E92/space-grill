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
        private float frictionCoefficient = 0.5F;
        public float VelocityThreshold => 5 * FrictionCoefficient;

        public float AccelerationCoefficient => _accelerationCoefficient;

        public float AccelerationThreshold => _accelerationThreshold;

        public float FrictionCoefficient => frictionCoefficient;
    }
}
