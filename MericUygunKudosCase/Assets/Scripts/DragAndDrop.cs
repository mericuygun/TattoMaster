using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public Button finishButton;
    public GameObject PaintSymbol;
    public List<Color> listOfColors = new List<Color>();
    private int colorIndex = 0;

    public Camera camerax;

    void Start()
    {       

    }

    public void ColorIndexChange(int colorIndexLocal)
    {
        colorIndex = colorIndexLocal;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camerax.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Tatto")
            {

                hit.transform.GetComponent<SpriteRenderer>().color = listOfColors[colorIndex];

            }
        }        
    }      
}
