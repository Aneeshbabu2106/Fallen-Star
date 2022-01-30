using UnityEngine;

public class LightCatchingController : MonoBehaviour

{
    public bool isCatchable;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() !=  null)
        {
            isCatchable = true;
            //Debug.Log("ready");
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
         if(other.gameObject.GetComponent<PlayerController>() !=  null)
        {
            isCatchable = false;
            //Debug.Log("Not ready");
        }
    }

    public void LightCatch()
    {
        Destroy(gameObject);
    }
}
