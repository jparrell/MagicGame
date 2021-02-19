using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireElement : MonoBehaviour
{
    public GameObject FireElementPrefab;
    public Transform ElementPoint;
    private float firecooldown = 0f;

    void Update()
    {
        if (firecooldown == 0 && Input.GetButtonDown("FireElement"))
        {
            var firemana = Instantiate(FireElementPrefab, ElementPoint.position, ElementPoint.rotation);
            firemana.transform.parent = gameObject.transform;
            firecooldown = +1;      
        }
        //if (firecooldown == 1 && Input.GetButtonDown("FireElement"))
       // {
            //Destroy(FireElementPrefab);
        //}
    }   
}
