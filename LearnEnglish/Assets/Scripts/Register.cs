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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void registerButton(){
    	//print("registration sucessful");
    	if(username != ""){
	    	if(System.IO.File.Exists(@"../data/"+username+".txt")){
	    		Debug.Log("user name taken ");
	    	}
	    	else{
	    		System.IO.File.WriteAllText(@"../LearnEnglish/data/"+username+".csv",username);
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
    	/*if(Input.GetKeyDown(KeyCode.Return))
    	{
    		registerButton();
    	}*/
        username = UserName.GetComponent<InputField>().text;
    }
}
