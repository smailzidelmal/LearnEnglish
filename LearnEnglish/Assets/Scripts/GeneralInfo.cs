using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class GeneralInfo
{

    static bool isanswer = false;
    static bool correct = false;   
    public static bool walk = true;

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

    public static void parsefileplayer(string file){
        string path_file = Path.Combine(Application.dataPath ,Path.GetFullPath(file));
        Dictionary<string, List<string>> res_dict = new Dictionary<string, List<string>>();
        using(var reader = new StreamReader(path_file))
        {
            reader.ReadLine();
            var line = reader.ReadLine();
            var line_split = line.Split(';');
            try {
                //recupération du login est des donées général (cardio moyen et son niveau)
                res_dict.Add("gene", new List<string>());
                for (int i = 1; i < line_split.Length; i++){
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

}
