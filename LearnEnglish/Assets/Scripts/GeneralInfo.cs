using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
