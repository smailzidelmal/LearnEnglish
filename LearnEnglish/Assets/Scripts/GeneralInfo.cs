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
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var line_split = line.Split(';');
                try {
                    res_dict.Add(line_split[0], new List<string>());
                    for (int i = 1; i < line_split.Length; i++){
                        res_dict[line_split[0]].Add(line_split[i]);
                    }
                }
                catch (ArgumentException)
                {
                    Debug.Log("" + line_split[0] + "exist two time");
                }

            }
        }
        Debug.Log("=>cd"+res_dict);
    }

}
