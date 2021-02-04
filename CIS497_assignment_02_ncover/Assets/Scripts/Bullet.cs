/*
 * Nathan Cover
 * Bullet.cs
 * Assignment_02
 * Class to handle the functionality of the projectiles for the firearms, the class contains a constructor
 * to specify the spawn location and direction the bullet should be facing when created, as well as setting death time.
 * The bullet destroys itself after a set time to not bloat the hierarchy.
 */

using TMPro;
using UnityEngine;

namespace Assets.Scripts.Assignment_02
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private float speed = 10f;
        private Rigidbody2D rb2d = null;
        private Vector3 targetDir = new Vector3(0,0,0);
        public string affectedTag = "Enemy";

        private Bullet(float lifeTime, float speed, Vector3 targetDir, string affectedTag)
        {
            lifeTime = this.lifeTime;
            speed = this.speed;
            targetDir = this.targetDir;
            affectedTag = this.affectedTag;
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
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var temp = other.GetComponent<CanTakeDamage>();
            if (temp != null && other.gameObject.tag == affectedTag)
            {
                temp.TakeDamage();
                Destroy(this.gameObject);
            }
        }
    }
}
