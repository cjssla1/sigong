using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigong : MonoBehaviour {
    public float size;
    public float life;
    private float times;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        times += Time.deltaTime;
        if(times > life)//없어질 때
        {
            Collider2D[] s = Physics2D.OverlapCircleAll(transform.position, size);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].CompareTag("Character"))
                {
                    s[i].gameObject.GetComponent<Character>().Sigong = null;
                    s[i].gameObject.GetComponent<Character>().hitFlag = false;
                    s[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }

                if (s[i].CompareTag("Character_sky"))
                {
                    s[i].gameObject.GetComponent<Character_sky>().Sigong = null;
                    s[i].gameObject.GetComponent<Character_sky>().hitFlag = false;
                }
            }
            Destroy(this.gameObject);
        }
        else Checking_Near_Char();
        
	}

    void Checking_Near_Char()
    {
        Collider2D[] s = Physics2D.OverlapCircleAll(transform.position, size);

        for(int i =0; i < s.Length; i++)
        {
            if (s[i].CompareTag("Character")) {
                s[i].gameObject.GetComponent<Character>().Sigong = this.gameObject;
                s[i].gameObject.GetComponent<Character>().hitFlag = true;
                s[i].gameObject.GetComponent<Character>().moveFlag = false;
                s[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

            if (s[i].CompareTag("Character_sky"))
            {
                s[i].gameObject.GetComponent<Character_sky>().Sigong = this.gameObject;
                s[i].gameObject.GetComponent<Character_sky>().hitFlag = true;
                s[i].gameObject.GetComponent<Character_sky>().moveFlag = false;
            }
        }
    }
    
}
