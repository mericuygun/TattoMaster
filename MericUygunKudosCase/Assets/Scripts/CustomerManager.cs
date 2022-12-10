using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


public class CustomerManager : Singleton<CustomerManager>
{
    public GameObject customerPrefab;
    public GameObject Customer;
    Vector3 v3Spawn;

    void Start()
    {
        v3Spawn = new Vector3(3.307f, 0.1f, -4.681149f);
        StartCoroutine(Wait());
    }
    public void Beginning()
    {
        Customer = Instantiate(customerPrefab, v3Spawn, Quaternion.identity);
    }
    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(1);
        Beginning();
    }
}
