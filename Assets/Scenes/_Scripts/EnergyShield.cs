using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyShield : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceBomb;
    public Text scoreGT;
    public FloatOS score;
    void Start()
    {
        GameObject scoreGO =
        GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = score.Value.ToString();
    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision coll)
    {
        GameObject Collided = coll.gameObject;
        if(Collided.tag == "Dragon Bomb")
        {
            Destroy(Collided);
            DragonPicker apScript =
Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
            apScript.BombDestroyed();
        }
        if (Collided.tag == "Dragon Egg")
        {
            Destroy(Collided);
            //var scoreonly = scoreGT.text.Split(" ")[1];
            //int score = int.Parse(scoreonly);
            //score += 1;
            score.Value += 1;
            scoreGT.text = score.Value.ToString();
            audioSource.Play();
        }
        if (Collided.tag == "Dragon Heal")
        {
            Destroy(Collided);
            DragonPicker apScript =
Camera.main.GetComponent<DragonPicker>();
            apScript.HealDestroyed();
            audioSource.Play();
        }

    }
}
