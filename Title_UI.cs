using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour {

    public string mode;
    public string quit;
    public string setting;

    public void Click_Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mode);
    }
    public void Click_Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(quit);
    }
    public void Click_Setting()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(setting);
    }
}
