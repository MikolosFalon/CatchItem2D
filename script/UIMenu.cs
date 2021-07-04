using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMenu : MonoBehaviour
{
    //life
    public List<Image> LifeImage;
    public List<Sprite> LifeSprite;
    public static int life;

    //score 
    public TMP_Text ScoreFild;
    public static int Score;

    //hi score 
    public TMP_Text hiScoreFild;
    public static int hiScore;

    //game ower
    public GameObject gameOwer;
    public static bool go=true;

    // set start value
    public void StartNew()
    {
        life = 2;
        Score = 0;
        //cheack save
        hiScore = PlayerPrefs.GetInt("HiScore");
        StartCoroutine(UpdateProgress());
        gameOwer.SetActive(false);
        go = false;
        ScoreFild.text = Score.ToString();
        hiScoreFild.text = hiScore.ToString();
    }

    // update 
    IEnumerator UpdateProgress()
    {
        yield return new WaitForSecondsRealtime(0.5F);
        UpdateLife();
        UpdateScore();


        if (life < 0)
        {
            DeadPlayer();
        }
        else
        {
            StartCoroutine(UpdateProgress());
        }
        yield return null;
    }
    void UpdateLife()
    {
        // LifeSprite[0] not life
        // LifeSprite[1] have life
        for (int i = 0; i < LifeImage.Count; i++)
        {
            if (i <= life)
            {
                LifeImage[i].sprite = LifeSprite[1];
            }
            else
            {
                LifeImage[i].sprite = LifeSprite[0];
            }
        }
        //score
    }
    void UpdateScore()
    {
        if (hiScore < Score)
        {
            hiScore = Score;
        }
        ScoreFild.text = Score.ToString();
        hiScoreFild.text = hiScore.ToString();
    }
    void DeadPlayer()
    {
        gameOwer.SetActive(true);
        go = true;
        if (Score == hiScore)
        {
            PlayerPrefs.SetInt("HiScore", hiScore);
        }
    }
}
