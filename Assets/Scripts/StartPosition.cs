using UnityEngine;

public class StartPosition : MonoBehaviour
{
    [SerializeField] Transform _target;

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        _target.position = transform.position;
    }

  
}
