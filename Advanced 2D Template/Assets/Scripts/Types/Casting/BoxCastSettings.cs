using System;
using UnityEngine;

namespace Types.Casting
{
    [Serializable]
    public struct BoxCastSettings : Interfaces.ICastable
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Vector3 _size;
        [SerializeField] private Quaternion _rotation;

        public readonly RaycastHit? GetHitInfo(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction)
        {
            if (TryGetHitInfo(position, direction, maxDistance, layerMask, triggerInteraction, out RaycastHit hit))
                return hit;

            return null;
        }

        public readonly bool TryGetHitInfo(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction, out RaycastHit hit)
        {
            return Physics.BoxCast(position + _offset, _size, direction, out hit, _rotation, maxDistance, layerMask, triggerInteraction);
        }

        public readonly RaycastHit[] GetHitInfoAll(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction)
        {
            return Physics.BoxCastAll(position + _offset, _size, direction, _rotation, maxDistance, layerMask, triggerInteraction);
        }

        public readonly int GetHitInfoNonAlloc(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction, RaycastHit[] results)
        {
            return Physics.BoxCastNonAlloc(position + _offset, _size, direction, results, _rotation, maxDistance, layerMask, triggerInteraction);
        }

        public readonly void Draw(Vector3 position)
        {
            Gizmos.DrawCube(position + _offset, _size);
        }
    }
}
