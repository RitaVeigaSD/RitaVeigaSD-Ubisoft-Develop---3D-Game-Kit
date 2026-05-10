using UnityEngine;
using AK.Wwise;

public class StopOnWeaponTaken : MonoBehaviour
{
    public GameObject weaponObject;
    public AK.Wwise.Event loopEvent;

    private bool stopped = false;

    void Update()
    {
        if (!stopped && (weaponObject == null || !weaponObject.activeInHierarchy))
        {
            loopEvent.Stop(gameObject);
            stopped = true;
        }
    }
}