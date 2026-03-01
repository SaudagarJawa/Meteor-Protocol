using UnityEngine;

public class PipeConttroller : MonoBehaviour
{
    public float pipespeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*pipespeed*Time.deltaTime);
    }
}
