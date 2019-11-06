using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public int XCount = 10;

    public int YCount = 10;

    public int ZCount = 10;

    public float Spacing = 1.2f;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {

        for (int y = 0; y < YCount; y++)
        {
            for (int x = 0; x < XCount; x++)
            {
              for (int z = 0; z < ZCount; z++)
              {
                var pos = gameObject.transform.position;

                pos.x += Spacing * x;
                pos.y += Spacing * y;
                pos.z += Spacing * z;

                Debug.Log(string.Format("x:{0}, y:{1}, z:{2}", pos.x, pos.y, pos.z));

                Instantiate(Resources.Load("Cube"), pos, Quaternion.identity);
              }
            }
        }
    }
}
