using UnityEngine;
using AK.Wwise;

public class DestructibleBoxWwiseAudio : MonoBehaviour
{
    public AK.Wwise.Event hitEvent;
    public GameObject persistentEmitter;

    public void PlayHitSound()
    {
        Debug.Log("HIT SOUND TRIGGERED");

        if (hitEvent != null && persistentEmitter != null)
        {
            hitEvent.Post(persistentEmitter);
        }
    }
}