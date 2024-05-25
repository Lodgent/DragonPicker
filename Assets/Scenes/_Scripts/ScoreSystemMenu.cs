using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreSystemMenu : MonoBehaviour
{
    public Text scoreGT;
    public FloatOS scores;
    // Start is called before the first frame update
    void Start()
    {
        scoreGT.text = $"{scores.Value.ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
