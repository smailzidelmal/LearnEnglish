using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    public GameObject UserName;
    private string username;
    

    public void loginButton()
    {
        if(username != ""){
	    	if(System.IO.File.Exists(@"../LearnEnglish/data/"+username+".csv")){
	    		print("registration sucessful ... Welcome "+username);
	    		UserName.GetComponent<InputField>().text="";
	    	}
	    	else{
	    		Debug.Log("user name Invalid ");
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
