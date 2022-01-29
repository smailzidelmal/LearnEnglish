using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    public GameObject UserName;
    public string username;
    public GameObject playButton ;

    public void loginButton()
    {
        if(username != ""){
	    	if(System.IO.File.Exists(@"../data/"+username+".csv")){
	    		print("registration sucessful ... Welcome "+username);
	    		//UserName.GetComponent<InputField>().text="";
	    		this.playButton.SetActive(true);
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
