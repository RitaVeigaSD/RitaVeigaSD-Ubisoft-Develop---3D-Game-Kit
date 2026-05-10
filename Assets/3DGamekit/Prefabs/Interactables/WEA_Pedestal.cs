using UnityEngine;
using AK.Wwise;

public class PedestalWwiseLoop : MonoBehaviour
{
    public AK.Wwise.Event loopEvent;

    private uint playingID;

    void Awake()
    {
        // Force registration manually
        AkUnitySoundEngine.RegisterGameObj(gameObject);
    }

    void Start()
    {
        if (loopEvent != null)
        {
            playingID = loopEvent.Post(gameObject);
        }
    }

    void OnDisable()
    {
        if (loopEvent != null)
        {
            loopEvent.Stop(gameObject);
        }

        AkUnitySoundEngine.UnregisterGameObj(gameObject);
    }
}