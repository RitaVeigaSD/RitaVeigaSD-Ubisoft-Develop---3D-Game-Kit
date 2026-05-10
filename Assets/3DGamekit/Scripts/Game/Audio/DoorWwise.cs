using UnityEngine;
using AK.Wwise;

public class DoorWwiseAudio : MonoBehaviour
{
    public AK.Wwise.Event doorOpenEvent;

    public void PlayDoorOpen()
    {
        if (doorOpenEvent != null)
        {
            doorOpenEvent.Post(gameObject);
        }
    }
}