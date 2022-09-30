using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<DieHandler>(out DieHandler dieHandler))
        {
            dieHandler.Die();
        }
    }
}
