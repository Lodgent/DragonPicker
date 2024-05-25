using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBomb : MonoBehaviour
{
    public static float bottomY = -30f;
    public AudioSource audioSource;

    public bool isDestroied = false;
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {


    }
    void Update()
    {
        
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

        }
    }
}
