
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]private GameObject[] enemies;
    private Vector3[] initilPosition;

    private void Awake()
    {
        initilPosition = new Vector3[enemies.Length];
        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                initilPosition[i] = enemies[i].transform.position;
            }
        }
    }

    public void ActivateRoom(bool _status)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(_status);
                enemies[i].transform.position = initilPosition[i];
            }
        }
    }
}
