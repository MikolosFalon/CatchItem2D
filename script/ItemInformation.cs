using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour
{
    public enum ItemTape
    {
        coin=1,
        life=2,
        deat=3
    }
    public ItemTape itemTape;

    public float timeLife;
    // rigitbody
    public Rigidbody2D RB;


    void Start()
    {
        StartCoroutine(Deat());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!UIMenu.go)
        {
            if (collision.name == "Player")
            {
                if (itemTape.ToString()== "coin")
                {
                    UIMenu.Score++;
                }
                if (itemTape.ToString() == "life")
                {
                    //cheack limit life 
                    if (UIMenu.life < 8)
                    {
                        UIMenu.life++;
                    }
                }
                if (itemTape.ToString() == "deat")
                {
                    UIMenu.life--;
                }
                Destroy(gameObject);
            }
        }
    }
    IEnumerator Deat()
    {
        yield return new WaitForSeconds(timeLife);
        Destroy(gameObject);
        yield return null;
    }
    private void FixedUpdate()
    {
        RB.AddForce(Vector2.down);
    }
}
