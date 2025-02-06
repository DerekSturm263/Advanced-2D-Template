using Types.Camera;
using Types.Casting;
using Types.Miscellaneous;
using Types.Scene;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Types.Collections.Dictionary<string, GameObject> namesToObjects;
    public Types.Wrappers.Nullable<ScriptableObject> optionalSO;
    public CameraSettings settings;
    public Grid g1;
    public Any any;
    public Caster groundedCast;
    public SceneLoadSettings sceneSettings;
}
