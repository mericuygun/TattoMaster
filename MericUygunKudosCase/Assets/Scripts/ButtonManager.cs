using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;

public class ButtonManager : Singleton<ButtonManager>
{
    public Button start;
    public Button Tap;
    public GameObject objectConfetti;
    GameObject confettiFbx;
    Vector3 v3Camera;
    public bool getButton = false;
    public GameObject textObject1;
    public GameObject textObject2;
    public GameObject Undo;
    public GameObject example;
    public bool isExploded;
    bool IsReady = false;
    TattoManager Tmanager;
    public bool IsStarted;
    Customer customer;





    void Start()
    {        
        customer = GetComponent<Customer>();
        Tmanager = TattoManager.Instance;
        textObject1.SetActive(false);
        textObject2.SetActive(false);
        Undo.SetActive(false);
        example.SetActive(false);
        v3Camera = new Vector3(-0.13f, -0.111f, -0.016f);
    }

    void Update()
    {
        StartCoroutine(StartTattoTimer());
        StartTatto2();
    }

    public void StartTatto()
    {
        if (isExploded == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            confettiFbx = Instantiate(objectConfetti, v3Camera, Quaternion.identity);
            textObject1.SetActive(false);
            StartCoroutine(DestroyFbx());
            isExploded = true;
            GameObject.Find("TattoDesignPapers").SetActive(false);
            Tmanager.Tattoing();
        }
    }

    public void StartTatto2()
    {
        if (IsReady == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                textObject2.SetActive(false);
                Undo.SetActive(true);
                example.SetActive(true);
                IsStarted = true;
            }
        }

    }
    public void ActiveButton1()
    {
        textObject1.SetActive(true);
    }
    public void ActiveButton2()
    {
        textObject2.SetActive(true);
        IsReady = true;
    }
    IEnumerator DestroyFbx()
    {
        yield return new WaitForSeconds(3);
        Destroy(confettiFbx);
    }
    IEnumerator StartTattoTimer()
    {
        yield return new WaitForSeconds(10f);
        StartTatto();
    }
}
