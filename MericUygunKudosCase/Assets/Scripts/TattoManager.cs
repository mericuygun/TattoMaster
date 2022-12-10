using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using DG.Tweening;



public class TattoManager : Singleton<TattoManager>
{
    bool isZoomed;
    public bool IsFirstStep;
    bool showPopUp;

    public GameObject[] confettis;
    public GameObject[] bravo;
    public GameObject objectSkin;
    public GameObject firstPart;
    public GameObject secondPart;
    public GameObject thirdPart;
    public GameObject objectTatto;

    Vector3 v3transformTatto = new Vector3(3.19f, 1.885f, 0.062f);
    Vector3 v3rotationTatto = new Vector3(27.882f, 169.879f, -0.036f);
    Vector3 v3transformSkin = new Vector3(3.2682f, 1.6505f, -0.3838f);
    Vector3 v3cam;
    Vector3 v3confetti = new Vector3(3.2608f, 1.6655f, -0.3509f);


    Machine machine;
    Camera mainCamera;
    Customer customerX;
    ButtonManager button2;
    void Start()
    {
        machine = GameObject.FindObjectOfType<Machine>();
        customerX = GameObject.FindObjectOfType<Customer>();
        button2 = GameObject.FindObjectOfType<ButtonManager>(); 
        mainCamera = Camera.main;
        v3cam = mainCamera.transform.position;

        firstPart = objectSkin.transform.GetChild(0).gameObject;
        secondPart = objectSkin.transform.GetChild(1).gameObject;
        thirdPart = objectSkin.transform.GetChild(2).gameObject;


        firstPart.gameObject.SetActive(true);
        secondPart.gameObject.SetActive(true);
        thirdPart.gameObject.SetActive(true);
    }


    void Update()
    {
        Tattoing();
        FirstStepOfTatto();        
    }
    public void Tattoing()
    {
                        
        if(button2.isExploded == true)
        {
            if(isZoomed == false)
            {          

                mainCamera.transform.DOMove(v3transformTatto, 2f).SetEase(Ease.Linear);
                mainCamera.transform.DORotate(v3rotationTatto, 2f).SetEase(Ease.Linear);
                mainCamera.fieldOfView = 40f;
                objectTatto = Instantiate(objectSkin, v3transformSkin, Quaternion.Euler(62, -12, 0));
                firstPart = objectTatto.transform.GetChild(0).gameObject;
                secondPart = objectTatto.transform.GetChild(1).gameObject;
                thirdPart = objectTatto.transform.GetChild(2).gameObject;                
                isZoomed = true;
                StartCoroutine(TaptoStartTimer());                
            }
            else
            {
                //nothing
            }            
        }    
        
    }
    void FirstStepOfTatto()
    {
        if (IsFirstStep == false)
        {
            if (button2.IsStarted == true)
            {
                secondPart.SetActive(false);
                thirdPart.SetActive(false);
                IsFirstStep = true;
            }
            else
            {
                //nothing
            }
        }
    }
    public void PoPups()
    {
        if (showPopUp == false)
        {            
            Vector3 screenPos = new Vector3(3.2687f, 1.6634f, -0.3872f);
            GameObject objectBravo = Instantiate(bravo[Random.Range(0, 2)], screenPos, Quaternion.Euler(28, -192, 0));
            GameObject objectConfetti = Instantiate(confettis[Random.Range(0,5)], v3confetti, Quaternion.identity);
            objectBravo.name = "bravomsg";
            objectBravo.transform.DOScale(0.02f, 2).SetEase(Ease.InOutBack);            
            Destroy(objectBravo, 2);
            Destroy(objectConfetti, 3);
            showPopUp = true;
            StartCoroutine(PopupTimer());
        }
    }
    IEnumerator TaptoStartTimer()
    {
        yield return new WaitForSeconds(1.5f);
        button2.ActiveButton2();
    }
    IEnumerator PopupTimer()
    {
        yield return new WaitForSeconds(2f);
        showPopUp = false;

    }
    
}
