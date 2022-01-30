
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedForce;
    private float horizontalInput;
    Vector3 scale;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //flipping
        scale = transform.localScale;
        if(horizontalInput < 0)
        {
            scale.x = -1f * Mathf.Abs(horizontalInput);
            transform.localScale = scale;
        }else if(horizontalInput > 0)
        {
            scale.x = Mathf.Abs(horizontalInput);
            transform.localScale = scale;
        }

        //horizontal movement
        Vector2 position =transform.position;
        position.x +=  horizontalInput * speedForce *Time.deltaTime;
        transform.position=position;

    }
}
