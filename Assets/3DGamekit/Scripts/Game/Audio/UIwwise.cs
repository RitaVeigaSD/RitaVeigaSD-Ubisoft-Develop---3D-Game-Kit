using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIwwise : MonoBehaviour
{
    [Header("HoverEvent")]
    public AK.Wwise.Event hoverEvent;

    public void PlayHoverSound()
    {
        if (hoverEvent != null)
        {
            hoverEvent.Post(gameObject);
        }
    }
    [Header("ValidateEvent")]
    public AK.Wwise.Event validateEvent;

    public void PlayValidateSound()
    {
        if (validateEvent != null)
        {
            validateEvent.Post(gameObject);
        }
    }
    [Header("PauseEvent")]
    public AK.Wwise.Event pauseEvent;

    public void PlayPauseSound()
    {
        if (pauseEvent != null)
        {
            pauseEvent.Post(gameObject);
        }
    }

    [Header("StartEvent")]
    public AK.Wwise.Event startEvent;

    public void PlayStartSound()
    {
        if (startEvent != null)
        {
            startEvent.Post(gameObject);
        }
    }
    [Header("SliderEvent")]
    public AK.Wwise.Event sliderEvent;

    public void PlaySliderSound()
    {
        if (sliderEvent != null)
        {
            sliderEvent.Post(gameObject);
        }
    }

    public void StopSliderSound()
    {
        if (sliderEvent != null)
        {
            AkUnitySoundEngine.StopAll(gameObject);
        }
    }
    public void UpdateSliderPitch(float sliderValue)
    {
        float remapped = (sliderValue * 4f) - 2f;
        AkUnitySoundEngine.SetRTPCValue("SliderPitch", remapped, gameObject);
        Debug.Log("SliderPitch RTPC set to: " + remapped);
    }

}