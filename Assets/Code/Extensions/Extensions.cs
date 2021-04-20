using UnityEngine;


namespace Extensions
{
    public static class Extensions
    {
        #region Methods

        public static T GetOrAddComponent<T>(this GameObject child) where T : Component
        {
            var component = child.GetComponent<T>();
            if (component == null)
            {
                component = child.AddComponent<T>();
            }
            return component;
        }

        public static Material ChangeAlpha(this Material material, float alphaValue)
        {
            var mat = material;
            var oldColor = material.color;
            var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
            mat.SetColor("New color", newColor);
            return mat;
        }

        public static float Angle360(Vector3 from, Vector3 to, Vector3 right)
        {
            float angle = Vector3.Angle(from, to);
            return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
        }
        #endregion
    }
}
