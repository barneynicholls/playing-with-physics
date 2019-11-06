using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    void Start()
    {
        Instantiate(Resources.Load("Cube"), gameObject.transform);
    }
}
