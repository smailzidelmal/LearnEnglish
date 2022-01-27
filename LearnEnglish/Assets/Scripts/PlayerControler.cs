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
    public int instantPPM = 0; 
    public int avragePPM = 120;
    public int getCardio(){
        string file = "../capt_cardio/cardio.txt";
        string path_file = Path.Combine(Application.dataPath ,Path.GetFullPath(file));
        if (File.Exists(path_file)){
            string[] lines = System.IO.File.ReadAllLines(file);
            Debug.Log(lines[0]);
            instantPPM = Int16.Parse(lines[0]);
            return Int16.Parse(lines[0]);
            //File.Delete(path_file);
        }
        return avragePPM ;
    }
}
