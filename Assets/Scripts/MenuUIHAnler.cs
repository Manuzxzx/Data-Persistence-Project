using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHAnler : MonoBehaviour
{
    public TMP_Text nameField;
    public string playerName;
    public TMP_Text bestScore;
    public TMP_InputField inputField;

    private void Awake()
    {
        playerName = MasterManager.instance.playerName;
        inputField.text = playerName;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        bestScore.text = MasterManager.instance.bestScore;
        

       
    }

    // Update is called once per frame
    
    public void SatrtNew() 
    {
        SceneManager.LoadScene(1); 
    }
    public void Exit() 
    {
        MasterManager.instance.SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void GetName()
    {
        playerName = nameField.text;
        Debug.Log(playerName);
        MasterManager.instance.playerName = playerName;
    }
    
}
