using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //phisix element
    public Rigidbody2D RB;
    //speed move
    public float speadMove;

    // dick texture
    public List<Sprite> dicks;
    public SpriteRenderer dick;

    // value for change evry 10 point
    public int dickValue = 10;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!UIMenu.go)
        {
            RB.AddForce(Vector2.right * Input.GetAxis("Horizontal") * speadMove);
        }

    }
    private void Update()
    {
        if (dickValue <= UIMenu.Score)
        {
            dickValue +=10;
            ChangeSkin();
        }
    }
    void ChangeSkin()
    {
        int ck = new int();
        ck = Random.Range(0,  dicks.Count);
        dick.sprite = dicks[ck];
    }
}
