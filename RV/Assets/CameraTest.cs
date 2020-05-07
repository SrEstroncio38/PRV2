using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class CameraTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    #if PLATFORM_ANDROID
            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone) && !Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Microphone);
                Permission.RequestUserPermission(Permission.Camera);
        }
    #endif
    }
}
