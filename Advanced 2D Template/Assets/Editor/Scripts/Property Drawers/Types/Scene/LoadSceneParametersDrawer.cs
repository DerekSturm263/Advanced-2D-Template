using UnityEditor;
using UnityEngine.SceneManagement;

namespace Types.Scene
{
    [CustomPropertyDrawer(typeof(LoadSceneParameters))]
    internal class LoadSceneParametersDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "m_LoadSceneMode" },
            new string[] { "m_LocalPhysicsMode" }
        };
    }
}
