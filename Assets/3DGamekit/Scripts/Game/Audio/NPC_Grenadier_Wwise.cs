using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Grenadier_Wwise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Header("LR_Attack Event")]
    public AK.Wwise.Event lr_attackEvent;

    public void PlayLR_AttackSound()
    {
        if (lr_attackEvent != null)
        {
            lr_attackEvent.Post(gameObject);
        }
    }
    [Header("Hit Event")]
    public AK.Wwise.Event hitEvent;

    public void PlayHitSound()
    {
        if (hitEvent != null)
        {
            hitEvent.Post(gameObject);
        }
    }
    [Header("Footsteps Event")]
    public AK.Wwise.Event footstepsEvent;

    public void PlaFootstepsSound()
    {
        if (footstepsEvent != null)
        {
            footstepsEvent.Post(gameObject);
        }
    }
    [Header("Melee Event")]
    public AK.Wwise.Event meleeEvent;

    public void PlayMeleeSound()
    {
        if (meleeEvent != null)
        {
            meleeEvent.Post(gameObject);
        }
    }
    [Header("RangeAttack2 Event")]
    public AK.Wwise.Event rangeattack2Event;

    public void PlayRangeAttack2Sound()
    {
        if (rangeattack2Event != null)
        {
            rangeattack2Event.Post(gameObject);
        }
    }
    [Header("GolemDeath Event")]
    public AK.Wwise.Event golemdeathEvent;

    public void PlayGolemDeathSound()
    {
        if (golemdeathEvent != null)
        {
            golemdeathEvent.Post(gameObject);
        }
    }
}
