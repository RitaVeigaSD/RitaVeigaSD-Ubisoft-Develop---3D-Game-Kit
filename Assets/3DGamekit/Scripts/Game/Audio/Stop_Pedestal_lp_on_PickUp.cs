using UnityEngine;

public class StopPedestalLoopOnPickup : MonoBehaviour
{
    public AK.Wwise.Event stopEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stopEvent.Post(gameObject.transform.parent.Find("WeaponPedastal/Pedestal_Audio").gameObject);
            Debug.Log("Pedestal stop triggered");
        }
    }
}