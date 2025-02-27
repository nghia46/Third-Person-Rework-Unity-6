using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    [SerializeField] private bool lockCursor = true;
    void Awake()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
