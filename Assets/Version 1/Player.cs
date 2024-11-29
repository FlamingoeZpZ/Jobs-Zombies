using System;
using UnityEngine;
namespace Version_1
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private Transform head;

        [SerializeField] private float rotationSpeed;
        [SerializeField] private float moveSpeed;
        
        private Rigidbody _rb;
        private Vector3 _moveDirection;
        private Vector2 _lookDirection;

        //A tad bit lazy.
        public static Vector3 PlayerLocation { get; private set;}

        private void Awake()
        {
            Controls.Init(this);
            _rb = GetComponent<Rigidbody>();
            
            //lazy
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void FixedUpdate()
        {
            float dt = Time.deltaTime;
            HandleMoving();
            HandleLooking(dt);
        }

        private void HandleMoving()
        {
            _rb.AddForce(transform.rotation * _moveDirection * (moveSpeed));
            PlayerLocation = transform.position;
        }

        private void HandleLooking(float time)
        {
            float t = rotationSpeed * time;
            transform.Rotate(Vector3.up, _lookDirection.x * t);
            head.Rotate(Vector3.right, _lookDirection.y * t);
        }

        public void Attack(bool readValueAsButton)
        {
            weapon.SetFiringState(readValueAsButton);
        }

        public void Look(Vector2 readValue)
        {
            _lookDirection = readValue;
        }

        public void Move(Vector2 readValue)
        {
            _moveDirection = new Vector3(readValue.x, 0, readValue.y);
        }
    }
}
