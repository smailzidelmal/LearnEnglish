using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class Quiz: MonoBehaviour
{
    // Start is called before the first frame update
    public bool new_questions = true;

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


    
    void Start()
    {
        //partie 1
        // Quizz[0]="How old are you? I ________ ,have 30,have 30 years,am 30 years,am 30 years old,old";
        // Quizz[1]="Please _________ you speak slower?,could,will,do,are,could";
        // Quizz[2]="London is the capital of the United ________ .,country,land,headquarters,Kingdom,Kingdom";
        // Quizz[3]="I’ll wait for you _________.,house,at home,home,to home,at home";
        // Quizz[4]="I love _________ abroad. ,to travelling,travel,to travel,is travelling,to travel";
        // Quizz[5]="I am so ____________. I need to eat something.,thirsty,sleepy,hungry,exhausted,hungry";
        // Quizz[6]="Where _______ you from?  Australia.,do,is,come,are,are";
        // Quizz[7]="I live ______ Los Angeles.,to,in,at,of,in";
        // Quizz[8]="How ____ you spell your name please? – R-I-C-H-A-R-D-S.,are,does,write,do,do";
        // Quizz[9]="They _______ go to the cinema.,tomorrow,rarely,much,rare,rarely";
        // Quizz[10]="My sister ______ born on the 1st of April 1995.,is,was,had,has been,was";
        // Quizz[11]="Is this a small city?  No it’s ______ big.,only,but,also,quite,quite";
        // Quizz[12]="English is a lot _________ than French.,easy,easier,more easy,more easier,easier";
        // Quizz[13]="_________ long have you worked here?,how,what,where,why,how";
        // Quizz[14]="It costs $100! It’s _______ expensive!,to,lot,much,too,too";
        // Quizz[15]="He usually ________ at 7am.,got up,get up,gets up,don’t get up,gets up";
        // Quizz[16]="How _______ does this cost?,many,far,long,much,much";
        // Quizz[17]="Do your parents live here? -Yes that’s ______ house over there.,their,there,other,our,her,their";
        // Quizz[18]="This lesson is too ________. Could you help me? ,easy,tiring,hard,boring,hard";
        // Quizz[19]="Yesterday I _______ to the restaurant with my boyfriend.,go,to go,went,have gone,went";
        // nbQst= 20;
        // Quizz[20]="le Jeu est fini !!,Merci,Score : ,Niveau :,AuRevoir,Merci";
        
        TxtQuestion = GameObject.Find("TextQuestion").GetComponent <Text>();
        TxtHG = GameObject.Find("textHG").GetComponent <TextMesh>();
        TxtHD = GameObject.Find("textHD").GetComponent <TextMesh>();
        TxtBG = GameObject.Find("textBG").GetComponent <TextMesh>();
        TxtBD = GameObject.Find("textBD").GetComponent <TextMesh>();

        
        
        using(var reader = new StreamReader("Assets/Ressources/question.csv"))
        {
            reader.ReadLine();
            nbQst= -1;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                Quizz2.Add(line.Split(';'));
                nbQst++;

            }
        }
        
        
        PoseUneQuestion(numQst);
    }




    // Update is called once per frame
    void Update()
    {
        if (new_questions){
            PoseUneQuestion(numQst);
        }
        
    }

    private void random_val<T>(T[] alpha){
        for (int i = 0; i < alpha.Length; i++) {
            T temp = alpha[i];
            int randomIndex = Random.Range(i, alpha.Length);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
    }
    
    void PoseUneQuestion(int numQst)
    {
    	if (score <= 20){niveau="A1- Débutant";}
    	else if (score <= 35){niveau="A2- Moyen";}
    	else if (score <= 60){niveau="B1- intermédiaire ";}
    	else if (score <= 80){niveau="B2-Avancé ";}
    	else if(score <= 90){niveau="C1- Courant";}
    	
    	//string[] Col=Quizz[numQst].Split(',');
    	string[] Col=Quizz2[numQst];
        
        //TODO: mettre le random des questions de maniere plus propre.
        int[] alpha = {1, 2, 3, 4};
        if (nbQst != numQst){
            random_val<int>(alpha);
            Debug.Log(alpha[0]+ ", "+ alpha[1]+ ", "+ alpha[2]+ ", "+ alpha[3]);
        }


        TxtQuestion.text=Col[0];
    	TxtHG.text=Col[alpha[0]];
    	TxtHD.text=Col[alpha[1]]+score;
    	TxtBG.text=Col[alpha[2]]+niveau;
    	TxtBD.text=Col[alpha[3]];
    	reponse=Col[5];
        new_questions = false;
    }
}
