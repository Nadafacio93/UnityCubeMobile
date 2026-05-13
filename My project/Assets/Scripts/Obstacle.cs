using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 rotation;
    public ParticleSystem destructionParticle;
    private void Start()
    {
        var xRotation = Random.Range(0.5f, 1f);
        rotation = new Vector3(xRotation, 0);
    }
    private void Update()
    {
        transform.Rotate(rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(destructionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
