using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMove : MonoBehaviour
{
    public float MOVE_SPD = 50f;
    public GameObject ground, a;
    public GameObject pipe, p, head;
    public bool isEnd = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Finish(35);
        HeadOn(p,35);
    }

    // Update is called once per frame
    void Update()
    {
        GroundMove();
        PipeMove();
        CloudMove();
    }

    void GroundMove()
    {
        GameObject b = a;
        if (a.transform.position.x <= 0)
        {
            a = Instantiate(ground) as GameObject;
            a.transform.position = (Vector2)b.transform.position + new Vector2(2 * MoveGround.HWIDTH_GROUND - 1, 0);
        }
    }

    void PipeMove()
    {
        GameObject b = p;
        if (b.transform.position.x <= 108 - 35)  //108 is where pipe be generated, 35 is de distance between 2 pipes
        {
            p = Instantiate(pipe) as GameObject;
            p.transform.position = new Vector2(108, -35);
            p.transform.localScale = new Vector2(1, Random.Range(20, 50));
            Finish(p.transform.localScale.y);
            HeadOn(p,p.transform.localScale.y);
        }
    }

    void CloudMove()
    {

    }

    void Finish(float Height)
    {
        GameObject b;
        b = Instantiate(pipe) as GameObject;
        b.transform.position = new Vector2(108, -35 + Height + 20);
        b.transform.localScale = new Vector2(1, 70 - Height - 20);
        HeadOn(b, 0);
    }

    void HeadOn(GameObject tmp, float height)
    {
        GameObject b = Instantiate(head) as GameObject;
        b.transform.position = new Vector2(tmp.transform.position.x, tmp.transform.position.y + height);
        b.transform.SetParent(tmp.transform);
    }

    public void EndGame()
    {
        MOVE_SPD = 0;
        isEnd = true;
    }
}


