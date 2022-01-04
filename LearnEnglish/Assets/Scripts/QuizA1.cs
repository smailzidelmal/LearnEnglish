using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizA1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Text TxtQuestion;
    private TextMesh TxtHG;
    private TextMesh TxtHD;
    private TextMesh TxtBG;
    private TextMesh TxtBD;
    private string[] Quiz = new string[6];
    
    void Start()
    {
        Debug.Log("ca marche");
        Quiz[0]="le Nom de Axel ?,Macron,Francois,Gerard,Foltyn,Foltyn";
        Quiz[1]="le Nom de Smail ?,Zidelmal,kahil,Amara,Matoub,Zidelmal";
        
        TxtQuestion = GameObject.Find("TextQuestion").GetComponent <Text>();
        TxtHG = GameObject.Find("textHG").GetComponent <TextMesh>();
        TxtHD = GameObject.Find("textHD").GetComponent <TextMesh>();
        TxtBG = GameObject.Find("textBG").GetComponent <TextMesh>();
        TxtBD = GameObject.Find("textBD").GetComponent <TextMesh>();
        
        PoseUneQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PoseUneQuestion()
    {
    	
    	string[] Col=Quiz[0].Split(',');
    	TxtQuestion.text=Col[0];
    	TxtHG.text=Col[1];
    	TxtHD.text=Col[2];
    	TxtBG.text=Col[3];
    	TxtBD.text=Col[4];
    }
}
