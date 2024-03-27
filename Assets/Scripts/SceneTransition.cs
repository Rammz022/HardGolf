using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int _index;

    public void Transition(int index)
    {
        SceneManager.LoadScene(index);
    }    

}
