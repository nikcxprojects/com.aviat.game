using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Enemy")) Destroy(col.gameObject);
        Debug.Log("ASDASD");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Enemy")) Destroy(col.gameObject);
        Debug.Log("ASDASD");    
    }
}
