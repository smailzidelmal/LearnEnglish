using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject canvas;
    void OnMouseDown(){
        //GameObject.Find("Canvas").GetComponent<Canvas>().enabled = s;
        int numQst = GameObject.Find("Canvas").GetComponent<Quiz>().numQst ;
        int nbQst = GameObject.Find("Canvas").GetComponent<Quiz>().nbQst;
        if(numQst+1 < nbQst){
            GameObject.Find("Canvas").GetComponent<Quiz>().numQst +=1;
        }
        else{
            Debug.Log(" Le Jeu est Fini ");
            GameObject.Find("Canvas").GetComponent<Quiz>().numQst=nbQst;
        }
        GameObject.Find("Canvas").GetComponent<Quiz>().new_questions = true;
    }
}
