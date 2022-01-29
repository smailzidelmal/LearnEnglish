using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;


public class Register : MonoBehaviour
{
    public GameObject UserName;
    private string username;
    
    public void registerButton(){
    	if(username != ""){
	    	if(System.IO.File.Exists(@"../data/"+username+".csv")){
	    		Debug.Log("user name taken ");
	    	}
	    	else{
	    		System.IO.File.WriteAllText(@"../data/"+username+".csv",username);
	    		UserName.GetComponent<InputField>().text="";
	    		print("registration sucessful");
	    	}
    	}
    	else {
    		Debug.Log("user name empty ");
    	}
    	
    }
    // Update is called once per frame
    void Update()
    {
        username = UserName.GetComponent<InputField>().text;
    }
}
