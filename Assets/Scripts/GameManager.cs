using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int leavesAmount = 0;
    public TMP_Text leavesAmountText;
    public TMP_Text mannaAmountText;
    public TMP_Text waterAmountText;
    public TMP_Text timeUntilVictoryText;
    public int Manna = 100;

    public int Water = 100;
    public float TimerTimerTimer = 1f;
    public float TimerTimerTimer2 = 1f;
    public int TIME_UNTIL_VICTORY = 300;
    public float DrinkWaterTimer = 3f;
    public LeavesCollector clickerCollector;
    public Spawner spawmer_;
    public int GiveMannaAmount = 1;

    public bool MannaGeneratorEnabled = false;

    public int removeMannaAmount = 1;
    public float leafMannaChance = 0.08f;
    public bool CanGiveManna = false;
    public float direction = 0f;

    public float TimerUntillNextSpawn = 3f;
    public float currentSpawnTime = 0f;
    public int spawnAmount = 1;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        // removed shadowing of SceneManager; use API directly when needed
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime >= TimerUntillNextSpawn)
        {
            currentSpawnTime = 0f;
            spawmer_.GetComponent<Spawner>().SpawnObjects(spawnAmount);
            int value = Random.Range(0, 100);

            if (value <= 10)
            {
                spawnAmount += 1;
            }
            else if (value <= 35)
            {
                if (TimerUntillNextSpawn > 0.5f)
                {
                    TimerUntillNextSpawn -= 0.1f;
                }
            }
            else if (value >= 90)
            {
                TimerUntillNextSpawn += 0.5f;
            }
        }
        DrinkWaterTimer -= Time.deltaTime;
        if (DrinkWaterTimer <= 0f)
        {
            DrinkWaterTimer = 3f;
            Water -= Random.Range(1, 6);
            if (Water <= 0)
            {
                GameOver();
            }
        }
        if (TIME_UNTIL_VICTORY > 0)
        {
            TimerTimerTimer -= Time.deltaTime;
            if (TimerTimerTimer <= 0f)
            {
                TimerTimerTimer = 1f;
                TIME_UNTIL_VICTORY -= 1;
            }
        }
        else
        {
            YouWin();
        }
        if (MannaGeneratorEnabled == true)
        {
            TimerTimerTimer2 -= Time.deltaTime;
            if (TimerTimerTimer2 <= 0f)
            {
                TimerTimerTimer2 = 1f;
                Manna += GiveMannaAmount;
            }
        }
    }

    private void OnEnable()
    {
        Ticker.OnTickAction += Tick;
    }
    private void OnDisable()
    {
        Ticker.OnTickAction -= Tick;
    }

    private void Tick()
    {
        leavesAmountText.text = "Leaves: " + leavesAmount.ToString();
        mannaAmountText.text = "Manna: " + Manna.ToString();
        waterAmountText.text = "Water: " + Water.ToString();
        timeUntilVictoryText.text = "Time Until Victory: " + TIME_UNTIL_VICTORY.ToString();
    }

    public void AddLeaves(int amount)
    {
        leavesAmount += amount;
    }

    public void removeManna(int amount)
    {
        Manna -= amount;
        if (Manna < 0)
        {
            GameOver();
        }
    }

    public void AddManna(int amount)
    {
        Manna += amount;
    }
    public void GameOver()
    {
        Debug.Log("You lost the game");
        SceneManager.LoadScene("GameOver");
    }
    public void YouWin()
    {
        Debug.Log("You won the game");
        SceneManager.LoadScene("Victory..");
    }
    public void EnableOnHoldCollection()
    {
        if (clickerCollector != null) clickerCollector.onHold = true;
        clickerCollector.onDown = false;
    }
    public void MannaGenerator()
    {
        CanGiveManna = true;
        MannaGeneratorEnabled = true;
    }
}