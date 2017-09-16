using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour {
   
    public void Click_Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level");
    }
    public void Click_Quit()
    {
        
    }
}
