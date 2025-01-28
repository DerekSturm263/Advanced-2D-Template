using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Text
{
    public abstract class TMPTextEffect : ScriptableObject
    {
        public abstract void ModifyTextMesh(TMPro.TMP_TextInfo textInfo, List<Vector3> allVertices, float deltaTime, float time);
    }
}
