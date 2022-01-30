using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LightCatchingController lightCatchingControllerObj;
    [SerializeField] private float speedForce = 50f;
    private float horizontalInput;
    private bool isCatchable = false;
    private bool catchLight = false;
    Vector3 scale;
    Vector2 position;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        catchLight = Input.GetKey(KeyCode.E);

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
        position =transform.position;
        position.x +=  horizontalInput * speedForce *Time.deltaTime;
        transform.position=position;
    }
    private void FixedUpdate() {

        //light catching
        isCatchable=lightCatchingControllerObj.isCatchable;
        if(isCatchable && catchLight){
            playerLightCatch();
        }
    }

    void playerLightCatch()
    {
        lightCatchingControllerObj.LightCatch();

    }


}
