using GoogleVR.PermissionsDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class CameraTest : MonoBehaviour
{
    GameObject dialog = null;

    void Start()
    {
#if PLATFORM_ANDROID
        if (!GvrPermissionsRequester.Instance.IsPermissionGranted("Camera"))
        {
            string[] permissions = {"Camera"};
            GvrPermissionsRequester.Instance.RequestPermissions(permissions, null);
        }
#endif
    }
}
