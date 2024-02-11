using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 PlayerDir = GameManager.Instance.player.inputVec;
        float playerDirX = PlayerDir.x < 0 ? -1 : 1;
        float playerDirY = PlayerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * playerDirX * 40);
                }
                
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * playerDirY * 40);
                }
                break;
        }
    }
}
