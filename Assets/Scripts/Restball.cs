using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restball : MonoBehaviour
{
    public Vector3 endPositionBall;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(endPositionBall.ToString());
        Debug.Log("Oй mы далего за полем!");
    }
}
