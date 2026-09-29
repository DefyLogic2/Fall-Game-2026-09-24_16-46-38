using UnityEngine;

public class LeavesCollector : MonoBehaviour
   
{
    public Transform gameManager;
    public float radius = 1.5f;
    public Color gizmoColor = Color.red;
    public bool onDown = true;
    public bool onHold = false;
    public bool ENABLED = true;
    void Start()
    {
      //  Gizmos.color = gizmoColor;
        gameManager = GameObject.Find("GameManager").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ENABLED) 
        {
            if (Input.GetMouseButton(0))
            {

                if (onHold)
                {
                    Collect();
                }

            }
        }
       
    }
    private void OnDrawGizmosSelected()
    {
       
        Gizmos.color = gizmoColor;

        Gizmos.DrawWireSphere(transform.position, radius);

      
        // Color fillColor = gizmoColor;
        // fillColor.a = 0.2f;
        // Gizmos.color = fillColor;
        // Gizmos.DrawSphere(transform.position, radius);
    }
    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown fired on " + gameObject.name);
        if (ENABLED)
        {
            if (onDown)
            {
                Collect();
                gameManager.GetComponent<GameManager>().removeManna(1);

            }
            if (onHold)
            {

                Collect();
                gameManager.GetComponent<GameManager>().removeManna(5);

            }
        }
      
      

    }
    public void Collect()
    {
        Leaves leaf = GetComponent<Leaves>();
        if (leaf != null)
        {
            leaf.Collect();
        }
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Leaves"));


        if (hit != null)
        {

            Leaves hitLeaves = hit.gameObject.GetComponent<Leaves>();
            if (hitLeaves != null)
            {
                hitLeaves.Collect();
            }
        }
    }
}
