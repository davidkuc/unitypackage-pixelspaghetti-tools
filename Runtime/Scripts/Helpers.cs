using UnityEngine;
using UnityEngine.UI;

public static class Helpers
{
    public static bool SetActive_Toggle(GameObject go)
    {
        go.SetActive(!go.activeInHierarchy);
        return go.activeInHierarchy;
    }

    public static GameObject
    SetEnemyFacingDirection(this GameObject go, float direction)
    {
        go.transform.localScale =
            new Vector3(go.transform.localScale.x * Mathf.Sign(direction),
                go.transform.localScale.y,
                go.transform.localScale.z);

        return go;
    }

    public static Button GetButton(this GameObject go) =>
        go.GetComponent<Button>();

    public static Button GetButton(this Transform transform) =>
        transform.GetComponent<Button>();

    public static Vector2
    GetDirection(Vector3 startPosition, Vector3 endPosition) =>
        (endPosition - startPosition).normalized;


#region Coloring Debug.Log()
    public static string ToHex(this Color color)
    {
        return string
            .Format("#{0:X2}{1:X2}{2:X2}",
            ToByte(color.r),
            ToByte(color.g),
            ToByte(color.b));
    }

    private static byte ToByte(float f)
    {
        f = Mathf.Clamp01(f);
        return (byte)(f * 255);
    }

    public static string Color(this string text, Color color)
    {
        string output;
        output = string.Format("<color={0}>{1}</color>", color.ToHex(), text);
        return output;
    }
#endregion

#region Sound

    public static float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }

    public static float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);

        return linear;
    }
#endregion
}
