using UnityEngine;

namespace SingletonBehaviours
{
    public class VFXController : Types.SingletonBehaviour<VFXController>
    {
        private bool _isEnabled = true;
        public bool IsEnabled => _isEnabled;
        public void SetIsEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;

            // TODO: Uncomment
            /*foreach (ConditionalEnable component in FindObjectsByType<ConditionalEnable>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
            {
                component.enabled = _isEnabled;
            }*/
        }

        public void SpawnEffect(Types.VFX.VFXAsset vfx) => SpawnEffect(vfx.Value);

        public void SpawnEffect(Types.VFX.VFX vfx)
        {
            if (!_isEnabled)
                return;

            GameObject effect = Instantiate(vfx.VFXObject, vfx.Offset, Quaternion.identity);

            effect.transform.right = vfx.Direction.normalized;
            effect.transform.localScale = Vector3.Scale(effect.transform.localScale, vfx.ScaleMultiplier);
            effect.transform.localPosition += vfx.Offset;

            Debug.Log($"Spawning VFX {vfx.VFXObject.name}");
            return;
        }
    }
}
