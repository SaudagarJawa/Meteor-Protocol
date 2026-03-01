using System.Collections;
using UnityEngine;

public class PipeSpawnder : MonoBehaviour
{
    public GameObject pipe;
    public float spawntime;
    public float yminposmin,yposmax;
    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }

    IEnumerator SpawnPipeCoroutine()
    {
         yield return new WaitForSeconds(spawntime);
         Instantiate(pipe,transform.position + Vector3.up * Random.Range(yminposmin,yposmax),Quaternion.identity);
        StartCoroutine(SpawnPipeCoroutine());
    }
}
