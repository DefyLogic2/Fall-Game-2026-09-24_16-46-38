using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject prefabToSpawn;
   public int numberOfObjects = 10; 
   public BoxCollider2D spawnArea;  
   public bool spawn_randomly = true;
        public bool spellspawner = false;
    public bool ENABLED = false;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    void Start()
    {
        if (spawnArea == null)
        {
            spawnArea = GetComponent<BoxCollider2D>();
        }

        SpawnObjects(numberOfObjects);
    }

    public void SpawnObjects(int amount1)
    {
        numberOfObjects = amount1;
        if (ENABLED)
        {

            Bounds bounds = spawnArea.bounds;
            if (spawn_randomly)
            {
                for (int i = 0; i < numberOfObjects; i++)
                {

                    float randomX = Random.Range(bounds.min.x, bounds.max.x);
                    float randomY = Random.Range(bounds.min.y, bounds.max.y);


                    Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

                    Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
                }

            }
            if (spawn_randomly == false)
            {
                for (int i = 0; i < numberOfObjects; i++)
                {

                    Vector3 myPosition = transform.position;
                    Instantiate(prefabToSpawn, myPosition, Quaternion.identity);
                }
            }



        }

    }
    void Spawn1()
    {
        if (ENABLED)
        {
            Bounds bounds = spawnArea.bounds;

            if (spawn_randomly == false)
            {
                for (int i = 0; i < numberOfObjects; i++)
                {

                    Vector3 myPosition = transform.position;
                    Instantiate(object1, myPosition, Quaternion.identity);
                }
            }



        }
      

    }
    void Spawn2()
    {
        if (ENABLED)
        {

            Bounds bounds = spawnArea.bounds;

            if (spawn_randomly == false)
            {
                for (int i = 0; i < numberOfObjects; i++)
                {

                    Vector3 myPosition = transform.position;
                    Instantiate(object2, myPosition, Quaternion.identity);
                }
            }


        }
       

    }
    void Spawn3()
    {
        if (ENABLED)
        {
            Bounds bounds = spawnArea.bounds;


            for (int i = 0; i < numberOfObjects; i++)
            {

                Vector3 myPosition = transform.position;
                Instantiate(object3, myPosition, Quaternion.identity);
            }




        }


    }
    void Spawn4()
    {
        if (ENABLED)
        {

            Bounds bounds = spawnArea.bounds;


            for (int i = 0; i < numberOfObjects; i++)
            {

                Vector3 myPosition = transform.position;
                Instantiate(object4, myPosition, Quaternion.identity);
            }


        }
        


    }
    void Spawn5()
    {
        if (ENABLED)
        {

            Bounds bounds = spawnArea.bounds;


            for (int i = 0; i < numberOfObjects; i++)
            {

                Vector3 myPosition = transform.position;
                Instantiate(object5, myPosition, Quaternion.identity);
            }


        }
      


    }

    void Spawn6()
    {
        if (ENABLED)
        {
            Bounds bounds = spawnArea.bounds;


            for (int i = 0; i < numberOfObjects; i++)
            {

                Vector3 myPosition = transform.position;
                Instantiate(object6, myPosition, Quaternion.identity);
            }



        }
       


    }
}
