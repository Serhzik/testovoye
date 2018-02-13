using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
    public Camera Hard, FreeLook;
    public event Action<bool> SwitchCamera;
    bool isFreeLook = false;
    public void SwitchCam()
    {
        if (isFreeLook)
        {
            isFreeLook = false;
        }
        else
        {
            isFreeLook = true;
        }
        SetCam();
    }
    void SetCam()
    {
        FreeLook.gameObject.SetActive(isFreeLook);
        Hard.gameObject.SetActive(!isFreeLook);
        if (SwitchCamera != null)
            SwitchCamera(isFreeLook);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
