using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private float bulletSpeed = 12f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float aimDistance = 0.5f;

    [Header("References")]
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private Camera mainCamera;

    private float fireTimer;

    private void Awake()
    {
        if(mainCamera == null)
            mainCamera = Camera.main;
    }
    
    private void Update()
    {
        AimAtMouse();

        fireTimer -= Time.deltaTime;

        if(fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    private void AimAtMouse()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = -mainCamera.transform.position.z + transform.position.z;

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector2 direction = (Vector2)(mouseWorldPosition - transform.position);

        if (direction.sqrMagnitude < 0.001f)
            return;

        direction.Normalize();

        // Faz o firepoint orbitar o player
        firePoint.localPosition = direction * aimDistance;

        // Rotaciona o sprite do  firepoint para mirar no mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Shoot()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = -mainCamera.transform.position.z + transform.position.z;

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector2 direction = (Vector2)(mouseWorldPosition - firePoint.position);

        if(direction.sqrMagnitude < 0.001f)
            return;

        direction.Normalize();

        Bullet bullet = bulletPool.GetBullet();

        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.gameObject.SetActive(true);

        bullet.Initialize(direction, bulletSpeed, bulletPool);
    }

}
