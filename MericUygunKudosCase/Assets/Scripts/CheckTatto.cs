using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CheckTatto : MonoBehaviour
{
    public Button finishButton;
    Color blueColor;
    Color redColor;
    Color yellowColor;
    Color newColorss;
    Paint paint;
    public GameObject alt;
    public GameObject ust;
    public GameObject orta;

    Color objeTop;
    Color objeMid;
    Color objeBot;
    bool isReady;
    bool GetCol;

    public GameObject failPopUp;
    public GameObject winPopUp;
    public GameObject[] confettis;

    public Button tryAgain;
    public Button skipLevel;
    public Button nextLevel;

    Vector3 screenPos = new Vector3(3.2687f, 1.6634f, -0.3872f);
    Vector3 v3confetti = new Vector3(3.231f, 1.296f, -0.177f);

    void Start()
    {

        paint = GetComponent<Paint>();
        blueColor = new Color(0, 0.1023216f, 1);
        redColor = new Color(0.9254903f, 0.04705883f, 0.04705883f);
        yellowColor = new Color(0.9607844f, 0.8862746f, 0);


    }


    void Update()
    {
        GetColors();




    }

    public void CheckTattoWhenPress()
    {


        if (objeTop == redColor && objeMid == yellowColor && objeBot == redColor)
        {
            WinScreen();
            Debug.Log("Ýçerdema");
        }
        else
        {

            LoseScreen();


        }


    }
    void WinScreen()
    {
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(false);

        GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(true);
        GameObject winConfetti = Instantiate(confettis[Random.Range(0, 6)], v3confetti, Quaternion.Euler(-103, -12, 0));
        GameObject winPopup = Instantiate(winPopUp, screenPos, Quaternion.Euler(28, -192, 0));
        winPopup.transform.DOScale(0.04f, 2f).SetEase(Ease.InCirc);

    }

    void LoseScreen()
    {
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(false);

        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(true);
        GameObject losePopUp = Instantiate(failPopUp, screenPos, Quaternion.Euler(28, -192, 0));
        losePopUp.transform.DOScale(0.04f, 2f).SetEase(Ease.InCirc);
    }

    void GetColors()
    {


        GameObject objTop = GameObject.Find("ust(Clone)");
        if (objTop != null)
        {
            objeTop = objTop.GetComponent<SpriteRenderer>().color;
        }


        GameObject objMid = GameObject.Find("orta(Clone)");
        if (objMid != null)
        {
            objeMid = objMid.GetComponent<SpriteRenderer>().color;
        }


        GameObject objBot = GameObject.Find("alt(Clone)");
        if (objBot != null)
        {
            objeBot = objBot.GetComponent<SpriteRenderer>().color;
        }
    }
}





