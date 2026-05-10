using UnityEngine;
using AK.Wwise;

public class ChomperWwiseAudio : MonoBehaviour
{
    [Header("Wwise Events")]
    public AK.Wwise.Event attackEvent;

    public void PlayAttackSound()
    {
        if (attackEvent != null)
        {
            attackEvent.Post(gameObject);
        }
    }

    public void StopAttackSound()
    {
        if (attackEvent != null)
        {
            attackEvent.Stop(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            attackEvent.Post(gameObject);
            Debug.Log("Manual test fired");
        }
    }
    [Header("Footstep Event")]
    public AK.Wwise.Event footstepEvent;
    public void PlayFootstepSound()
    {
        if (footstepEvent != null)
        {
            footstepEvent.Post(gameObject);
        }
    }
    [Header("Idle Event")]
    public AK.Wwise.Event idleEvent;
    public void PlayIdleSound()
    {
        if (idleEvent != null)
        {
            idleEvent.Post(gameObject);
        }
    }

    public void StopIdleSound()
    {
        if (idleEvent != null)
        {
            idleEvent.Stop(gameObject);
        }
    }
    [Header("Spotted Event")]
    public AK.Wwise.Event spottedEvent;
    public void PlaySpottedSound()
    {
        if (spottedEvent != null)
        {
            spottedEvent.Post(gameObject);
        }
    }

    public void StopSpottedSound()
    {
        if (spottedEvent != null)
        {
            spottedEvent.Stop(gameObject);
        }
    }
    [Header("Death Event")]
    public AK.Wwise.Event deathEvent;
    public void PlayDeathSound()
    {
        if (deathEvent != null)
        {
            deathEvent.Post(gameObject);
        }
    }
    void OnDestroy()
    {
        StopIdleSound();
   
    }
}
