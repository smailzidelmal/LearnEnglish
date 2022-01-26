using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{

    public Animator enemy;

    public GameObject canvas;
    
    private Vector3 start_position;

    void Start()
    {
        start_position = transform.position;
    }

    void OnMouseDown(){
        GeneralInfo.startAnswer();
        Canvas[] onlyInactive = GameObject.FindObjectsOfType<Canvas>(true).Where(sr => !sr.gameObject.activeInHierarchy).ToArray();
        if (onlyInactive.Length == 1) {
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

    public void hit(){
        transform.position = start_position;
        Debug.Log("frappe");
        enemy.SetTrigger("hit");
    }

    public void takeDamage(){
        transform.position = start_position;
        enemy.SetTrigger("dammage");
    }

}
