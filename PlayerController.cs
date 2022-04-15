using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public GameObject projectilePrefab;

    

    public ParticleSystem shipExplode;
    public ParticleSystem smokeTrail;

    public float projectilespeed;
    public float fireRate = 8;
    public float nextFire = 1;

    private GameManager gameManager;

    private AudioSource playerAudio;

    
    public AudioClip FireMislle;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        lockPLayerIn();
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Vector3 posOffset = transform.position;
            posOffset.z += 1.5f;

            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            missileTrail();

            smokeTrail.Play();
            playerAudio.PlayOneShot(FireMislle, 5.0f);
        }

        


    }
    void lockPLayerIn()
    {
        //boundaries for X
        float xPos = Mathf.Clamp(transform.position.x, -12.4f, 10.1f);
        transform.position = new Vector3(xPos, transform.position.y,
                                          transform.position.z);
        //boundaries for Z
        float zPos = Mathf.Clamp(transform.position.z, -16.3f, 20);
        transform.position = new Vector3(transform.position.x, transform.position.y,
                                         zPos);
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
            isGameActive = false;
            gameManager.GameOver();
            Explode();
          

        }
       

    }
   
    
    public void Explode()
    {
        ParticleSystem explosion = Instantiate(shipExplode, transform.position,transform.rotation) as ParticleSystem;
        
       
        explosion.Play();
        shipExplode.Play();

        Destroy(gameObject);

    }

    void missileTrail()
    {
        ParticleSystem sMKTrail = Instantiate(smokeTrail, transform.position, transform.rotation) as ParticleSystem;

        sMKTrail.Play();
    }
}
