using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private int prefabId = 1;
    [SerializeField] private float rotationSpeed;
    private int _level  = 0;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch (_level)
        {
            case 0:
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                break;
            
            default:
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                break;
        }

        // test Code
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Level Up");
            LevelUp();
        }
    }

    public void LevelUp()
    {
        // Todo: 레벨은 DataManager.Bullets.Count보다 적어야 한다.
        // Todo: 생성 개수 count를 Bullet 데이터에 포함시킬지 정해야 함.
        _level = Mathf.Min(++_level, DataManager.Bullets.Count - 1);
        Init();
    }

    public void Init()
    {
        switch (_level)
        {
            case 0:
                rotationSpeed = 150;
                break;
            
            default:
                break;
        }
        
        Spawn();
    }
    
    private void Spawn()
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet;

            // 생성된 Bullet이 있을 경우
            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }

            else
            {
                bullet = GameManager.Instance.poolManager.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;
            
            bullet.GetComponent<BulletController>().Init(DataManager.Bullets[_level]);
            
            // 배치
            var rotVac = Vector3.forward * 360 * i / count;
            bullet.Rotate(rotVac);
            bullet.Translate(bullet.up * 1.5f, Space.World);
        }
    }
}
