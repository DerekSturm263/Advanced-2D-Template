using UnityEngine;

namespace Types.Multiplayer
{
    [CreateAssetMenu(fileName = "New Profile Asset", menuName = "Multiplayer/Profile")]
    public class ProfileAsset : ScriptableObjects.Wrappers.Asset<Profile> { }
}
