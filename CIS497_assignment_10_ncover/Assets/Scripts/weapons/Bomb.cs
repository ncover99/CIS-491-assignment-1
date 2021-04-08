/*
 * Nathan Cover
 * Bomb.cs
 * Assignment_03
 * Class to handle the functionality of the projectiles for the bomb launcher, can be remote detonated after an arm
 * time, each instance of a bomb recieves signals from the bomb launcher that created it
 * and can be detonated by said launcher
 *
 * on activate it calls the object poolers destroy method and also instantiates the explosion through the pooler
 */

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_10
{
    public class Bomb : MonoBehaviour, IObserver
    {
        private ObjectPooler objectPooler;
        [SerializeField] private ISubject _detonator = null;
        [SerializeField] private float _armTime = 2f;
        [SerializeField] private Color _dudColor = Color.red;
        private SpriteRenderer _sr2d;
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
        void Awake()
        {
            objectPooler = ObjectPooler.instance;
        }

        void OnEnable()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _sr2d = GetComponent<SpriteRenderer>();
            _sr2d.color = _dudColor;

            StartCoroutine(Arm());
        }

        IEnumerator Arm()
        {
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
            objectPooler.Instantiate("explosion", transform.position, transform.rotation);
            //Instantiate(_onDeath, transform.position, transform.rotation);
            objectPooler.Destroy("bomb", this.gameObject);
        }
    }
}
