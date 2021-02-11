/*
 * Nathan Cover
 * Bullet.cs
 * Assignment_02
 * Class to handle the functionality of the projectiles for the firearms, the class contains a constructor
 * to specify the spawn location and direction the bullet should be facing when created, as well as setting death time.
 * The bullet destroys itself after a set time to not bloat the hierarchy.
 */

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public class Bomb : MonoBehaviour, IObserver
    {
        [SerializeField] private ISubject _detonator = null;
        [SerializeField] private float _armTime = 2f;
        [SerializeField] private Color _dudColor = Color.red;
        private SpriteRenderer _sr2d;
        [SerializeField] private GameObject _onDeath = null;
        [SerializeField] private AnimationCurve _trajectory = null;
        [SerializeField] private float _startSpeed = 6f;
        private Rigidbody2D _rb2d = null;
        private Vector3 _targetDir = new Vector3(0,0,0);
        private float _curveDeltaTime = 0.0f;

        public void SetDetonator(ISubject detonator)
        {
            _detonator = detonator;
        }

        // Start is called before the first frame update
        IEnumerator Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _sr2d = GetComponent<SpriteRenderer>();
            _sr2d.color = _dudColor;
            
            yield return new WaitForSeconds(_armTime);
            _sr2d.color = Color.white;
            _detonator.RegisterObserver(this);
            //add to event list, aka the bomb can be triggered now
        }

        // Update is called once per frame
        void Update()
        {
            _curveDeltaTime+= Time.deltaTime;
            Debug.DrawRay(transform.position, transform.up * 1, Color.green);
        }

        void FixedUpdate()
        {
            _rb2d.MovePosition(_rb2d.position +
                              (new Vector2(transform.up.x, transform.up.y) *
                               _startSpeed * _trajectory.Evaluate(_curveDeltaTime)) *
                              Time.fixedDeltaTime);
        }

        public void ReceiveSignal()
        {
            Instantiate(_onDeath, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
