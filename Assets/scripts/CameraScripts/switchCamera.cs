using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class switchCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject StartCamera, playCamera, testCamera;

    private GameObject[] cameras;
    private bool[] activeCameras;
    private uint maxCameras = 3;

    private void Start()
    {
        cameras     = new GameObject[maxCameras];
        activeCameras    = new bool[maxCameras];

        cameras[0]  = StartCamera;
        activeCameras[0] = true;

        cameras[1]  = playCamera;
        activeCameras[1] = false;

        cameras[2]  =   testCamera;
        activeCameras[2] = false;

    }
    private enum CAMERAS
    {
        Start = 0,
        Play = 1,
        Test = 2,
    };

    public void changeCameraOnClick(){
        GetComponent<Animator>().SetTrigger("Change");
    }
    private void toggleStartAndPlayCamera()
    {
        bool StartActive = activeCameras[(uint)CAMERAS.Start];
        bool playActive = activeCameras[(uint)CAMERAS.Play];
        if (StartActive == true && playActive == false)
        {
            ChangeCamera(CAMERAS.Play);
        }
        else if (StartActive == false && playActive == true)
        {
            ChangeCamera(CAMERAS.Start);
        }
        else
        {
            Debug.Log("cannot Toggle Start And Settings camera , either both off or both on");
            int x = 0;
            for (uint i = 0; i < maxCameras; ++i)
            {
                x += activeCameras[i] ? 1 : 0;
                Debug.Log($"{x}");
            }
        }
    }


    private void ChangeCamera(CAMERAS type)
    {
        for (uint i = 0; i < maxCameras; ++i)
        {
            if (i == (uint)type)
            {
                cameras[i].SetActive(true);
                activeCameras[i] = true;

            }
            else
            {
                cameras[i].SetActive(false);
                activeCameras[i] = false;
            }
        }
    }
}
