using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    Rigidbody2D BirdRigid;
    public GameObject GM;
    public Animator Anim;

    const float JUMP_NUM = 50f;
    // Start is called before the first frame update
    void Start()
    {
        BirdRigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((!GM.GetComponent<GameMove>().isEnd) & ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Mouse0))))
        {
            Jump();
        }
    }

    void Jump()
    {
        BirdRigid.velocity = Vector2.up * JUMP_NUM;
        Anim.SetTrigger("isFlap");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject.Find("GameMaster").GetComponent<GameMove>().EndGame();
    }
}
