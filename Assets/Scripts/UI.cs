using System;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] String gameOverText = "GAME OVER";
    GameObject[] pumpkins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pumpkins = GameObject.FindGameObjectsWithTag("Pumpkin");

        text.text = "Pumpkins: " + pumpkins.Length;

        if (pumpkins.Length <= 0)
        {
            text.text = gameOverText;
        }
    }
}
