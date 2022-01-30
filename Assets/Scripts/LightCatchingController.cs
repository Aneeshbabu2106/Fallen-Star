using UnityEngine;
using System.Collections;

public class LightCatchingController : MonoBehaviour

{
    public bool isCatchable;
    public float speed;
    public Transform target;
    public Transform initial;
    public GameObject lightPrefab;
    float time;

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
        Debug.Log(gameObject.name);
    }
    public void startLightMove(Vector3 _endPos)
    {
        GameObject light = Instantiate(lightPrefab,transform);
        StartCoroutine (MoveLight (light.transform,transform.position,_endPos));
        //Debug.Log("start");

    }
    IEnumerator MoveLight (Transform obj,Vector3 startPos,Vector3 endPos)
    {
        time=0;
        // Debug.Log("inside ienum");
        while(time<1)
        {
          time += speed * Time.deltaTime;
          obj.position = Vector3.Lerp(startPos,endPos,time);
          //Debug.Log("start"+ startPos + "end" + endPos);   
          yield return new WaitForEndOfFrame();
        }
        yield return null;

    }

}
