using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_Player_Controler_Footsteps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]
    private AK.Wwise.Event player_footstep;
    // Declare a game object, which will be the source where the sound is played: 

    [SerializeField]
    private GameObject player_footstep_source;

    // Then write a method: 
    public void anim_player_footstep()

    {
        player_footstep.Post(player_footstep_source);
    }
}
