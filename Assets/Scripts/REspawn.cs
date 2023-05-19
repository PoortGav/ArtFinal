using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REspawn : MonoBehaviour
{
    public GameObject sp;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = sp.transform.position;
        }

    }
}
