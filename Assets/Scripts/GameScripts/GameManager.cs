using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BirdStats _birdStats;
    [SerializeField] private List<GameObject> birds;
    [SerializeField] private GameObject speedBoost;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject Menu;
    [SerializeField] private Button restartButton;
    private float spawnRate = 1.0f;
    private float xRange = 7f;
    private float yPos = 4f;


    public bool isGameActive = false;

    IEnumerator SpawnBird()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, birds.Count);
            Instantiate(birds[index],RandomSpawnPos(),birds[index].transform.rotation);
        }
    }

    IEnumerator SpawnBoost()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(10f);
            Instantiate(speedBoost, RandomSpawnPos(), speedBoost.transform.rotation);
        }
    }

   private Vector2 RandomSpawnPos()
    {
        return new Vector2(Random.Range(-xRange, xRange), yPos);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        _birdStats.Speed = difficulty;
        isGameActive = true;
        StartCoroutine(SpawnBird());
        StartCoroutine(SpawnBoost());
        Menu.gameObject.SetActive(false);
    }

}
