using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeping : MonoBehaviour
{
    public Text p1;
    public int p1Score;

    public Text p2;
    public int p2Score;

    public bool p1Turn;

    public void BlockBroken()
    {
        switch (p1Turn)
        {
            case true:
                p1Score++;
                p1.text = p1Score.ToString();
                break;

            case false:
                p2Score++;
                p2.text = p2Score.ToString();
                break;
        }
    }
}
