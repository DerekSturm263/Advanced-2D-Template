using System;
using UnityEngine;

namespace Types.Casting
{
    [Serializable]
    public struct SphereCastSettings : Interfaces.ICastable
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _radius;

        public readonly RaycastHit? GetHitInfo(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction)
        {
            if (TryGetHitInfo(position, direction, maxDistance, layerMask, triggerInteraction, out RaycastHit hit))
                return hit;

            return null;
        }

        public readonly bool TryGetHitInfo(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction, out RaycastHit hit)
        {
            return Physics.SphereCast(position + _offset, _radius, direction, out hit, maxDistance, layerMask, triggerInteraction);
        }

        public readonly RaycastHit[] GetHitInfoAll(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction)
        {
            return Physics.SphereCastAll(position + _offset, _radius, direction, maxDistance, layerMask, triggerInteraction);
        }

        public readonly int GetHitInfoNonAlloc(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction, RaycastHit[] results)
        {
            return Physics.SphereCastNonAlloc(position + _offset, _radius, direction, results, maxDistance, layerMask, triggerInteraction);
        }

        public readonly void Draw(Vector3 position)
        {
            Gizmos.DrawSphere(position + _offset, _radius);
        }
    }
}
