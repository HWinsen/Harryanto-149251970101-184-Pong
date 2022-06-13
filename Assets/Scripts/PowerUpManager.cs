using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Transform spawnArea;
    [SerializeField] private int maxPowerUpAmount;
    [SerializeField] private int spawnInterval;
    [SerializeField] private int removeInterval;
    [SerializeField] private Vector2 powerUpAreaMin;
    [SerializeField] private Vector2 powerUpAreaMax;

    private List<GameObject> powerUpList;
    [SerializeField] private List<GameObject> powerUpTemplateList;

    private float spawnTimer;
    private float removeTimer;

    // Start is called before the first frame update
    void Start()
    {
        powerUpList = new List<GameObject>();
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnInterval)
        {
            GenerateRandomPowerUp();
            spawnTimer -= spawnInterval;
        }

        if(powerUpList.Count > 0) {
            removeTimer += Time.deltaTime;

            if (removeTimer > removeInterval)
            {
                RemovePowerUp(powerUpList[0]);
                removeTimer -= removeInterval;
            }
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if(position.x < powerUpAreaMin.x ||
           position.x > powerUpAreaMax.x ||
           position.y < powerUpAreaMin.y ||
           position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0) {
            RemovePowerUp(powerUpList[0]);
        }
    }

    public void ResetTimer()
    {
        spawnTimer = 0;
        removeTimer = 0;
    }
}
