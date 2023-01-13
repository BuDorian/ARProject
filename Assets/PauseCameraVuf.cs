using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class PauseCameraVuf : MonoBehaviour
{
    public Toggle toogle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PausePlayVufCam()
    {
        VuforiaBehaviour.Instance.enabled = toogle.isOn;
    }
}
