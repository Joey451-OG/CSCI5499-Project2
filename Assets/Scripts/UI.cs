using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] CanvasRenderer pumpkinText;
    [SerializeField] CanvasRenderer healthText;
    [SerializeField] String gameOverText = "GAME OVER";
    [SerializeField] String deadText = "GAME OVER";
    [SerializeField] GameObject deadScreen;
    GameObject[] pumpkins;
    Health _player;

    private bool isReloading = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Health>();
        deadScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pumpkins = GameObject.FindGameObjectsWithTag("Pumpkin");

        pumpkinText.GetComponent<TMP_Text>().text = "Pumpkins: " + pumpkins.Length;
        healthText.GetComponent<TMP_Text>().text = "Health: " + _player.getHP();

        if (pumpkins.Length <= 0)
        {
            pumpkinText.GetComponent<TextMeshPro>().text = gameOverText;
        }

        if (_player.getHP() < 0)
        {
            if (isReloading) return;
            isReloading = true;

            deadScreen.SetActive(true);

            Invoke("ExecuteReload", 5f);
        }
    }

    void ExecuteReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
