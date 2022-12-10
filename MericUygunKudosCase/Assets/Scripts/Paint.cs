using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Paint : MonoBehaviour
{
    
    public Button redButton;
    public Button blueButton;
    public Button yellowButton;

    public GameObject objectTatto;
    public GameObject objectTop;
    public GameObject objectMid;
    public GameObject objectBottom;

    public GameObject objectFakeTop;
    public GameObject objectFakeMid;
    public GameObject objectFakeBottom;
    public GameObject objectFullTatto;

    Vector3 v3top = new Vector3(3.2738f, 1.6812f, -0.3991f);
    Vector3 v3mid = new Vector3(3.2675f, 1.6516f, -0.3841f);
    Vector3 v3bot = new Vector3(3.2646f, 1.6141f, -0.3642f);
    Vector3 v3full = new Vector3(3.2655f, 1.6439f, -0.3796f);

    Machine machine;
    CheckTatto checktatto;
    public bool IsGenerated;


    void Start()
    {
        checktatto = GameObject.FindObjectOfType<CheckTatto>();
        machine = GetComponent<Machine>();
    }


    void Update()
    {
        GenerateTatto();
    }

    public void GenerateTatto()
    {
        if (machine.thirdPartEnd == true && IsGenerated == false)
        {
            GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(true);
            objectFullTatto = Instantiate(objectTatto, v3full, Quaternion.Euler(-28, -12, 0));
            objectFakeTop = Instantiate(objectTop, v3top, Quaternion.Euler(-28, -12, 0));
            objectFakeMid = Instantiate(objectMid, v3mid, Quaternion.Euler(-28, -12, 0));
            objectFakeBottom = Instantiate(objectBottom, v3bot, Quaternion.Euler(-28, -12, 0));            
            IsGenerated = true;            
            GameObject.Find("TattoMachinePrefab").SetActive(false);
        }


    }


}
