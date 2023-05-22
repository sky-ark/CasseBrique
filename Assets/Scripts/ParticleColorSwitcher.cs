using UnityEngine;

public class ParticleColorSwitcher : MonoBehaviour {

    public ParticleSystem ballParticleSystem;

    private MeshRenderer _meshRenderer;
    
    private void Start() { 
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("Brick")) return;
        Color brickColor = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        _meshRenderer.material.color = brickColor;
        ParticleSystem.MainModule mainModule = ballParticleSystem.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(brickColor);
    }
    
}
