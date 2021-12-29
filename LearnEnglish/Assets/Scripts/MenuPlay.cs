using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlay : MonoBehaviour
{
    public  GameObject Menu;  
    
    void OnMouseDown(){
   	this.Menu.SetActive(false);	
   }
}
