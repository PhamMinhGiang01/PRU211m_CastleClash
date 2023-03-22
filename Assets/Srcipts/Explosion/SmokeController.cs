using UnityEngine;

public class SmokeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float setup = 0.5f;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += ( Time.deltaTime);
        if (timer >= setup)
        {
            Destroy(gameObject);
        }
    }
}
