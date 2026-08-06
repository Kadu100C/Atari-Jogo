using UnityEngine;

public class destroyTimed : MonoBehaviour
{



    void Start()
    {
        Invoke(nameof(AutoDestroy), 1f);
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }
}