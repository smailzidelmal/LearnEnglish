using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Animator player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneralInfo.playerHasAnswer()){}
        player.SetBool("walk", GeneralInfo.isWalk());
    }
}
