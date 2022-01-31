using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Click : MonoBehaviour
{
	public GameObject rules;
    public GameObject canvas;
    void OnMouseDown(){
		
    	int numQst =GameObject.Find("Canvas").GetComponent<Quiz>().numQst ;
        int nbQst =GameObject.Find("Canvas").GetComponent<Quiz>().nbQst;
        //todo calcule du score 
		Debug.Log("Degat "+2f/nbQst);
        
    	if(GameObject.Find("Canvas").GetComponent<Quiz>().reponse == transform.GetChild(0).GetComponent<TextMesh>().text)
    	{
			GeneralInfo.setResult(numQst, "true");
    		Debug.Log(" bonne réponse !! ....confirmez votre performance avec cette nouvelle question  ");
    		GameObject.Find("Canvas").GetComponent<Quiz>().score +=1;
    		GeneralInfo.answer(true);
    		GameObject.Find("EnnemyHealthBarImage").GetComponent<health>().healthBarImage.fillAmount -= 2f/nbQst;
    		GameObject.Find("EnnemyTimeBarImage").GetComponent<MyTimer>().TimerBar.fillAmount = 1f;
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
    		GeneralInfo.setResult(numQst, "false");
    		Debug.Log(" Mauvaise réponse ....essayer de vous rattraper avec cette nouvelle question  ");
    		GeneralInfo.answer(false);
    		GameObject.Find("HealthBarImage").GetComponent<health>().healthBarImage.fillAmount -= 2f/nbQst;
    		GameObject.Find("EnnemyTimeBarImage").GetComponent<MyTimer>().TimerBar.fillAmount = 1f;
  			foreach (GameObject ennemy in GameObject.FindGameObjectsWithTag("Enemy")) {
             	ennemy.GetComponent<EnemyManager>().hit();
         	}
			if(numQst+1 >= nbQst){
    			Debug.Log(" Le Jeu est Fini ");
    			GameObject.Find("Canvas").GetComponent<Quiz>().numQst=nbQst;
    		}
    	}

		float palyerGameOver = GameObject.Find("HealthBarImage").GetComponent<health>().healthBarImage.fillAmount ;
		float ennemyGameOver = GameObject.Find("EnnemyHealthBarImage").GetComponent<health>().healthBarImage.fillAmount;
		Debug.Log(palyerGameOver + " <=0 || " +ennemyGameOver);
		if (palyerGameOver <=0 || ennemyGameOver <= 0){
			GeneralInfo.write_file_player("C2", nbQst);
			rules.SetActive(false);
			GeneralInfo.lanchEndMenu();
		}
		Debug.Log("Desactivate");
		GameObject.Find("Canvas").SetActive(false);
    }
}
