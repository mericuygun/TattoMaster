using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Machine : MonoBehaviour
{
    public AudioClip audioMachine;    
    TattoManager tmanager;
    Drawing drawing;
    Vector3 secondPartStart;
    Vector3 thirdPartStart;
    [SerializeField] GameObject trailObject;
    public bool thirdPartEnd;
    Animator animatorX;
    GameObject temporaryObject;

    void Start()
    {
        animatorX = GetComponent<Animator>();
        animatorX.speed = 0;
        secondPartStart = new Vector3(3.339919f, 1.650992f, -0.3677087f);
        thirdPartStart = new Vector3(3.328784f, 1.635323f, -0.3626724f);
        tmanager = FindObjectOfType<TattoManager>();
        drawing = FindObjectOfType<Drawing>();
        GameObject objTrail = Instantiate(trailObject, transform);
        objTrail.transform.localEulerAngles = Vector3.zero;
        objTrail.transform.localPosition = Vector3.zero;
        objTrail.GetComponent<TrailRenderer>().time = 999;
        temporaryObject = objTrail;

    }


    void Update()
    {
        FirstPartTattoing();
    }
    public void FirstPartTattoing()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioMachine;

        if (tmanager.IsFirstStep == true)
        {


            if (Input.GetMouseButton(0))
            {
                audio.Play(); 
                animatorX.speed = 1;
                drawing.FirstStepStarted = true;
                Handheld.Vibrate();
            }
            if (Input.GetMouseButtonUp(0))
            {
                audio.Stop();
                animatorX.speed = 0;
            }

        }

    }
    public void FirstPartEnded()
    {
        tmanager.PoPups();
        drawing.EndOfFirstPart = true;
        animatorX.enabled = false; 
        tmanager.firstPart.SetActive(false);
        transform.DOMove(secondPartStart, 1f).SetEase(Ease.Linear);
        temporaryObject.transform.SetParent(null);
        StartCoroutine(SecondPartTimer());
    }
    public void SecondPartTattoing()
    {
        animatorX.SetBool("SecondPartTatto", true);
        animatorX.speed = 0;
        tmanager.secondPart.SetActive(true);
        GameObject objTrail = Instantiate(trailObject, transform);
        objTrail.transform.localEulerAngles = Vector3.zero;
        objTrail.transform.localPosition = Vector3.zero;
        objTrail.GetComponent<TrailRenderer>().time = 999;
        temporaryObject = objTrail;
        
    }
    public void ThirdPartTattoing()
    {
        animatorX.SetBool("ThirdPartTatto", true);
        tmanager.thirdPart.SetActive(true);
        animatorX.speed = 0;
        GameObject objTrail = Instantiate(trailObject, transform);
        objTrail.transform.localEulerAngles = Vector3.zero;
        objTrail.transform.localPosition = Vector3.zero;
        objTrail.GetComponent<TrailRenderer>().time = 999;
        temporaryObject = objTrail;
    }
    public void SecondPartEnded()
    {
        tmanager.PoPups();
        drawing.EndOfSecondPart = true;
        animatorX.enabled = false;
        tmanager.secondPart.SetActive(false);
        temporaryObject.transform.SetParent(null);
        transform.DOMove(thirdPartStart, 1f).SetEase(Ease.Linear);
        StartCoroutine(ThirdPartTimer());
    }
    public void ThirdPartEnded()
    {
        tmanager.PoPups();
        temporaryObject.transform.SetParent(null);
        thirdPartEnd = true;
        GameObject.Find("TattoMachinePrefab").transform.Translate(0,0,0);
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);

    }

    IEnumerator SecondPartTimer()
    {
        yield return new WaitForSeconds(1.5f);
        animatorX.enabled = true; 
        SecondPartTattoing();
    }
    IEnumerator ThirdPartTimer()
    {
        yield return new WaitForSeconds(0.5f);
        animatorX.enabled = true;
        ThirdPartTattoing();
    }

}
