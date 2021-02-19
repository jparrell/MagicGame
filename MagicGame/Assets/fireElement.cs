using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireElement : MonoBehaviour
{
    public GameObject FireElementPrefab;
    public Transform ElementPoint;

    void Update()
    {
        if (Input.GetButtonDown("FireElement"))
        {
            Instantiate(FireElementPrefab, ElementPoint.position, ElementPoint.rotation);
        }
    }   
}
