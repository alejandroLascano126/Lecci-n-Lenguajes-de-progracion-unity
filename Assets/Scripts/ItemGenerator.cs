using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;

    public float minTime = 5f; // Tiempo m�nimo entre spawns
    public float maxTime = 8f; // Tiempo m�ximo entre spawns
    public float offsetX = 30f;  // Incremento en X para cada spawn
    private float nextSpawnX;    // Posici�n X acumulativa para el siguiente spawn

    void Start()
    {
        // Inicializamos la posici�n inicial como la posici�n del SpawnManager
        nextSpawnX = transform.position.x;

        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio entre 1.5 y 2.5 segundos
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            // Crear la posici�n del siguiente objeto
            Vector3 spawnPosition = new Vector3(
                nextSpawnX,             // Posici�n X acumulativa
                transform.position.y,   // Mantener la posici�n Y del SpawnManager
                transform.position.z    // Mantener la posici�n Z del SpawnManager
            );

            // Instanciar el objeto en la posici�n calculada
            Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], spawnPosition, Quaternion.identity);

            // Aumentar la posici�n X acumulativa
            nextSpawnX += offsetX;
        }
    }
}


