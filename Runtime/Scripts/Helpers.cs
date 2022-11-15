using UnityEngine;
using UnityEngine.UI;

public static class Helpers
{
    public static bool SetActive_Toggle(GameObject go)
    {
        go.SetActive(!go.activeInHierarchy);
        return go.activeInHierarchy;
    }

    public static GameObject SetEnemyFacingDirection(this GameObject go, float direction)
    {
        go.transform.localScale = new Vector3(go.transform.localScale.x * Mathf.Sign(direction), 
            go.transform.localScale.y, go.transform.localScale.z);

        return go;
    }


    public static Button GetButton(this GameObject go) => go.GetComponent<Button>();

    public static Button GetButton(this Transform transform) => transform.GetComponent<Button>();
}
