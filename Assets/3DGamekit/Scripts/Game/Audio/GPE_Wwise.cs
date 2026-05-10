using UnityEngine;
using AK.Wwise;

public class GPEAudio : MonoBehaviour
{
    [Header("Wwise Events")]
    public AK.Wwise.Event PressurePadActivEvent;

    public void PlayPressurePadActivSound()
    {
        if (PressurePadActivEvent != null)
        {
            PressurePadActivEvent.Post(gameObject);
        }
    }
    [Header("Wwise Events")]
    public AK.Wwise.Event StoneHitEvent;

    public void PlayStoneHitSound()
    {
        if (StoneHitEvent != null)
        {
            StoneHitEvent.Post(gameObject);
        }
    }
    [Header("Wwise Events")]
    public AK.Wwise.Event DoorOpenEvent;

    public void PlayDoorOpenSound()
    {
        if (DoorOpenEvent != null)
        {
            DoorOpenEvent.Post(gameObject);
        }
    }
    [Header("Wwise Events")]
    public AK.Wwise.Event ChestIdleEvent;

    public void PlayChestIdleSound()
    {
        if (ChestIdleEvent != null)
        {
            ChestIdleEvent.Post(gameObject);
        }

    }
    public void StopChestIdleSound()
    {
        if (ChestIdleEvent != null)
        {
            ChestIdleEvent.Stop(gameObject);
        }
    }
[Header("Wwise Events")]
    public AK.Wwise.Event ChestOpenEvent;

    public void PlayChestOpenSound()
    {
        if (ChestOpenEvent != null)
        {
            ChestOpenEvent.Post(gameObject);
        }
    }
    [Header("Wwise Events")]
    public AK.Wwise.Event CrystalEvent;


    public GPEAudio(AK.Wwise.Event crystalEvent)
    {
        this.CrystalEvent = crystalEvent;
    }

    public void PlayCrystalSound()
    {
        if (CrystalEvent != null)
        {
            CrystalEvent.Post(gameObject);
        }

    }
    [Header("Wwise Events")]
    public AK.Wwise.Event FishEvent;

    public void FishSound()
    {
        if (FishEvent != null)
        {
            FishEvent.Post(gameObject);
        }
    }
}