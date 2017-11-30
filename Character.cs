using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    public bool moveFlag;
    public bool flyFlag;
    public bool hitFlag;

    public float checkTime;
    public float checkDistance;
    public int moveSpeed;
    public bool moveDir; //true right / false left

    public GameObject Sigong;

    
    private Animator ani;
    private Transform appear;

	// Use this for initialization
	void Start () {
        ani = gameObject.GetComponentInChildren<Animator>();
        appear = gameObject.transform.GetChild(0).GetComponent<Transform>();
        moveDir = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (moveFlag)
        {
            ani.SetBool("fly", false);
            ani.SetBool("hit", false);
            ani.SetBool("move", true);
            Checking_Ground();
            Moving(moveDir);
        }
        else if (flyFlag)
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
        else
        {
            Checking_Ground();
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


    void Checking_Ground()
    {
        Vector3 left = transform.position + new Vector3(-checkDistance, 0, 0);
        Vector3 right = transform.position + new Vector3(checkDistance, 0, 0);
        RaycastHit2D[] left_out = Physics2D.RaycastAll(left, Vector2.down,1);
        RaycastHit2D[] right_out = Physics2D.RaycastAll(right, Vector2.down,1);

        bool left_exist = false;
        bool right_exist = false;
        if (left_out.Length != 0)
        {
            left_exist = true;
            for (int i = 0; i < left_out.Length; i++)
            {
                if (left_out[i].transform.CompareTag("Ground"))
                {
                    continue;
                }
            }
        }
        else
        {
            left_exist = false;
        }

        if (right_out.Length != 0)
        {
            right_exist = true;
            for (int i = 0; i < right_out.Length; i++)
            {
                if (right_out[i].transform.CompareTag("Ground"))
                {
                    continue;
                }
            }
        }
        else
        {
            right_exist = false;
        }

        if (left_exist == false && right_exist == false)
        {
            flyFlag = true;
        }
        else if (left_exist == false && right_exist == true)
        {
            //움직임 변환
            moveDir = true;
            appear.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (left_exist == true &&right_exist == false)
        {
            //움직임 변환
            moveDir = false;
            appear.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            flyFlag = false;
            moveFlag = true;
        }
    }
}
