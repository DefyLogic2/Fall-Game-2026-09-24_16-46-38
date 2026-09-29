using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform _GameManager;
    public GameManager gameManager;
    public Collider2D collider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _GameManager = GameObject.Find("GameManager").transform;
        gameManager = _GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Leaf"))
        {
            gameManager.GameOver();
        }
        
    }
}
