using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int initialSize = 20;
    private Queue<Bullet> avaliableBullets = new Queue<Bullet>();

    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            CreateBullet();
        }
    }

    private Bullet CreateBullet()
    {
        GameObject obj = Instantiate(bulletPrefab);
        Bullet bullet = obj.GetComponent<Bullet>();

        obj.SetActive(false);
        avaliableBullets.Enqueue(bullet);

        return bullet;
    }

    public Bullet GetBullet()
    {
        Bullet bullet;

        if(avaliableBullets.Count > 0)
        {
            bullet = avaliableBullets.Dequeue();
        }
        else
        {
            bullet = CreateBullet();
            avaliableBullets.Dequeue();
        }

        return bullet;
    }

    public void ReturnBullet (Bullet bullet) 
    {
        bullet.gameObject.SetActive(false);
        avaliableBullets.Enqueue(bullet);
    }
}
