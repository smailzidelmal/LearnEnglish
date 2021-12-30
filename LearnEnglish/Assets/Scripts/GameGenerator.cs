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
    
    // Start is called before the first frame update
    
    void Start()
    {
        InvokeRepeating("spawnRoad", startDelay, repeatrate);
    }

    public void spawnRoad(){
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
    }

    public void initGame(){
        destroyAll();
        for (int i = 0; i <= 8; i++){
            spawnRoad();
        }
        Vector3 posenemy2 = posenemy;
        posenemy2.x += 2f;
        Vector3 posenemy3 = posenemy;
        posenemy3.x -= 2f;
        Instantiate(player,posplayer,Quaternion.identity);
        GameObject enemytmp;
        enemytmp = Instantiate(enemy,posenemy,Quaternion.identity);
        enemytmp.transform.Rotate (new Vector3 (0f, 180f, 0f));
        enemytmp = Instantiate(enemy,posenemy2,Quaternion.identity);
        enemytmp.transform.Rotate (new Vector3 (0f, 180f, 0f));
        enemytmp = Instantiate(enemy,posenemy3,Quaternion.identity);
        enemytmp.transform.Rotate (new Vector3 (0f, 180f, 0f));
    }

}
