// Start Code
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDragon : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject dragonEggPrefab;
    public GameObject dragonBombPrefab;
    public GameObject HealPrefab;
    public float speed = 1f;
    public float timeBetweenEggDrops = 1f;
    public float timeBetweenBombDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirections = 0.1f;
    public List<System.Action> actions = new List<System.Action>();
    void Loads()
    {
        int r = Random.Range(0, 3);
        actions[r]();
    }

    void Start()
    {
        actions.Add(DropEgg);
        actions.Add(DropBomb);
        actions.Add(DropHeal);
        InvokeRepeating("Loads", 0.0f, timeBetweenEggDrops);
    }
    void DropHeal() // 2
    {
        Vector3 myVector = new
        Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(HealPrefab);
        egg.transform.position =
        transform.position + myVector;
        //Invoke("DropEgg", timeBetweenEggDrops);
    }
    void DropEgg() // 2
    {
        Vector3 myVector = new
        Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position =
        transform.position + myVector;
        //Invoke("DropEgg", timeBetweenEggDrops);
    }
    void DropBomb() // 2
    {
        Vector3 myVector = new
        Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonBombPrefab);
        egg.transform.position =
        transform.position + myVector;
        //Invoke("DropEgg", timeBetweenBombDrops);
    }

    void Update()
    {
        Vector3 pos = transform.position; //1
        pos.x += speed * Time.deltaTime; //2
        transform.position = pos; //3
        if (pos.x < -leftRightDistance) //1
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance) //2
        {
            speed = -Mathf.Abs(speed);
        }

    }
    private void FixedUpdate()
    {
        if (Random.value < chanceDirections)
        {
            speed *= -1;
        }
    }

}

