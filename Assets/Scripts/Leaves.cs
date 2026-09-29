using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int Leaves_amount = 1;
    public bool Single;
    public bool Multiple;
    public bool CanMerge;
    public float MergeRadius = 1f;
    public bool MainLeaf;
    public Transform _GameManager;
    public GameManager gameManager;
    public bool playedRandomValue = false;
    public Leaves[] leafArray;


    public bool CanGiveManna;


    public bool randomRotation = true;
    public bool randomScale = true;
    public bool randomTexture = true;
    [SerializeField] public float scale1 = 1f;
    public float timer1 = 1f;
    public float timer2 = 1f;

    private Coroutine moveCoroutine;

    void Start()
    {

        if (randomRotation == true)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        }
        if (randomScale == true)
        {
            float randomScaleValue = Random.Range(9f, 12f);
            transform.localScale = new Vector3(randomScaleValue, randomScaleValue, 1f);
        }
        if (randomTexture == true)
        {
            // Apply random texture logic here
        }
        _GameManager = GameObject.Find("GameManager").transform;
        gameManager = _GameManager.GetComponent<GameManager>();
        scale1 = scale1 * Random.Range(1.1f, 1.3f);
        timer1 = timer1 * Random.Range(0.11f, 0.2f);
        timer2 = timer2 * Random.Range(0.12f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Merge()
    {
        if (CanMerge == true)
        {
            if (MainLeaf == true)
            {

            }
        }
    }
    public void Collect()
    {
        if (playedRandomValue == false)
        {

            if (gameManager.GetComponent<GameManager>().CanGiveManna == true)
            {
                float randomValue = Random.Range(0f, 1f);
                playedRandomValue = true;
                if (randomValue <= gameManager.GetComponent<GameManager>().leafMannaChance)
                {
                    gameManager.AddManna(gameManager.GiveMannaAmount);
                }
            }
        }

        // StartCoroutine(CollectAnimation(Vector3.one* scale1, timer1));
        StartCoroutine(CollectAnimation(Vector3.one * scale1, timer1, Vector3.one * 0.01f, timer2));
        //  gameManager.GetComponent<GameManager>().AddLeaves(Leaves_amount);
        //    this.gameObject.SetActive(false);

    }
    IEnumerator CollectAnimation(Vector3 scale1, float duration1, Vector3 finalScale, float duration2)
    {
        Vector3 startScale = transform.localScale;
        float elapsed = 0f;
        while (elapsed < duration1)
        {

            transform.localScale = Vector3.Lerp(startScale, scale1, elapsed / duration1);
            elapsed += Time.deltaTime;
            yield return null;
        }
        float elapsed2 = 0f;
        while (elapsed2 < duration2)
        {

            transform.localScale = Vector3.Lerp(startScale, finalScale, elapsed2 / duration2);
            elapsed2 += Time.deltaTime;
            yield return null;
        }
        gameManager.AddLeaves(Leaves_amount);
        transform.localScale = finalScale;
        Destroy(this.gameObject);
      
    }
    public void Pushed(Vector3 direction, float duration, float speed)
    {

        if (moveCoroutine != null) StopCoroutine(moveCoroutine);


        moveCoroutine = StartCoroutine(PushedRoutine(direction, duration, speed));
    }

    private IEnumerator PushedRoutine(Vector3 direction, float duration, float speed)
    {
        float elapsed = 0f;
        Vector3 normalizedDir = direction.normalized;

        while (elapsed < duration)
        {
            transform.position += normalizedDir * speed * Time.deltaTime;

            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    public void enableLeaf()
    {
        this.gameObject.SetActive(true);
    }
    public void disableLeaf()
    {
        this.gameObject.SetActive(false);
    }
}