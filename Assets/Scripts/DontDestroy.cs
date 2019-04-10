using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    static GameObject instance;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
