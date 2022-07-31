using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
            Destroy(collision.gameObject);
            Debug.Log("im here");
        }
    }
}
