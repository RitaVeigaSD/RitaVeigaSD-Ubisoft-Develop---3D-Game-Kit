using UnityEngine;

public class StopLoopWhenDestroyed : MonoBehaviour
{
    public GameObject pedestalAudioObject;

    void OnDestroy()
    {
        if (pedestalAudioObject != null)
        {
            AkUnitySoundEngine.StopAll(pedestalAudioObject);
        }
    }
}