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
            summonFireElement(ElementPoint.position); 
        }
        if (firecooldown >= 2 && Input.GetButtonDown("FireElement"))
        {
            Vector2 pos = new Vector2(ElementPoint.position.x +1, ElementPoint.position.y);
            summonFireElement(pos);
        }
        
    }   

    void summonFireElement(Vector2 position)
    {
        var firemana = Instantiate(FireElementPrefab, position, ElementPoint.rotation);
        firemana.transform.parent = gameObject.transform;
        firecooldown = +1;
        Debug.Log(firecooldown);
    }
}
