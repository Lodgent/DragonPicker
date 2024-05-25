using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DragonPicker : MonoBehaviour
{
    public AudioSource audioBomb;
    public GameObject energyShieldPrefab;
    public Image healBar; 
    public int numEnergyShield = 3;
    public float energyShieldButtomY = -6f;
    public float energyShieldRadius = 1.5f;
    public int maxHeal = 4;
    public int currentHeal;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 1; i <= numEnergyShield; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
            tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
            tBasketGo.transform.localScale =
            new Vector3(1 * i, 1 * i, 1 * i);
            basketList.Add(tBasketGo);
        }
        currentHeal = basketList.Count;
    }
    void Update()
    { 
        currentHeal=basketList.Count;
        healBar.fillAmount= (float)currentHeal/(float)maxHeal;
    }
    public void BombDestroyed()
    {
        audioBomb.Play();
    }
    public void DragonEggDestroyed()
    {
        //GameObject[] tDragonEggArray =
        //GameObject.FindGameObjectsWithTag("Dragon Egg");
        //foreach (GameObject tGO in tDragonEggArray)
        //{
        //    Destroy(tGO);
        //}
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);


        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_0Scene");
        }
    }
    public void HealDestroyed()
    {
        //GameObject[] tDragonEggArray =
        //GameObject.FindGameObjectsWithTag("Dragon Egg");
        //foreach (GameObject tGO in tDragonEggArray)
        //{
        //    Destroy(tGO);
        //}
        int basketCount = basketList.Count+1;
        if (basketCount != 5)
        {
            GameObject newBasketGo = Instantiate<GameObject>(energyShieldPrefab);
            newBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
            newBasketGo.transform.localScale = new Vector3(1 * basketCount, 1 * basketCount, 1 * basketCount);
            basketList.Add(newBasketGo);
        }
    }
}
