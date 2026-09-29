using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneManage: MonoBehaviour
{
    void Start()
    {
    //    DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(string Name)
    {
        SceneManager.LoadScene(Name);
    }

    
  
}