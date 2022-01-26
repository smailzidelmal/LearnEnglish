using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject canvas;
    void OnMouseDown(){
		
    	int numQst =GameObject.Find("Canvas").GetComponent<Quiz>().numQst ;
        int nbQst =GameObject.Find("Canvas").GetComponent<Quiz>().nbQst;
        //todo calcule du score 
        
    	if(GameObject.Find("Canvas").GetComponent<Quiz>().reponse == transform.GetChild(0).GetComponent<TextMesh>().text)
    	{
    		Debug.Log(" bonne réponse !! ....confirmez votre performance avec cette nouvelle question  ");
    		GameObject.Find("Canvas").GetComponent<Quiz>().score +=1;
    		GeneralInfo.answer(true);
    		GameObject.Find("EnnemyHealthBarImage").GetComponent<health>().healthBarImage.fillAmount -= 0.05f;
    		GameObject.Find("EnnemyTimeBarImage").GetComponent<Timer>().TimerBar.fillAmount = 1f;
			foreach (GameObject ennemy in GameObject.FindGameObjectsWithTag("Enemy")) {
             	ennemy.GetComponent<EnemyManager>().takeDamage();
         	}
    		if(numQst+1 >= nbQst){
    			Debug.Log(" Le Jeu est Fini ");
    			GameObject.Find("Canvas").GetComponent<Quiz>().numQst=nbQst;
    		}
    	}
    	else
    	{
    		Debug.Log(" Mauvaise réponse ....essayer de vous rattraper avec cette nouvelle question  ");
    		GeneralInfo.answer(false);
    		GameObject.Find("HealthBarImage").GetComponent<health>().healthBarImage.fillAmount -= 0.05f;
    		GameObject.Find("EnnemyTimeBarImage").GetComponent<Timer>().TimerBar.fillAmount = 1f;
  			foreach (GameObject ennemy in GameObject.FindGameObjectsWithTag("Enemy")) {
             	ennemy.GetComponent<EnemyManager>().hit();
         	}
			if(numQst+1 >= nbQst){
    			Debug.Log(" Le Jeu est Fini ");
    			GameObject.Find("Canvas").GetComponent<Quiz>().numQst=nbQst;
    		}
    	}
		Debug.Log("Desactivate");
		GameObject.Find("Canvas").SetActive(false);
    }
}
