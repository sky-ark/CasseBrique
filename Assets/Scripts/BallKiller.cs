using UnityEngine;

public class BallKiller : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Ball")) return;
        Destroy(other.gameObject);
    }
    
}
