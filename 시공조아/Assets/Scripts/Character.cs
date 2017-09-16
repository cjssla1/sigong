using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float timeSeg;

    public bool moveFlag;
    public bool jumpFlag;
    public bool hitFlag;

    public GameObject Sigong;

    public int moveSpeed;

    private float times;
    private Animator ani;
    private bool moveDir; //true right / false left
    private Transform appear;

	// Use this for initialization
	void Start () {
        ani = gameObject.GetComponentInChildren<Animator>();
        appear = gameObject.transform.GetChild(0).GetComponent<Transform>();
        moveDir = true;
    }
	
	// Update is called once per frame
	void Update () {
        times += Time.deltaTime;

        if (moveFlag)
        {
            ani.SetBool("hit", false);
            ani.SetBool("move", true);
            
            Moving(moveDir);
        }
        else if (jumpFlag)
        {
            ani.SetBool("hit", false);
            ani.SetBool("fly", true);

        }
        else if(hitFlag)
        {
            if (Sigong != null)//주변에 시공이 있음
            {
                ani.SetBool("hit", true);
                Moving(Sigong.transform.position);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Checking();
        }
	}

    void Moving(bool dirX) // true right or false left
    {
        if (dirX == true)
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else if(dirX == false)
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }
    void Moving(Vector2 p)
    {
        this.transform.Translate(new Vector2(p.x-transform.position.x ,p.y-transform.position.y) * Time.deltaTime * moveSpeed);
    }

    void Moving(Vector2 first,Vector2 second)
    {

    }

    void Checking()
    {
        Vector3 left = transform.position + new Vector3(-0.5f, 0, 0);
        Vector3 right = transform.position+ new Vector3( 0.5f, 0, 0);
        RaycastHit2D[] left_out = Physics2D.RaycastAll(left, Vector2.down);
        RaycastHit2D[] right_out = Physics2D.RaycastAll(right,Vector2.down);

        Debug.DrawRay(right, Vector3.down, Color.red, 1.0f);


        for (int i = 0; i < left_out.Length; i++)
        {
            if (left_out[i].transform.CompareTag("Ground"))
            {
                continue;
            }
            //움직임 변환
            moveDir = moveDir ? false : true; 
        }

        for (int i = 0; i < right_out.Length; i++)
        {
            if (!right_out[i].transform.CompareTag("Ground"))
            {
                continue;
            }

            moveDir = moveDir ? false : true;
        }
        
    }


}
