using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoMenu : MonoBehaviour
{
    public  GameObject Menu;
    public  GameObject EndMenu;
    public  GameObject rules;
    public GameObject logRegister ;
   void OnMouseDown(){
   	this.EndMenu.SetActive(false);
   	this.rules.SetActive(false);	
   	this.Menu.SetActive(true);
   	this.logRegister.SetActive(true);
   }
}
