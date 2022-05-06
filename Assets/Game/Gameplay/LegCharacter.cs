using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LegCharacter : MonoBehaviour
{
    [SerializeField]
    private bool _touched;
    [SerializeField]
    private Camera mainCamera;
    public bool isPedal = false;
    bool isMoveLeg = false;
    public Transform _posPedal;
    public static LegCharacter Ins;
    public bool isMouseUp = false;
    public Transform posStart;
    public GameObject pedalObj;
    public GameObject tagetPlayer;
    public GameObject resetPedal;
    public GameObject footCharacter;
    Vector3 _startVc;
    Vector3 _endVc;
    float v;
    [SerializeField]
    private ParticleSystem particleSmoke;
    [SerializeField]
    private ParticleSystem particleSmoke2;
    [SerializeField]
    private ParticleSystem particleWin;
    public static bool isDealth = false;
    public GameObject btnTapDrag;
    [SerializeField]
    private Animator animWin;
    [SerializeField]
    private Image imgPower;
    [SerializeField]
    private GameObject objCamera;
    bool checkWin = false;
    private void Awake()
    {
        Ins = this;
    }
    void Start()
    {
        btnTapDrag.SetActive(false);
        _startVc = Vector3.zero;
        _endVc = Vector3.zero;
        particleSmoke.Stop();
        particleSmoke2.Stop();
        particleWin.Stop();
        imgPower.fillAmount = 0;
        objCamera.transform.position = objCamera.transform.position + new Vector3(0.15f, 0.6f, -3.08f);
        StartCoroutine(CameraMove());
        checkWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (SoccerPlayerController.isMoveLeg == true)
        {
            Debug.Log("run ");
        }*/
        if (SoccerPlayerController.isStop == true && checkWin == false)
        {
            footCharacter.transform.position = _posPedal.position;
            
            DragFootAndPedal();
        }

        if (imgPower.fillAmount < targetPow)
        {
            imgPower.fillAmount += speed * Time.deltaTime;
        }
        if (imgPower.fillAmount > targetPow)
        {
            imgPower.fillAmount -= speed * Time.deltaTime;
        }

    }

    void DragFootAndPedal()
    {
        Vector3 posMouse = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(posMouse);

        if (Input.GetMouseButtonDown(0))
        {
            _startVc = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            v = (_startVc.y - _endVc.y) * 0.5f;
            IncrementProgress(v);

            btnTapDrag.SetActive(false);
            _touched = false;
            if (v != 0)
            {
                float time2 = 0;
                if (Time.time - time2 >= 0.9f)
                {
                    time2 = Time.time;
                    FootCharacterMotor.Ins.isMoveLeg = true;
                    pedalObj.transform.DORotate(new Vector3(0, 0, transform.rotation.z + 70f), 1 - v);
                    StartCoroutine(ResetPedal());
                    particleSmoke.Play();
                }
                if (v > 0.45f)
                {
                    //Run
                    //phut phao
                    animWin.SetTrigger("Win");
                    isDealth = true;
                    checkWin = true;
                    SoccerPlayerController.isStop = false;
                    particleSmoke2.Play();
                    StartCoroutine(ParticleWin());
                }
                else if (v < 0.45f)
                {
                    particleSmoke2.Stop();
                    //rung
                }
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            _endVc = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            RemovePow(v);
            
        }
        if (!_touched) return;

    }
    IEnumerator CameraMove()
    {
        yield return new WaitForSeconds(1);
        objCamera.transform.DOMove(new Vector3(2.96f, 1.08f, -2.9f), 2f);
    }
    IEnumerator ResetPedal()
    {
        yield return new WaitForSeconds((_startVc.y - _endVc.y) * 0.5f);
        pedalObj.transform.DORotate(new Vector3(0, 0, transform.rotation.z), 1 - v);

        StartCoroutine(ResetPedal1());

    }
    IEnumerator ResetPedal1()
    {
        yield return new WaitForSeconds(1 - v);
        //FootCharacterMotor.Ins.RbCharacterFail();

    }
    IEnumerator ParticleWin()
    {
        yield return new WaitForSeconds(2);
        particleWin.Play();
    }
    float targetPow = 0;
    float speed = 1f;
    public void IncrementProgress(float newProgress)
    {
        targetPow = imgPower.fillAmount + newProgress;
    }
    public void RemovePow(float newProgress)
    {
        targetPow = imgPower.fillAmount - newProgress;
        
    }
}
