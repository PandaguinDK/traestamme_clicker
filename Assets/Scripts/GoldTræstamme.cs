using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTræstamme : MonoBehaviour
{
    public Canvas canvas;
    public GameObject GoldTræstammePrefab;
    public GameObject instantiatedGoldTræstamme;
    private float Offset = 200;
    private bool GoldTræstammeIsSpawning;
    public float GoldTræstammeMultiplier;
    bool force = false; 
    public float lowestCookieSpawnTime;
    public float highestCookieSpawnTime;

    void Start()
    {
        GoldTræstammeIsSpawning = false;
        GoldTræstammeMultiplier = 7;
        lowestCookieSpawnTime =  1;
        highestCookieSpawnTime = 100;
    }

    void Update()
    {
        if (GoldTræstammeIsSpawning == false)
        {
            Invoke("SpawnGoldTræstamme", Random.Range(lowestCookieSpawnTime, highestCookieSpawnTime));
            GoldTræstammeIsSpawning = true;
        }
    }

    [ContextMenu("Instantiate")]
    void SpawnGoldTræstamme()
    {
        float lowestPointX = transform.position.x - 400;
        float highestPointX = transform.position.x + Offset;
        float lowestPointY = transform.position.y - Offset;
        float highestPointY = transform.position.y + Offset;

        instantiatedGoldTræstamme = Instantiate(GoldTræstammePrefab, canvas.transform, force);
        instantiatedGoldTræstamme.transform.position = new Vector3 (Random.Range(lowestPointX, highestPointX), Random.Range(lowestPointY, highestPointY), 0);

    }
    [ContextMenu("PressGoldTræstamme")]
    public void GoldTræstammePressed()
    {
        LogicScript.moneyIncomeMultiplier += GoldTræstammeMultiplier;
        Destroy (instantiatedGoldTræstamme);
        Invoke("ResetGoldTræstammeMultiplier", 20f);
    }

    void ResetGoldTræstammeMultiplier()
    {
        LogicScript.moneyIncomeMultiplier -= GoldTræstammeMultiplier;
        GoldTræstammeIsSpawning = false;
    }
}
