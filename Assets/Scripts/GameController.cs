using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject spherePrefab;
    public Transform gameArea;
    public int totalSpheres = 5;
    public float spawnRadius = 8f;
    public float spawnHeight = 0.5f;
    
    public Text scoreText;
    public GameObject winPanel;
    
    private int score = 0;
    private int spheresCollected = 0;
    
    void Start()
    {
        // Set player tag
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            player.tag = "Player";
        }
        
        // Initialize UI
        UpdateScoreText();
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        
        // Spawn collectible spheres
        SpawnSpheres();
    }
    
    void SpawnSpheres()
    {
        for (int i = 0; i < totalSpheres; i++)
        {
            // Calculate random position
            float angle = Random.Range(0f, Mathf.PI * 2f);
            float distance = Random.Range(2f, spawnRadius);
            float x = Mathf.Cos(angle) * distance;
            float z = Mathf.Sin(angle) * distance;
            
            Vector3 spawnPosition = new Vector3(x, spawnHeight, z);
            
            // Instantiate sphere
            GameObject sphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
            
            // Add SphereController if not already in prefab
            if (sphere.GetComponent<SphereController>() == null)
            {
                sphere.AddComponent<SphereController>();
            }
        }
    }
    
    public void CollectSphere()
    {
        spheresCollected++;
        score += 1;
        UpdateScoreText();
        
        // Check win condition
        if (spheresCollected >= totalSpheres)
        {
            Win();
        }
    }
    
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
    
    void Win()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        Debug.Log("You Win! All spheres collected.");
    }
}
