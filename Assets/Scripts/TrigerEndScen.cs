using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigerEndScen : MonoBehaviour
{

    public GameObject Victory;
    private void OnTriggerEnter(Collider collider)
    {
        Victory.SetActive(true);
    }

    public void NextScen()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
