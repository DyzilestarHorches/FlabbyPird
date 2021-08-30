using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public const float HWIDTH_GROUND = 113f;
    public const float CAM_BARRIER = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * GameObject.Find("GameMaster").GetComponent<GameMove>().MOVE_SPD * Time.deltaTime);
        if (this.transform.position.x <= - HWIDTH_GROUND - CAM_BARRIER)
            Destroy(this.gameObject);
    }
}
