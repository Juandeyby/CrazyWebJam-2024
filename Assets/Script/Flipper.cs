using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] GameObject flipper;
    [SerializeField] KeyCode keycode;
    [SerializeField] private float torqueAmount = 10000f;

    private Rigidbody2D flipperRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flipperRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        flipUp(keycode);
    }


    private void flipUp(KeyCode keyCode)
    {
        if(Input.GetKeyDown(keyCode))
        {

            flipperRB.AddTorque(torqueAmount,ForceMode2D.Force);

        };

    }
}
