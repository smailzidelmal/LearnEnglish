using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class Quiz: MonoBehaviour
{
    // Start is called before the first frame update
    public bool new_questions = false;

    private Text TxtQuestion;
    private TextMesh TxtHG;
    private TextMesh TxtHD;
    private TextMesh TxtBG;
    private TextMesh TxtBD;
    private string[] Quizz = new string[21];
    private List<string[]> Quizz2 = new List<string[]>();
    public int numQst =-1;
    public int nbQst= 0;
    public string reponse;
    public int score = 0 ;
    private string niveau;

    public GameObject ButtonHD;
	public GameObject ButtonHG;


    
    void Start()
    {
        
        new_questions = false;
        numQst = -1;

        TxtQuestion = GameObject.Find("TextQuestion").GetComponent <Text>();
        TxtHG = GameObject.Find("textHG").GetComponent <TextMesh>();
        TxtHD = GameObject.Find("textHD").GetComponent <TextMesh>();
        TxtBG = GameObject.Find("textBG").GetComponent <TextMesh>();
        TxtBD = GameObject.Find("textBD").GetComponent <TextMesh>();
        GameObject.Find("Canvas").SetActive(false);
        
        using(var reader = new StreamReader("../data/question/question.csv"))
        {
            reader.ReadLine();
            nbQst= -1;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                Debug.Log(line);
                Quizz2.Add(line.Split(';'));
                nbQst++;

            }
        }
    }


 
    private float adaptQuiz ; 
    private bool adapt2Answer = false;
    //private bool adapt4Answer = false;
    // Update is called once per frame
    void Update()
    {
    	adaptQuiz = GameObject.Find("EnnemyTimeBarImage").GetComponent<MyTimer>().maxTime;
        if (new_questions){
            PoseUneQuestion(numQst);
            adapt2Answer =true ;
            //adapt4Answer =true ;
        }
        else if (adaptQuiz == 5 &  adapt2Answer == true ){
      		 PoseUneQuestion(numQst);
        	 adapt2Answer=false; 
        }
        /*else if (adaptQuiz > 5 &  adapt4Answer == true ){
      		 PoseUneQuestion(numQst);
        	 adapt4Answer=false; 
        }*/
        
    }

    private void random_val<T>(T[] alpha){
        for (int i = 0; i < alpha.Length; i++) {
            T temp = alpha[i];
            int randomIndex = UnityEngine.Random.Range(i, alpha.Length);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
    }
    
    void PoseUneQuestion(int numQst)
    {
        //amelioration future
        //Debug.Log("nb = " + numQst);
    	if (score <= 20){niveau="A1- D??butant";}
    	else if (score <= 35){niveau="A2- Moyen";}
    	else if (score <= 60){niveau="B1- interm??diaire ";}
    	else if (score <= 80){niveau="B2-Avanc?? ";}
    	else if(score <= 90){niveau="C1- Courant";}
    	
    	string[] Col=Quizz2[numQst];

        int[] alpha = {1, 2, 3, 4};

  	
        TxtQuestion.text=Col[0];
        
        adaptQuiz = GameObject.Find("EnnemyTimeBarImage").GetComponent<MyTimer>().maxTime;
        
        if ( adaptQuiz == 5 ) {
        	int indexGdAns = Array.IndexOf(Col,Col[5]);
        	
        	
        	List<int> nums = new List<int>(alpha);
            Debug.Log(nums.IndexOf(indexGdAns));
		    nums.RemoveAt(nums.IndexOf(indexGdAns)); 
		    alpha = nums.ToArray();
        	
      		if (nbQst != numQst){
		        random_val<int>(alpha);
		        // Debug.Log(alpha[0]+ ", "+ alpha[1]+ ", "+ alpha[2]+ ", "+ alpha[3]);
	      	}
            int [] alpha2 = {alpha[0], indexGdAns};
            random_val<int>(alpha2);
		    TxtBG.text=Col[alpha2[0]];
	    	TxtBD.text=Col[alpha2[1]];
	    	
	    	
	    	ButtonHD.SetActive(false);
	    	ButtonHG.SetActive(false);
	    	
	    	
        
        } 
        else{
        
        	ButtonHD.SetActive(true);
	    	ButtonHG.SetActive(true);
	    	
        	if (nbQst != numQst){
		    random_val<int>(alpha);
		   // Debug.Log(alpha[0]+ ", "+ alpha[1]+ ", "+ alpha[2]+ ", "+ alpha[3]);
	      	  }
	    	TxtHG.text=Col[alpha[0]];
	    	TxtHD.text=Col[alpha[1]];
	    	TxtBG.text=Col[alpha[2]];
	    	TxtBD.text=Col[alpha[3]];
    	}
    	reponse=Col[5];
        new_questions = false;
    }
}
