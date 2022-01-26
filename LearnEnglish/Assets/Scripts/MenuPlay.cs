using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlay : MonoBehaviour
{
    public  GameObject Menu;  
    public  GameObject Player;  
    private GameGenerator gameGen;

    void OnMouseDown(){
        gameGen = GameObject.FindGameObjectWithTag("Generator").GetComponent<GameGenerator>(); 
        gameGen.initGame();
   	this.Menu.SetActive(false);
   	GameObject.Find("EnnemyTimeBarImage").GetComponent<MyTimer>().start = true;
   }
}
