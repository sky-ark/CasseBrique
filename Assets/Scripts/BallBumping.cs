using UnityEngine;

public class BallBumping : MonoBehaviour {

    public float bumpPower;
    
    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("Ball")) return;
        Vector3 contactVector = collision.contacts[0].normal;
        Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(contactVector * bumpPower, ForceMode.Force);
    }

}
