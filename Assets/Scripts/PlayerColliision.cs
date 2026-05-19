using UnityEngine;

public class PlayerColliision : MonoBehaviour
{
    [SerializeField] Animator animator;
    GameManagerSc gm;

    private void Start()
    {
        gm = FindAnyObjectByType<GameManagerSc>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Coin"))
        {
            gm.ChangeCoin(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Fence"))
        {
            animator.SetTrigger("Hit");
        }
        else if (collision.gameObject.CompareTag("Obtacle"))   
        {
            gm.ChangeLifes(-1);
            Destroy(collision.gameObject);
        } 
    }
}
 