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
        Debug.Log("ca marche");
        Quizz[0]="le Nom de Axel ?,Macron,Francois,Gerard,Foltyn,Foltyn";
        Quizz[1]="le Nom de Smail ?,Zidelmal,kahil,Amara,Matoub,Zidelmal";
        
        nbQst= 2;
        Quizz[2]="le Jeu est fini !!,Merci,Score,Niveau,AuRevoir,Merci";
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
