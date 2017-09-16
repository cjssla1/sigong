using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameRule : MonoBehaviour {

    public GameObject sigong;
    public int Maxium_of_sigong;
    public int Number_of_sigong;
    public int Number_of_Char;
    public bool endFlag;

    public string thisScene;
    public string nextScene;
    public GameObject canvas_of_end;
    public GameObject canvas_of_ingame;

	// Use this for initialization
	void Start () {
        Number_of_sigong = 0;
        canvas_of_end.SetActive(false);
        //InvokeRepeating("Checking_Char", 1.0f, 1.0f);    	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            Instantiate(sigong, p, Quaternion.identity);
            Number_of_sigong++;
        }
	}

    public void Checking_Char()
    {

        if(Number_of_Char == 0)
        {
            endFlag = true;
            canvas_of_end.SetActive(true);
            canvas_of_ingame.SetActive(false);
        }
    }

    public void Click_Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Load");
    }
    public void Click_rePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(thisScene);
    }

    public void Click_next()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
}
