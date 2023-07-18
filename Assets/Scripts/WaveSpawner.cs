using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public static int EnemiesAlive = 0;
    public TMP_Text countdownText;
    //[SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float countdown = 2f;

    private int waveIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameEnded) return;

        if (EnemiesAlive > 0) return;

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWaves());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f,Mathf.Infinity);
        countdownText.text = string.Format("{0:00.00}",countdown);
    }
    IEnumerator  SpawnWaves()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];

        Debug.Log("UMA NOVA ONDA TA CHEGANDO, MANO");

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("Win!");
            this.enabled = false;
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
