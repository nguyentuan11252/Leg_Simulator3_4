using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayerController : Singleton<SoccerPlayerController>
{
    [SerializeField] private Collider foot;
    [SerializeField] private Rigidbody footBody;
    [SerializeField] private float force = 10.0f;
    public static bool isStop = false;
    public static bool isPlay = false;
    public float v;
    Vector3 _startVc;
    Vector3 _endVc;
    private enum State
    {
        Idle,
        Captured,
    }
    private void Start()
    {
        isPlay = true;
    }
    private State _state = State.Idle;
    private Plane _plane = new Plane(-Vector3.forward, Vector3.zero);

    void Update()
    {
        if (isStop == false)
        {
            if (isPlay == false)
            {
                switch (_state)
                {
                    case State.Idle:
                        {
                            if (!Input.GetMouseButtonDown(0)) return;
                            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            _startVc = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                            if (foot.Raycast(ray, out var hit, 1000))
                            {
                                Debug.Log("point");
                                _state = State.Captured;
                            }
                        }
                        break;
                    case State.Captured:
                        {
                            if (Input.GetMouseButtonUp(0))
                            {
                                _state = State.Idle;
                                return;

                            }
                            _endVc = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            if (!_plane.Raycast(ray, out var enter)) return;
                            var pos = ray.GetPoint(enter);
                            if (pos.x > 6f)
                            {
                                pos.x = 6f;
                            }
                            if (pos.x < -2)
                            {
                                pos.x = -2;
                            }
                            if (pos.y > 2f)
                            {
                                pos.y = 2f;
                            }
                            if (pos.y < -2f)
                            {
                                pos.y = -2f;
                            }
                            var v = pos - footBody.position;
                            footBody.AddForce(v * force);
                            LegForce();
                        }
                        break;
                }
            }
        }
    }
    public void LegForce()
    {
        v = (_endVc.x- _startVc.x) * 0.5f;
        Debug.Log("v: " + v);
    }
}
