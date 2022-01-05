using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    public GameObject canvas;
    void OnMouseDown(){
        Canvas[] onlyInactive = GameObject.FindObjectsOfType<Canvas>(true).Where(sr => !sr.gameObject.activeInHierarchy).ToArray();
        if (onlyInactive.Length == 1) {
            Debug.Log("FIND YOU !!!");
            onlyInactive[0].gameObject.SetActive(true);
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
}
