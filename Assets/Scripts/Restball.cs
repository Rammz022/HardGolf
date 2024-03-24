using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restball : MonoBehaviour
{
    public Vector3 endPositionBall;
    public Transform Player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Îé óëåòåëè ñ ïîëÿ!");
    }
}
