using UnityEngine;

namespace Helpers
{
    public static class MathHelper
    {
        public static T Lerp<T>(T a, T b, float t) where T : Interfaces.ILerpable<T> => a.Lerp(b, t);

        public static float Sign(float f)
        {
            if (f != 0)
                return Mathf.Sign(f);
            else
                return 0;
        }

        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            return new
            (
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y)
            );
        }

        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            return new
            (
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y),
                Mathf.Clamp(value.z, min.z, max.z)
            );
        }
    }
}
