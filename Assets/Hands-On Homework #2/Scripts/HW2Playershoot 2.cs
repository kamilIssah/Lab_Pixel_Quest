using UnityEngine;

public class HW2PlayerShootAlt : MonoBehaviour
{
    public GameObject preFab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private const float Timer = 1.0f;
    private float _currentTime = 1.0f;
    private bool _canShoot = true;

    public void Update()
    {
        TimerMethod();
        Shoot();
    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0)
            {
                _canShoot = true;
                _currentTime = Timer;
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _canShoot) // Changed to Mouse1 (Right Click)
        {
            GameObject bullet = Instantiate(preFab, bulletSpawn.position, Quaternion.identity);
            bullet.transform.SetParent(bulletTrash);
            _canShoot = false;
        }
    }
}
