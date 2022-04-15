using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDown : MonoBehaviour
{

    public Rigidbody enemyRb;
    public GameObject projectilePrefab;

    public ParticleSystem explostion;

    private GameManager gameManager;

    public float speed = 30;

    public int pointValue;

    private float bottomBound = -20;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (transform.position.z < bottomBound && gameObject.CompareTag("Enemy"))

        {
            Destroy(gameObject);

        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        explosion();
        Destroy(other.gameObject);
        gameManager.UpdateScore(pointValue);

    }

    void explosion()
    {
        ParticleSystem explosion = Instantiate(explostion, transform.position, transform.rotation) as ParticleSystem;


        explosion.Play();


        Destroy(gameObject);

        
    }

}







