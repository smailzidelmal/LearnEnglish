using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{

    public float startDelay = 0f;
    public float repeatrate = 2f;
    private GameObject lastroad = null;
    public GameObject road;
    public GameObject player;
    public Vector3 posplayer = new Vector3(0f,-1f, -5.98f);
    public GameObject enemy;
    public Vector3 posenemy = new Vector3(0f, -1f,-1f);
    public GameObject bg;

    public GameObject hpPlayer;
    public GameObject hpEnemy;
    
    public GameObject barAtk;

    public Vector3 posbg = new Vector3(0f, 0f,60f);
    
    private bool isStarted = false;
    // Start is called before the first frame update
    
    void Start()
    {
        isStarted = false;
        InvokeRepeating("spawnRoad", startDelay, repeatrate);
    }

    public void spawnRoad(){
        if (!isStarted){
            return;
        }
        Vector3 pos;
        if (lastroad != null){
            pos = lastroad.transform.position;
            pos.z += 10f;
        }
        else
        {
            pos = Vector3.zero;
        }
        if (pos.z <= 80f){
            lastroad = Instantiate(road,pos,Quaternion.identity);
        }
    }


    public void destroyAll(){
        GameObject[] objects;
        objects = GameObject.FindGameObjectsWithTag("Enemy");
   		foreach(GameObject obj in objects){
			GameObject.Destroy(obj);
		}
        objects = GameObject.FindGameObjectsWithTag("Player");
   		foreach(GameObject obj in objects){
			GameObject.Destroy(obj);
		}
        objects = GameObject.FindGameObjectsWithTag("BackGround");
   		foreach(GameObject obj in objects){
			GameObject.Destroy(obj);
		}
        objects = GameObject.FindGameObjectsWithTag("Road");
   		foreach(GameObject obj in objects){
			GameObject.Destroy(obj);
		}
        isStarted = false;
    }

    public void initGame(){
        destroyAll();
        isStarted = true;
        for (int i = 0; i <= 8; i++){
            spawnRoad();
        }
        hpPlayer.GetComponent<health>().healthBarImage.fillAmount=1f;
		hpEnemy.GetComponent<health>().healthBarImage.fillAmount=1f;
        barAtk.GetComponent<MyTimer>().TimerBar.fillAmount = 1f;

        Vector3 posenemy2 = posenemy;
        posenemy2.x += 2f;
        Vector3 posenemy3 = posenemy;
        posenemy3.x -= 2f;
        Instantiate(player,posplayer,Quaternion.identity);
        Instantiate(bg,posbg,Quaternion.identity);
        GameObject enemytmp;
        enemytmp = Instantiate(enemy,posenemy,Quaternion.identity);
        enemytmp.transform.Rotate (new Vector3 (0f, 180f, 0f));
        enemytmp = Instantiate(enemy,posenemy2,Quaternion.identity);
        enemytmp.transform.Rotate (new Vector3 (0f, 180f, 0f));
        enemytmp = Instantiate(enemy,posenemy3,Quaternion.identity);
        enemytmp.transform.Rotate (new Vector3 (0f, 180f, 0f));
    }

}
