using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoMenu : MonoBehaviour
{
    public  GameObject Menu;
    public  GameObject EndMenu;
   
   void OnMouseDown(){
   	this.EndMenu.SetActive(false);
   	this.Menu.SetActive(true);  	
   }
}
