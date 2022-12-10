using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public GameObject objectTattoMachine;
    GameObject objectCreatedMachine;
    Vector3 firstPartStart;
    public AnimationClip[] Animclips;   

    public bool FirstStepStarted = false;
    public bool isMachineCreated;
    public bool EndOfFirstPart;
    public bool EndOfSecondPart;
    public bool EndOfthirdPart;
   


    TattoManager tmanager;

    void Start()
    {
        tmanager = FindObjectOfType<TattoManager>();
        firstPartStart = new Vector3(3.344716f, 1.668369f, -0.376135f);
    }
    void Update()
    {
        CreateTattoMachine();
    }
    public void CreateTattoMachine()
    {
        if (isMachineCreated == false && tmanager.IsFirstStep == true)
        {
            objectCreatedMachine = Instantiate(objectTattoMachine, firstPartStart, Quaternion.Euler(-10.545f, -45.993f, 10.729f));
            objectCreatedMachine.name = "TattoMachinePrefab";
            isMachineCreated = true;            
        }
    }
    //public void FirstPartTattoing()
    //{
        
    //    if (tmanager.IsFirstStep == true)
    //    {
    //        if (FirstStepStarted == false)
    //        {

    //            GameObject.Find("machinePrefab").GetComponent<Animation>().Play("FirstPartTatto");
    //            //objectCreatedMachine.GetComponent<Animation>().GetClip("FirstPartTatto");
    //            //objectCreatedMachine.GetComponent<Animation>().Play();
    //            //Anim.Play("FirstPartTatto");
    //            FirstStepStarted = true;
    //            Debug.Log("1.Adým Baþladý");
    //        }
    //        else { }
    //    }
    //    else { }
        
    //}
    //public void FirstPartEnded()
    //{
    //    EndOfFirstPart = true;
    //    tmanager.firstPart.SetActive(false);
    //    tmanager.secondPart.SetActive(true);
    //    GameObject.Find("machinePrefab").GetComponent<TrailRenderer>().time = 0;
    //    GameObject.Find("machinePrefab").GetComponent<TrailRenderer>().time = 999;

    //}
}
