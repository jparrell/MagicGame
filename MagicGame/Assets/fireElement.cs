using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireElement : MonoBehaviour
{
    public Transform FirstElementPoint;
    public Transform SecondElementPoint;
    public Transform ThirdElementPoint;
    public GameObject FireElementPrefab;
    public GameObject WaterElementPrefab;
    public GameObject LifeElementPrefab;
    private float ElementPosition = 0f;
    
    void Update()
    {
        //fireCODE
        if (ElementPosition == 0 && Input.GetButtonDown("FireElement"))
        {
            summonFireElement(FirstElementPoint.position); 
        }
        else if(ElementPosition == 1 && Input.GetButtonDown("FireElement"))
        {
            Vector2 pos = new Vector2(SecondElementPoint.position.x , SecondElementPoint.position.y);
            summonFireElement(pos);
        }
        else if(ElementPosition == 2 && Input.GetButtonDown("FireElement"))
        {
            Vector2 pos2 = new Vector2(ThirdElementPoint.position.x, ThirdElementPoint.position.y);
            summonFireElement(pos2);
        }

        //waterCODE
        if (ElementPosition == 0 && Input.GetButtonDown("WaterElement"))
        {
            summonWaterElement(FirstElementPoint.position);
        }
        else if(ElementPosition == 1 && Input.GetButtonDown("WaterElement"))
        {
            Vector2 pos = new Vector2(SecondElementPoint.position.x, SecondElementPoint.position.y);
            summonWaterElement(pos);
        }
        else if(ElementPosition == 2 && Input.GetButtonDown("WaterElement"))
        {
            Vector2 pos2 = new Vector2(ThirdElementPoint.position.x , ThirdElementPoint.position.y);
            summonWaterElement(pos2);
            Debug.Log(ElementPosition);
        }
    }   

    void summonFireElement(Vector2 position)
    {
        ElementPosition += +1f;   
        var firemana = Instantiate(FireElementPrefab, position, FirstElementPoint.rotation);
        firemana.transform.parent = gameObject.transform;
    }
    void summonWaterElement(Vector2 position)
    {
        ElementPosition += +1f;
        var Watermana = Instantiate(WaterElementPrefab, position, FirstElementPoint.rotation);
        Watermana.transform.parent = gameObject.transform;
    }
}
