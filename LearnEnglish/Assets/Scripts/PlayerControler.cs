using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerControler : MonoBehaviour
{
    public Animator player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneralInfo.playerHasAnswer()){
            if (GeneralInfo.AnswerCorrect()){
                Debug.Log("frappe");
                player.SetTrigger("hit");
            }
            else{
                Debug.Log("aie");
                player.SetTrigger("dammage");
            }
        }
        player.SetBool("walk", GeneralInfo.isWalk());
    }
    void getCardio(){
        string file = "Assets/Scripts/cardio.txt";
        string path_file = Path.Combine(Application.dataPath ,Path.GetFullPath(file));
        if (File.Exists(path_file)){
            string[] lines = System.IO.File.ReadAllLines(file);
            Debug.Log(lines[0]);
            //File.Delete(path_file);
        }
    }
}
