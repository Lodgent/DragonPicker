using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f;
    public AudioSource audioSource;

    public bool isDestroied=false;
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        

    }
    void Update()
    {
        if (transform.position.y < -8f && !isDestroied)
        {
            ParticleSystem ps = GetComponent<ParticleSystem>();
            var em = ps.emission;
            em.enabled = true;
            Renderer rend;
            rend = GetComponent<Renderer>();
            rend.enabled = false;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            isDestroied = true;
            DragonPicker apScript =
Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
         
        }
    }
}
