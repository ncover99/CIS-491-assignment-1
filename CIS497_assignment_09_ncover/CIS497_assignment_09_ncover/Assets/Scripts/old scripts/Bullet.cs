/*
 * Nathan Cover
 * Bullet.cs
 * Assignment_09
 * Class to handle the functionality of the projectiles for the firearms, the class contains a constructor
 * to specify the spawn location and direction the bullet should be facing when created, as well as setting death time.
 * The bullet destroys itself after a set time to not bloat the hierarchy.
 */

using UnityEngine;

namespace Assets.Scripts.Assignment_09
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private float speed = 10f;
        private Rigidbody2D rb2d = null;
        private Vector3 targetDir = new Vector3(0,0,0);

        private Bullet(float lifeTime, float speed, Vector3 targetDir, string affectedTag)
        {
            lifeTime = this.lifeTime;
            speed = this.speed;
            targetDir = this.targetDir;
        }

        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            Destroy(this.gameObject, lifeTime);

        }

        // Update is called once per frame
        void Update()
        {
            Debug.DrawRay(transform.position, transform.up * 1, Color.green);
        }

        void FixedUpdate()
        {
            rb2d.MovePosition(rb2d.position +
                              (new Vector2(transform.up.x, transform.up.y) * speed) * Time.fixedDeltaTime);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(this.gameObject);
        }
    }
}
