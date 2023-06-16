using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public SceneTransitor Transitor;
    public GameObject respawn_p;

    void OnTriggerStay2D(Collider2D collision)
    {
        collision.transform.position = respawn_p.transform.position;
        Transitor.Fade();
    }
}
