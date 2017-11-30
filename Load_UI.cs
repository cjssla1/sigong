using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_UI : MonoBehaviour {
    public string Level;
    public int Step;
    public string[] stage_names;
    private void Start()
    {
        Step = PlayerPrefs.GetInt(Level);
    }

    public void Click_Menu_Button_Back()
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
    public void Click_Stage_Button_4()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[4]);
    }
    public void Click_Stage_Button_5()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[5]);
    }
    public void Click_Stage_Button_6()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[6]);
    }
    public void Click_Stage_Button_7()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[7]);
    }
    public void Click_Stage_Button_8()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[8]);
    }
    public void Click_Stage_Button_9()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[9]);
    }
    public void Click_Stage_Button_10()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[10]);
    }
    public void Click_Stage_Button_11()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[11]);
    }
    public void Click_Stage_Button_12()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[12]);
    }
    public void Click_Stage_Button_13()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[13]);
    }
    public void Click_Stage_Button_14()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[14]);
    }
    public void Click_Stage_Button_15()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[15]);
    }
    public void Click_Stage_Button_16()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[16]);
    }
    public void Click_Stage_Button_17()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage_names[17]);
    }

}
