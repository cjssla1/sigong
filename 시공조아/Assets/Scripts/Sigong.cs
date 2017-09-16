using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigong : MonoBehaviour {
    public float size;
    public float life;
    private float times;
    public GameRule gameRule;
	// Use this for initialization
	void Start () {
        gameRule = GameObject.FindGameObjectWithTag("Root").GetComponent<GameRule>();
	}
	
	// Update is called once per frame
	void Update () {
        times += Time.deltaTime;
        if(times > life)
        {
            Collider2D[] s = Physics2D.OverlapCircleAll(transform.position, size);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].CompareTag("Character"))
                {
                    s[i].gameObject.GetComponent<Character>().Sigong = null;
                    s[i].gameObject.GetComponent<Character>().hitFlag = false;
                    s[i].gameObject.GetComponent<Character>().moveFlag = true;
                    s[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }

                if (s[i].CompareTag("Character_sky"))
                {
                    s[i].gameObject.GetComponent<Character_sky>().Sigong = null;
                    s[i].gameObject.GetComponent<Character_sky>().hitFlag = false;
                    s[i].gameObject.GetComponent<Character_sky>().moveFlag = true;
                    s[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }
            }
            Destroy(this.gameObject);
        }
        else Checking();
        
	}

    void Checking()
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
                s[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            Destroy(other.gameObject);
            gameRule.Number_of_Char--;
            gameRule.SendMessage("Checking_Char",SendMessageOptions.DontRequireReceiver);
        }

        if (other.gameObject.CompareTag("Character_sky"))
        {
            Destroy(other.gameObject);
            gameRule.Number_of_Char--;
            gameRule.SendMessage("Checking_Char", SendMessageOptions.DontRequireReceiver);
        }
    }
}
