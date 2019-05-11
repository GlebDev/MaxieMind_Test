using UnityEngine;

public static class InputManager
{
    public static bool IsMobile {
        get {
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
            return false;
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            return true;
#endif
        }
    }

    public static bool CursorDown {
        get {
            if (IsMobile)
                return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
            else
                return Input.GetMouseButtonDown(0);
        }
    }

    public static bool CursorPressed
    {
        get
        {
            if (IsMobile)
                return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
            else
                return Input.GetMouseButton(0);
        }
    }

    public static Vector2 CursorPoint
    {
        get
        {
            if (IsMobile)
                return Input.touchCount > 0 ? Input.GetTouch(0).position : Vector2.zero;
            else
                return Input.mousePosition;
        }
    }
}
