using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float tiempoSpawn;
    [SerializeField][Range(0,1)] private float chanceDeSpawn;
    [SerializeField] Enemy[] enemyPrefabs;

    private float ultimoTiempoSpawn;

    private void Start()
    {
        var bordeDerecho = Camera.main.ViewportToWorldPoint(Vector3.right);
        transform.position = new Vector2(bordeDerecho.x + 1, transform.position.y);
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying) return;

        if (Time.time - ultimoTiempoSpawn > tiempoSpawn)
        {
            float dado = Random.Range(0, 1);

            if(dado < chanceDeSpawn)
            {
                var instantiated = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
                instantiated.transform.position = transform.position;
                ultimoTiempoSpawn = Time.time;
            }
        }
    }
}
