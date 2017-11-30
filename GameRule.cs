using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameRule : MonoBehaviour {

    public GameObject sigong;
    public string Level;
    public int Gold_of_sigong;
    public int Silver_of_sigong;
    public int Bronze_of_sigong;
    public int Number_of_sigong;//플레이어가생성
    public int Number_of_Char;//맵속의캐릭터
    public bool endFlag;

    public string thisScene;//Re 버튼
    public string nextScene;//next 버튼
    public GameObject canvas_of_end;
    public GameObject canvas_of_ingame;

	// Use this for initialization
	void Start () {
        Number_of_sigong = 0;
        canvas_of_end.SetActive(false);   	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 p = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            RaycastHit2D[] hits = Physics2D.RaycastAll(p, Vector2.zero,0);

            bool canBuild = true;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.CompareTag("Ground"))
                {
                    canBuild = false;
                    break;
                }
                else if (hits[i].transform.CompareTag("Black"))
                {
                    canBuild = false;
                    break;
                }
            }

            if (canBuild)
            {
                Instantiate(sigong, p, Quaternion.identity);
                Number_of_sigong++;
            }
        }
	}

    public void Checking_Char()
    {
        if(Number_of_Char == 0)
        {
            if(Number_of_sigong == Gold_of_sigong)
            {
                int step = PlayerPrefs.GetInt(Level);
                step++;
                PlayerPrefs.SetInt(Level, step);
            }
            endFlag = true;
            canvas_of_end.SetActive(true);
            canvas_of_ingame.SetActive(false);
        }
    }

    public void Click_Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
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
