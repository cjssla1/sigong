using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_UI : MonoBehaviour {
    
    public string[] stage_names;

    public void Click_Menu_Button_0()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    public void Click_Stage_Button_0()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[0]);
    }

    public void Click_Stage_Button_1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[1]);
    }

    public void Click_Stage_Button_2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[2]);
    }

    public void Click_Stage_Button_3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[3]);
    }
}
