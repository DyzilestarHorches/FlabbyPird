using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    bool isScored =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * GameObject.Find("GameMaster").GetComponent<GameMove>().MOVE_SPD * Time.deltaTime);
        if (this.transform.position.x <= -MoveGround.CAM_BARRIER - 5)
            Destroy(this.gameObject);
        if ((this.transform.position.x <= -1) && (!isScored))
        {
            GameObject.Find("GameMaster").GetComponent<Scoring>().AddScore();
            isScored = true;
        }
    }
}

