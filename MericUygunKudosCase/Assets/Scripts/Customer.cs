using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Customer : CustomerManager
{

    Animator customerAnim;
    public GameObject objectSpeechBubble;
    public Camera mainCam;
    Vector3 v3Scene = new Vector3(3.307f, 0.1f, -0.778f);
    public float speed = 30;

    
    [Header("Button&Papers")]
    ButtonManager button2;
    public GameObject objectPaper;
    Vector3 v3Screen = new Vector3(0, 2, -0.7f);
    Vector3 v3ScreenRot = new Vector3(0, -90f, 90);
    public bool isMoved;
    public GameObject objectSkin;
    public bool canPress;



    void Start()
    {
        objectSpeechBubble.SetActive(false);
        button2 = ButtonManager.Instance;
        customerAnim = GetComponent<Animator>();
        customerAnim.Play("walk");
        mainCam = Camera.main;
        gameObject.transform.DOMove(v3Scene, 3).OnComplete(SahneyeGeldiginde).SetEase(Ease.Linear);
    }
    void Update()
    {
        
    }
    public void SahneyeGeldiginde()
    {
        gameObject.transform.DOLookAt(mainCam.transform.position, 1, AxisConstraint.Y).SetEase(Ease.OutQuint);
        StartCoroutine(Bubble());
        customerAnim.Play("idle");
        StartCoroutine(PointingGesture());
    }

    IEnumerator Bubble()
    {
        yield return new WaitForSeconds(1f);
        objectSpeechBubble.SetActive(true);
        yield return new WaitForSeconds(3f);
        DisplayPapers();
    }   

    void DisplayPapers()
    {
        GameObject tattoObject = GameObject.Find("TattoDesignPapers");
        if(tattoObject != null)
        {
            tattoObject.transform.DOMove(v3Screen, 2f).SetEase(Ease.Linear);
            tattoObject.transform.DORotate(v3ScreenRot, 2f).SetEase(Ease.Linear);
            canPress = true;
        }
        StartCoroutine(StartTattoingButton());
    }

    IEnumerator StartTattoingButton()
    {
        yield return new WaitForSeconds(2f);
        button2.ActiveButton1();
    }
    IEnumerator PointingGesture()
    {
        yield return new WaitForSeconds(1f);
        customerAnim.Play("point");        
    }

}
