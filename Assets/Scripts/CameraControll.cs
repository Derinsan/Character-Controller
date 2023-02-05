using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;
    [SerializeField] private FixedJoystick joystick;
    private CinemachineOrbitalTransposer transposer;

    private void Start()
    {
        var brain = GameObject.Find("Main Camera").AddComponent<CinemachineBrain>();
        
        transposer = vcam2.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    private void Update()
    {
        if (joystick.Horizontal != 0)
        {
            vcam1.m_Priority = 10;
            vcam2.m_Priority = 11;
            transposer.m_Heading.m_Bias = joystick.Horizontal;
        }
        else if (joystick.Horizontal == 0)
        {
            vcam2.transform.position = vcam1.transform.position;
            vcam1.m_Priority = 11;
            vcam2.m_Priority = 10;
        }
    }
}
