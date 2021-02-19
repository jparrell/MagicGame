using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireElement : MonoBehaviour
{
    public GameObject FireElementPrefab;
    public Transform ElementPoint;
    private float firePosition = 0f;
    
    void Update()
    {
        if (firePosition == 0 && Input.GetButtonDown("FireElement"))
        {
            summonFireElement(ElementPoint.position); 
        }
        else if(firePosition == 1 && Input.GetButtonDown("FireElement"))
        {
            Vector2 pos = new Vector2(ElementPoint.position.x +1.8f, ElementPoint.position.y);
            summonFireElement(pos);
            Debug.Log(firePosition);
        }
        else if(firePosition == 2 && Input.GetButtonDown("FireElement"))
        {
            Vector2 pos2 = new Vector2(ElementPoint.position.x +.9f, ElementPoint.position.y +1.2f);
            summonFireElement(pos2);
        }
    }   

    void summonFireElement(Vector2 position)
    {
        firePosition += +1f;
        var firemana = Instantiate(FireElementPrefab, position, ElementPoint.rotation);
        firemana.transform.parent = gameObject.transform;
        
        //Debug.Log(firePosition);
    }
}
