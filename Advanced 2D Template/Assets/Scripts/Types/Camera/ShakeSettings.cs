using System;
using UnityEngine;

namespace Types.Camera
{
    [Serializable]
    public struct ShakeSettings
    {
        [SerializeField] private AnimationCurve _relativeVerticalCurve;
        public readonly float EvaluateRelativeVertical(float t) => _relativeVerticalCurve.Evaluate(t);

        [SerializeField] private AnimationCurve _relativeHorizontalCurve;
        public readonly float EvaluateRelativeHorizontal(float t) => _relativeHorizontalCurve.Evaluate(t);

        [SerializeField] private float _length;
        public readonly float Length => _length;

        [SerializeField] private float _strength;
        public readonly float Strength => _strength;

        [SerializeField] private float _frequency;
        public readonly float Frequency => _frequency;
    }
}
