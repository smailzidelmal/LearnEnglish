using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlay : MonoBehaviour
{
    public  GameObject Menu; 
    public  GameObject play;  
    public  GameObject Player;  
    private GameGenerator gameGen;
    public  GameObject rules ;
    public GameObject login ;
    public  GameObject register;
     void Start()
    {
        this.play.SetActive(false);
    }
    void OnMouseDown(){
        this.rules.SetActive(true);
        this.register.SetActive(false);
        this.login.SetActive(false);
        gameGen = GameObject.FindGameObjectWithTag("Generator").GetComponent<GameGenerator>(); 
        gameGen.initGame();
   	this.Menu.SetActive(false);
   	GameObject.Find("EnnemyTimeBarImage").GetComponent<MyTimer>().start = true;
   }
}
