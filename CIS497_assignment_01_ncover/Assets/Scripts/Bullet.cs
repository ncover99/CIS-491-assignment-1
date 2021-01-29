using UnityEngine;

namespace Assets.Scripts.Assignment_01
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private float speed = 10f;
        private Rigidbody2D rb2d = null;
        private Vector3 targetDir = new Vector3(0,0,0);

        private Bullet(float lifeTime, float speed, Vector3 targetDir)
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
    }
}
