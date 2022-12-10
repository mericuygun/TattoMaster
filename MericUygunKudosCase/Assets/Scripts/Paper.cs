//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class Paper : MonoBehaviour
//{
//    ButtonManager button2;
//    public GameObject objectPaper;
//    Vector3 v3Screen = new Vector3(0, 2, -0.7f);
//    Vector3 v3ScreenRot = new Vector3(0, -90f, 90);
//    void Start()
//    {
//        //DisplayPapers(); //ekrana geliyor.
//    }

//    public void DisplayPapers()
//    {
//        Debug.Log("Geldim");
        
//        objectPaper.transform.DOMove(v3Screen, 2f).SetEase(Ease.Linear);
//        objectPaper.transform.DORotate(v3ScreenRot, 2f).SetEase(Ease.Linear);
//        button2.start.gameObject.SetActive(true);
//    }
//}
