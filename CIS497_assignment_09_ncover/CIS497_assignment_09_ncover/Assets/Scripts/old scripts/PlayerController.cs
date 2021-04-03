/*
 * Nathan Cover
 * PlayerController.cs
 * Assignment_09
 * Class to handle player controls
 */

using UnityEngine;

namespace Assets.Scripts.Assignment_09
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private float _xMove = 0f;
        private float _yMove = 0f;

        private Rigidbody2D _rb2d;
        
        // Start is called before the first frame update
        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            if(Time.timeScale == 0)return;
            
            Movement();
            
        }

        private void Movement()
        {
            _xMove = Input.GetAxis("Horizontal");
            _yMove = Input.GetAxis("Vertical");
            
            // rotate to face cursor
            var screenPos = Camera.main.WorldToScreenPoint(transform.position); // player position in camera space
            var mouseDir = Input.mousePosition - screenPos;
            var angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + -90, Vector3.forward);
        }

        private void FixedUpdate()
        {
            // movement
            _rb2d.MovePosition(_rb2d.position + (new Vector2(_xMove, _yMove) * speed) * Time.fixedDeltaTime);
        }
    }   
    
}
