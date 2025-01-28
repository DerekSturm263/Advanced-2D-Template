using System;
using UnityEngine;

namespace Types.Casting
{
    [Serializable]
    public struct Caster
    {
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _maxDistance;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private QueryTriggerInteraction _triggerInteraction;

        [SerializeField] private Miscellaneous.Variant<BoxCastSettings, SphereCastSettings, CapsuleCastSettings, RaycastSettings> _settings;

        public readonly RaycastHit? GetHitInfo(Transform transform)
        {
            return _settings.Get<Interfaces.ICastable>().GetHitInfo(transform.position, _direction, _maxDistance, _layerMask, _triggerInteraction);
        }

        public readonly bool TryGetHitInfo(Transform transform, out RaycastHit hit)
        {
            return _settings.Get<Interfaces.ICastable>().TryGetHitInfo(transform.position, _direction, _maxDistance, _layerMask, _triggerInteraction, out hit);
        }

        public readonly RaycastHit[] GetHitInfoAll(Transform transform)
        {
            return _settings.Get<Interfaces.ICastable>().GetHitInfoAll(transform.position, _direction, _maxDistance, _layerMask, _triggerInteraction);
        }

        public readonly int GetHitInfoNonAlloc(Transform transform, RaycastHit[] results)
        {
            return _settings.Get<Interfaces.ICastable>().GetHitInfoNonAlloc(transform.position, _direction, _maxDistance, _layerMask, _triggerInteraction, results);
        }

        public readonly void Draw(Transform transform)
        {
            _settings.Get<Interfaces.ICastable>().Draw(transform.position);
        }
    }
}
