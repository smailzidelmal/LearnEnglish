using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class PlayerControler : MonoBehaviour
{
    public Animator player;
    // Start is called before the first frame update

    private bool new_answer = true;
    private Vector3 start_position;

    void Start()
    {
        start_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneralInfo.playerHasAnswer()){
            if (new_answer){
                if (GeneralInfo.AnswerCorrect()){
                    hit();
                }
                else{
                    takeDamage();
                }
                new_answer = false;
            }
        }
        else{
            new_answer = true;
        }
        player.SetBool("walk", GeneralInfo.isWalk());
    }

    public void hit(){
        transform.position = start_position;
        player.SetTrigger("hit");
    }

    public void takeDamage(){
        transform.position = start_position;
        player.SetTrigger("dammage");
    }
}
