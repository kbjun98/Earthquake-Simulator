using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FreeCamera : MonoBehaviour
    {
        public float _moveSpeed = 5f;
        public float _rotationSpeed = 5f;
        public bool _wheelAcceleration = true;

        public KeyCode _moveForward = KeyCode.W;
        public KeyCode _moveBackward = KeyCode.S;
        public KeyCode _moveLeft = KeyCode.A;
        public KeyCode _moveRight = KeyCode.D;
        public KeyCode _moveUp = KeyCode.E;
        public KeyCode _moveDown = KeyCode.Q;

        public KeyCode _run = KeyCode.LeftShift;
        public KeyCode _cursorLock = KeyCode.LeftAlt;

        public bool _isActivated = true;
        public bool _isCursorVisible = true;

        private Vector3 _moveDir;
        private Vector3 _worldMoveDir;
        private Vector2 _rotation;

        private Transform _rig;
        private float _deltaTime;

        private void Awake()
        {
            InitRig();
            InitTransform();
        }

        private void Update()
        {
            _deltaTime = Time.deltaTime;
            GetInputs();
            Rotate();
            Move();
        }

        private void InitRig()
        {
            _rig = new GameObject("Free Look Camera Rig").transform;
            _rig.position = transform.position;
            _rig.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);

            _rig.SetSiblingIndex(transform.GetSiblingIndex());
        }

        private void InitTransform()
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
            transform.SetParent(_rig);
        }

        private void GetInputs()
        {
            _moveDir = new Vector3(0, 0, 0);

            if (Input.GetKey(_moveForward)) _moveDir.z += 1f;
            if (Input.GetKey(_moveBackward)) _moveDir.z -= 1f;
            if (Input.GetKey(_moveRight)) _moveDir.x += 1f;
            if (Input.GetKey(_moveLeft)) _moveDir.x -= 1f;
            if (Input.GetKey(_moveUp)) _moveDir.y += 1f;
            if (Input.GetKey(_moveDown)) _moveDir.y -= 1f;

            if (Input.GetKey(_run))
            {
                _moveDir *= 2f;
            }

            if (_wheelAcceleration)
            {
                float wheel = Input.GetAxisRaw("Mouse ScrollWheel");
                if (wheel != 0)
                {
                    _moveSpeed += wheel * 10f;
                    if (_moveSpeed < 1f)
                        _moveSpeed = 1f;
                }
            }

            float mX = Input.GetAxisRaw("Mouse X");
            float mY = -Input.GetAxisRaw("Mouse Y");

            _rotation = new Vector2(mY, mX);
        }

        private void CursorLock()
        {
            if (Input.GetKeyDown(_cursorLock))
            {
                _isCursorVisible = !_isCursorVisible;
                Cursor.lockState = !_isCursorVisible ? CursorLockMode.Locked : CursorLockMode.None;
                Cursor.visible = _isCursorVisible;
            }
        }

        private void Rotate()
        {
            if (_rotation == Vector2.zero) return;

            float rotSpeed = _rotationSpeed * _deltaTime * 50f;

            Vector3 trnEuler = transform.localEulerAngles;
            Vector3 rigEuler = _rig.localEulerAngles;

            float nextX = trnEuler.x + _rotation.x * rotSpeed;

            if (nextX > 180f) nextX -= 360f;
            nextX = Mathf.Clamp(nextX, -89.9f, 89.9f);

            transform.localEulerAngles = new Vector3(nextX, trnEuler.y, trnEuler.z);

            float nextY = rigEuler.y + _rotation.y * rotSpeed;
            _rig.localEulerAngles = new Vector3(rigEuler.x, nextY, rigEuler.z);
        }

        private void Move()
        {
            if (_moveDir == Vector3.zero) return;

            _worldMoveDir = transform.TransformDirection(_moveDir);
            _rig.Translate(_worldMoveDir * _moveSpeed * Time.deltaTime, Space.World);
        }
    }
