using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float ShakeAmmount;
    public float ShakeFrequency;
    public bool AbleToShake = false;
    public CinemachineVirtualCamera Camera;
    private CinemachineBasicMultiChannelPerlin Noise;




    void Start()
    {

        Noise = Camera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

    }

    // Update is called once per frame
    void Update()
    {
       

        if(AbleToShake == true)
        {

            Noise.m_AmplitudeGain = ShakeAmmount;
            Noise.m_FrequencyGain = ShakeFrequency;

        }

        else if(AbleToShake == false)
        {

            Noise.m_AmplitudeGain = 0;
            Noise.m_FrequencyGain = 1;

        }

    }
}
