using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour
{
    public float fraction = 10000f;
    public float maxTime = 10f;
    public Image TimerBar;
    public bool start = false ;
	public float step = 1f;

    // Update is called once per frame
    void Update()
    {
    	if(start == true ){
	    	if( TimerBar.fillAmount <= 0 )
	    	{
				TimerBar.fillAmount = 1 ;
				TimerBar.color = Color.green;
				//la il va subir une attaque donc il faut appeler la variable de click pour faire - valeur de degat
				GameObject.Find("HealthBarImage").GetComponent<health>().healthBarImage.fillAmount -= 0.05f;
				GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerControler>().takeDamage();
				foreach (GameObject ennemy in GameObject.FindGameObjectsWithTag("Enemy")) {
					ennemy.GetComponent<EnemyManager>().hit();
				}
	    	}
	    	else 
	    	{
	    		 if (TimerBar.fillAmount < 0.7 ){TimerBar.color = Color.yellow;}
	    		 else if (TimerBar.fillAmount < 0.3 ){TimerBar.color = Color.red;}
	    		 else{ TimerBar.color = Color.green;}
	    		 
	    		 TimerBar.fillAmount =  TimerBar.fillAmount - (maxTime / fraction);
			}
        }
    }

	public void slow(){
		maxTime = Mathf.Max(5f, maxTime - step);
	}

	public void accelerate(){
		maxTime = Mathf.Min(20f, maxTime + step);
	}
}
