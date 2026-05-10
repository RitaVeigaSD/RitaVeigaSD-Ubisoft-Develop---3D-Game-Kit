using UnityEngine;
using AK.Wwise;
public class PlayerWwiseAudio : MonoBehaviour
{
    [Header("Jump Event")]
    public AK.Wwise.Event jumpEvent;
    [Header("Land Event")]
    public AK.Wwise.Event landEvent;
    [Header("Roll Event")]
    public AK.Wwise.Event rollEvent;
    [Header("Woosh Event")]
    public AK.Wwise.Event wooshEvent;
    [Header("Death Event")]
    public AK.Wwise.Event deathEvent;
    [Header("Hit Event")]
    public AK.Wwise.Event hitEvent;
    public void PlayJumpSound()
    {
        if (jumpEvent != null)
        {
            jumpEvent.Post(gameObject);
        }
    }
    public void PlayLandSound()
    {
        DetectSurface();
        AkUnitySoundEngine.SetSwitch("Footsteps", currentSurface, gameObject);
        if (landEvent != null)
        {
            landEvent.Post(gameObject);
        }
    }
    public void PlayRollSound()
    {
        if (rollEvent != null)
        {
            rollEvent.Post(gameObject);
        }
    }
    public void PlayWooshSound()
    {
        if (wooshEvent != null)
        {
            wooshEvent.Post(gameObject);
        }
    }
    public void PlayDeathSound()
    {
        if (deathEvent != null)
        {
            deathEvent.Post(gameObject);
        }
    }
    public void PlayHitSound()
    {
        if (hitEvent != null)
        {
            hitEvent.Post(gameObject);
        }
    }
    [Header("Footsteps Event")]
    public AK.Wwise.Event footstepsEvent;
    [Header("Raycast")]
    public float rayDistance = 25f;
    public LayerMask environmentLayer;
    private string currentSurface = "Grass";
    public void PlayFootstepsSound()
    {
        DetectSurface();
        AkUnitySoundEngine.SetSwitch("Footsteps", currentSurface, gameObject);
        if (footstepsEvent != null)
        {
            footstepsEvent.Post(gameObject);
        }
    }
    void DetectSurface()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit[] hits = Physics.RaycastAll(ray, rayDistance, environmentLayer, QueryTriggerInteraction.Collide);
        System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

        currentSurface = "Dirt";

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Stone"))
            {
                currentSurface = "Stone";
                break;
            }
            else if (hit.collider.CompareTag("Grass"))
            {
                currentSurface = "Grass";
                break;
            }
            else if (hit.collider.CompareTag("Metal"))
            {
                currentSurface = "Metal";
                break;
            }
            else if (hit.collider.CompareTag("Dirt"))
            {
                currentSurface = "Dirt";
                break;
            }

        }

        Debug.Log("Surface: " + currentSurface);
    }
  


}