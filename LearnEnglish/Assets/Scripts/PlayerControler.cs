using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Collections;
using System.Collections.Generic;
using IronPython.Hosting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Animator player;
    // Start is called before the first frame update

    private bool new_answer = true;

    void Start()
    {/*
        string file = "Assets/Scripts/cardio.py";
        string path_file = Path.Combine(Application.dataPath ,Path.GetFullPath(file));
        string path_python = Path.Combine(Application.dataPath ,Path.GetFullPath("Assets/Plugins/Lib/"));
        var engine = Python.CreateEngine();
        var searchPaths = engine.GetSearchPaths();
        searchPaths.Add(path_python);
        engine.SetSearchPaths(searchPaths);
        var scope = engine.CreateScope();
        engine.ExecuteFile(path_file, scope);
        dynamic run_cardio = scope.GetVariable("run_cardio");
        run_cardio();
    */}

    // Update is called once per frame
    void Update()
    {
        if (GeneralInfo.playerHasAnswer()){
            if (new_answer){
                transform.position = new Vector3(0f,-1f,-6f);
                if (GeneralInfo.AnswerCorrect()){
                    Debug.Log("frappe");
                    player.SetTrigger("hit");
                }
                else{
                    player.SetTrigger("dammage");
                }
                new_answer = false;
            }
        }
        else{
            new_answer = true;
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
