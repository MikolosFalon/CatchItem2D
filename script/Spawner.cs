using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Zones Spawns")]
    public List<GameObject> Spawns;
    [Header("Coin item")]
    public List<GameObject> coin;
    [Header("Good Items")]
    public List<GameObject> good;
    [Header("Bad items")]
    public List<GameObject> bad;

    //list all lists items
    private List<List<GameObject>> items;
    //devay
    public int delaySpawns;

    private void Start()
    {
        items = new List<List<GameObject>>();
        //fixed balanse 
        //on 10 (5 coin +4 mine +1 life)
        for (int igold = 0; igold < 5; igold++)
        {
            items.Add(coin);
        }
        for (int imine = 0; imine < 4; imine++)
        {
            items.Add(bad);
        }
        for (int ilife = 0; ilife < 1; ilife++)
        {
            items.Add(good);
        }
        StartCoroutine(Spawn());
    }

    void SelectTapeItem()
    {
        if (!UIMenu.go)
        {
            //SelectTapeItem   
            //select spawn
            int sp = new int();
            sp = Random.Range(0, Spawns.Count);

            //select item list
            int it = new int();
            it = Random.Range(0, items.Count);

            //selest item
            int ite = new int();
            ite = Random.Range(0, items[it].Count);

            //spawns
            Instantiate(items[it][ite], Spawns[sp].transform.position, Quaternion.identity);

        }
    }

    IEnumerator Spawn()
    {
        SelectTapeItem();
        yield return new WaitForSeconds(delaySpawns);
        StartCoroutine(Spawn());
        yield return null;
    }
}
