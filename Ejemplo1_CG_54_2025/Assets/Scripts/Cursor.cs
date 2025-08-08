using UnityEngine;

public class MousePositionLogger : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Mouse position: " + mousePosWorld.x + ", " + mousePosWorld.y);
    }
}