using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_sky : MonoBehaviour {

    public float timeSeg;

    public bool moveFlag;
    public bool hitFlag;
    public GameObject Sigong;

    public int moveSpeed;

    private float times;
    private Animator ani;
    private bool direction; //true right / false left
    private Transform appear;

	// Use this for initialization
	void Start () {
        ani = gameObject.GetComponentInChildren<Animator>();
        appear = gameObject.transform.GetChild(0).GetComponent<Transform>();
        direction = true;
    }
	
	// Update is called once per frame
	void Update () {
        times += Time.deltaTime;

        if (moveFlag)
        {
            ani.SetBool("hit", false);
            ani.SetBool("fly", true);
            
            moving(direction);
        }
        else if(hitFlag)
        {
            if (Sigong != null)//주변에 시공이 있음
            {
                ani.SetBool("fly", false);
                ani.SetBool("hit", true);
                moving(Sigong.transform.position);
            }
        }
	}

    void moving(bool dir) // 1 or -1
    {
        if (dir)
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }
    void moving(Vector2 p)
    {
        this.transform.Translate(new Vector2(p.x-transform.position.x ,p.y-transform.position.y) * Time.deltaTime * moveSpeed);
    }
    
}
