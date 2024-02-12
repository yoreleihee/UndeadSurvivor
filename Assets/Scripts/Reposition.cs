using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Reposition : MonoBehaviour
{
    [SerializeField] private float mapSize = 40;
    [SerializeField] private Collider2D coll;
    [SerializeField] private float enemyRepositionRange = 3f;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

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

        Vector3 playerDir = GameManager.Instance.player.inputVec;
        float playerDirX = playerDir.x < 0 ? -1 : 1;
        float playerDirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * playerDirX * mapSize);
                }
                
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * playerDirY * mapSize);
                }
                break;
            
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * (mapSize / 2) +
                                        new Vector3(Random.Range(enemyRepositionRange, -enemyRepositionRange), Random.Range(enemyRepositionRange, -enemyRepositionRange)));
                }

                break;
        }
    }
}
