using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public static class GeneralInfo
{
    static bool isanswer = false;
    static bool correct = false;   
    public static bool walk = true;

    private static Dictionary<string, List<string>>  res_dict = null;

    public static bool isWalk(){
        return walk;
    }

    public static void answer(bool answer){
        isanswer =  true;
        correct = answer;
    }

    public static void startAnswer(){
        isanswer =  false;
    }

    public static bool playerHasAnswer(){
        return isanswer;
    }
    public static bool AnswerCorrect(){
        return correct;
    }

    public static List<string> getQuestion(){
        return res_dict["question"];
    }    

    public static void lanchEndMenu(){
        Debug.Log("FIN");
        MenuEnd[] onlyInactive = GameObject.FindObjectsOfType<MenuEnd>(true).Where(sr => !sr.gameObject.activeInHierarchy).ToArray();
		Debug.Log(onlyInactive.Length);
        if (onlyInactive.Length == 1) {
            Debug.Log("VISIBLE");
            onlyInactive[0].gameObject.SetActive(true);
        }
    }

    public static void parsefileplayer(string file){
        string path_file = Path.Combine(Application.dataPath ,Path.GetFullPath(file));
        res_dict = new Dictionary<string, List<string>>();
        using(var reader = new StreamReader(path_file))
        {
            //si ligne d'explication
            //reader.ReadLine();
            var line = reader.ReadLine();
            var line_split = line.Split(';');
            try {
                //recupération du login est des donées général (cardio moyen et son niveau)
                res_dict.Add("gene", new List<string>());
                for (int i = 0; i < line_split.Length; i++){
                    res_dict["gene"].Add(line_split[i]);
                }
                // recupération des réponse au questions
                res_dict.Add("question", new List<string>());
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    line_split = line.Split(';');
                    if (int.TryParse(line_split[0], out _)){
                        res_dict["question"].Add(line_split[1]);
                    }
                    else{
                        Debug.Log("" + line_split[0] + "not number"); 
                        break;      
                    }
                }
            }
            catch (ArgumentException)
            {
                Debug.Log("" + line_split[0] + "exist two time");
            }
        }
        Debug.Log("dico=>"+res_dict);
        foreach (KeyValuePair<string, List<string>> kvp in res_dict)
        {
            Debug.Log("  Key = "+ kvp.Key +" value = " + kvp.Value);
            kvp.Value.ForEach(Debug.Log);
        }
    }


    public static void write_file_player(int ppm_moy, string lvl, int tot_quest){
        StreamWriter sw = new StreamWriter(@"../data/"+username+".csv", false);
        // la premiere ligne donne les info
        sw.WriteLine(username + ";" + ppm_moy + ";" + lvl);
        for (int i = 0; i < tot_quest; i++){
            if (result_answer.ContainsKey(i)){
                sw.WriteLine("" + i + ";" + result_answer[i]);
            }
            else if (res_dict != null && i < res_dict["question"].Count){
                sw.WriteLine("" + i + ";" + res_dict["question"][i]);
            }
            else {
                sw.WriteLine("" + i + ";false");
            }
        }
        sw.Close();
    } 



    public static  int instantPPM = 0; 
    public static  int avragePPM = 60;


    public static List<int> list_cardio = new List<int>();

    public static int getCardio(){
        string file = "../capt_cardio/cardio.txt";
        string path_file = Path.Combine(Application.dataPath ,Path.GetFullPath(file));
        if (File.Exists(path_file)){
            string[] lines = System.IO.File.ReadAllLines(file);
            Debug.Log(lines[0]);
            instantPPM = Int16.Parse(lines[0]);
            list_cardio.Add(Int16.Parse(lines[0]));
            return Int16.Parse(lines[0]);
            //File.Delete(path_file);
        }
        list_cardio.Add(avragePPM);
        return avragePPM;
    }

    public static int getCardioMoy(){
        if (res_dict["gene"].Count < 2){
            return avragePPM;
        }
        return Int16.Parse(res_dict["gene"][1]); 
        /*poid = 100;
        avragePPM * poid + getCardio() / (poid+1);*/
    }
    
    private static Dictionary<int, string> result_answer = new Dictionary<int, string>();

    public static void reset(){
        result_answer = new Dictionary<int, string>();
    }

    public static void setResult(int ind, string res){
        if (!result_answer.ContainsKey(ind))
        {
            result_answer.Add(ind, res);
        }
        else {
            result_answer[ind] = res;
        }
    }


    public static string username;

    public static void setuser(string user){
        username = user;
    }

}
