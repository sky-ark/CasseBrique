using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickHealth : MonoBehaviour
{
    public int health;
    public ParticleSystem _Particle;

    public int damage;

    public AudioClip BlockDestroyedSound;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            _Particle.Play();
            GameWonScript.DestroyedBrick += 1;
            //GetComponent<AudioSource>().clip = BlockDestroyedSound;
            //GetComponent<AudioSource>().Play();
            BrickSound.BlockDestroyed = true;
            Destroy(gameObject);
            
            Debug.Log(GameWonScript.DestroyedBrick);

        }
    }
    private void OnCollisionEnter(Collision collision )
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        health -= damage;
    }
}
