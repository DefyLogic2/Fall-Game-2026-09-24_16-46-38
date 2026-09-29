using UnityEngine;

public class SpellBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float spellDuration = 5f; // Duration of the spell effect in seconds
    public int mannaCost = 10; // Manna cost for casting the spell
    public Transform _GameManager;
    public GameManager gameManager;
    public int MannaCost = 20;
    public bool type1 = false;
    public bool type2 = false;
    public bool type3 = false;
    public bool type4 = false;
    public bool type5 = false;
    public bool type6 = false;
    public float direction = 0f;
    public float radius = 3f;
    public Rigidbody2D rb;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").transform;
        gameManager = _GameManager.GetComponent<GameManager>();
        this.direction = gameManager.direction;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Collect()
    {
        gameManager.removeManna(MannaCost);
        Leaves leaf = GetComponent<Leaves>();
        if (leaf != null)
        {
            leaf.Collect();
        }
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Leaves"));

        if (hit != null)
        {

            hit.gameObject.GetComponent<Leaves>().Collect();


        }
    }

    public void CastBasicSpell()
    {
        if (gameManager.Manna >= MannaCost)
        {
            Collect();
            Destroy(gameObject, spellDuration);
        }
        else
        {
            Debug.Log("Not enough manna to cast the spell!");
        }
    }

    public void CastTornadoSpell()
    {
        if (gameManager.Manna >= MannaCost)
        {
            rb.linearVelocity = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction)) * 5f;
            Collect();
            Destroy(gameObject, spellDuration);
        }
        else
        {
            Debug.Log("Not enough manna to cast the spell!");
        }
    }
    public void CastPusherSpell()
    {
        if (gameManager.Manna >= MannaCost)
        {
            Leaves leaf = GetComponent<Leaves>();
            if (leaf != null)
            {
                // pass direction vector, duration, and speed (adjust numbers as needed)
                leaf.Pushed(new Vector3(Mathf.Cos(direction), Mathf.Sin(direction), 0f), 0.5f, 5f);
            }
            Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Leaves"));

            if (hit != null)
            {

                hit.gameObject.GetComponent<Leaves>().Collect();


            }

            Destroy(gameObject, spellDuration);
        }
        else
        {
            Debug.Log("Not enough manna to cast the spell!");
        }
    }
}