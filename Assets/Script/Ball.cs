using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float launchForce = 100f;
    private Rigidbody2D ballRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        AddBallForce(launchForce);
    }

    private void AddBallForce(float force)
    {
        ballRB.AddForce(Vector3.up * force, ForceMode2D.Impulse);
    }
    
}
