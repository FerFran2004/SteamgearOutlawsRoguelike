using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CreationofGrid : MonoBehaviour
{
    Vector3 pos;
    public GameObject obj;
    

    void Start()
    {



    }
    // for (int i = 0; i < obj.Length; i++)
    // {
    //     pos = new Vector3[obj.Length];
    //     pos[0] = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
    //     pos[1] = new Vector3(transform.position.x + i, transform.position.y - 1, transform.position.z);
    //     //etc…
    //     Instantiate(obj, pos[0], transform.rotation);
    //     Instantiate(obj , pos[1], transform.rotation); 
    //* //etc…*
    //* }
    //*
}           //* }*
            //add number to transform.position.y to make new row. & miniplate the object scale to reduce gap between objects.