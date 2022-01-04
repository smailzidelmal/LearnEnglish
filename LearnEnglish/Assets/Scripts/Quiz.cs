using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz: MonoBehaviour
{
    // Start is called before the first frame update
    private Text TxtQuestion;
    private TextMesh TxtHG;
    private TextMesh TxtHD;
    private TextMesh TxtBG;
    private TextMesh TxtBD;
    private string[] Quizz = new string[6];
    public int numQst =0;
    public int nbQst= 0;
    public string reponse;
    
    void Start()
    {

        Quizz[0]="How old are you? I ________ ,have 30,have 30 years,am 30 years,am 30 years old,Foltyn";
        Quizz[1]="Please _________ you speak slower?,could,will,do,are,do";
        Quizz[2]="London is the capital of the United ________ .,country,land,headquarters,Kingdom,Kingdom";
        Quizz[3]="I’ll wait for you _________.,house,at home,home,to home,at home";
        Quizz[4]="I love _________ abroad. ,to travelling,travel,to travel,is travelling,travel";
        
        nbQst= 5;
        Quizz[5]="le Jeu est fini !!,Merci,Score,Niveau,AuRevoir,Merci";
        
        TxtQuestion = GameObject.Find("TextQuestion").GetComponent <Text>();
        TxtHG = GameObject.Find("textHG").GetComponent <TextMesh>();
        TxtHD = GameObject.Find("textHD").GetComponent <TextMesh>();
        TxtBG = GameObject.Find("textBG").GetComponent <TextMesh>();
        TxtBD = GameObject.Find("textBD").GetComponent <TextMesh>();
        
        PoseUneQuestion(numQst);
    }

    // Update is called once per frame
    void Update()
    {
        PoseUneQuestion(numQst);
    }
    void PoseUneQuestion(int numQst)
    {
    	
    	string[] Col=Quizz[numQst].Split(',');
    	TxtQuestion.text=Col[0];
    	TxtHG.text=Col[1];
    	TxtHD.text=Col[2];
    	TxtBG.text=Col[3];
    	TxtBD.text=Col[4];
    	reponse=Col[5];
    }
}
