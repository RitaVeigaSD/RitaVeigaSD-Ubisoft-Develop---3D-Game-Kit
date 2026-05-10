using AK.Wwise;
using UnityEngine;

public class WeaponPickupWwise : MonoBehaviour
{
    public AK.Wwise.Event pickupEvent;

    public void PlayPickup()
    {
        pickupEvent.Post(GameObject.FindWithTag("Player"));
    }
}
