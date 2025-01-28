using UnityEngine;

namespace Types.Casting
{
    [System.Serializable]
    public struct RaycastSettings : Interfaces.ICastable
    {
        public readonly RaycastHit? GetHitInfo(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction)
        {
            if (TryGetHitInfo(position, direction, maxDistance, layerMask, triggerInteraction, out RaycastHit hit))
                return hit;

            return null;
        }

        public readonly bool TryGetHitInfo(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction, out RaycastHit hit)
        {
            return Physics.Raycast(position, direction, out hit, maxDistance, layerMask, triggerInteraction);
        }

        public readonly RaycastHit[] GetHitInfoAll(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction)
        {
            return Physics.RaycastAll(position, direction, maxDistance, layerMask, triggerInteraction);
        }

        public readonly int GetHitInfoNonAlloc(Vector3 position, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction, RaycastHit[] results)
        {
            return Physics.RaycastNonAlloc(position, direction, results, maxDistance, layerMask, triggerInteraction);
        }

        public readonly void Draw(Vector3 position)
        {

        }
    }
}
