using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable Unity.InefficientPropertyAccess

public class CanonControl : MonoBehaviour {
    
    public Transform canonOut;
    public GameObject ballPrefab;
    public float minClamp, maxClamp;
    public float speed;
    public float power;
    public ForceMode forceMode;
    public int ammoCapacity = 50;
    private int currentAmmo;
    public TMP_Text ammoDisplay;

    //GameOver
    public float restartDelay = 5f;
    private float _mouseX; // valeur déplacemment souris
    public Animator anim; // Ref à l'anim de GameOver
    private float restartTimer; //Timer

    private void Awake()
    {
       
    }

    private void Start()
    {
        currentAmmo = ammoCapacity;
        Cursor.visible = false;
    }

    private void Update() {
        MoveCanon();
        ammoDisplay.text = "Munitions : " + currentAmmo.ToString();
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            FireCanon();
            currentAmmo--;
        }

        if (currentAmmo == 0) GameOver();
    }

    private void MoveCanon() {
        _mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
        _mouseX = Mathf.Clamp(_mouseX, minClamp, maxClamp);
        Quaternion rotation = Quaternion.Euler(0f, 0f, _mouseX);
        transform.rotation = rotation;
    }
    
    private void FireCanon() {
        GameObject instantiate = Instantiate(ballPrefab, canonOut.position, Quaternion.identity);
        instantiate.GetComponent<Rigidbody>().AddForce(transform.up * power, forceMode);
    }

    private void GameOver()
    {           
        // ... tell the animator the game is over.
        anim.SetTrigger("GameOver");

        // .. increment a timer to count up to restarting.
        restartTimer += Time.deltaTime;

        // .. if it reaches the restart delay...
        if(restartTimer >= restartDelay)
        {
            // .. then reload the currently loaded level.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}