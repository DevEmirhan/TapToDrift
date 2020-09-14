using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool isGameOn = false;
    public float movementSpeed = 1f;
    private float baseSpeed;
    public bool isRight = true;
    private LineRenderer line;
    public GameObject activePin;
    private bool isTurning = false;
    public GameObject levelUpPanel;
    public TextMeshProUGUI score;
    public bool earnPoint = false;
    private int playerScore;
    public GameObject carModel;
    private int level;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        baseSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOn && !isTurning )
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }

       if(activePin!= null && Input.GetMouseButton(0) && isGameOn)
        {
            isTurning = true;
            line.enabled = true;
            if (isRight)
            {
            transform.RotateAround(activePin.transform.position, new Vector3(0f, 1f, 0f), 90f * Time.deltaTime);
                carModel.transform.DOLocalRotate(new Vector3(0f, 15f, 0f), 1f).SetId("Turn");
            }
            else
            {
            transform.RotateAround(activePin.transform.position, new Vector3(0f, 1f, 0f), -90f * Time.deltaTime);
                carModel.transform.DOLocalRotate(new Vector3(0f, -15f, 0f), 1f).SetId("Turn");
            }


            line.SetPosition(0, transform.position);
            line.SetPosition(1, activePin.transform.position);
           
        }
        else
        {
            isTurning = false;
            line.enabled = false;
            //DOTween.Kill("Turn");
            carModel.transform.DOLocalRotate(Vector3.zero, .3f).SetEase(Ease.OutBounce);
        }
            
       

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.Instance.gameState = GameState.Lose;
        } else if (other.gameObject.tag == "LevelUp")
        {
            GetOnTheLine();
            StartCoroutine("OpenLevelUp");
            movementSpeed = 60;
        } else if(other.gameObject.tag == "Finish")
        {
            level++;
            movementSpeed = baseSpeed;
            for (int i = 0; i < level; i++)
            {
                movementSpeed += 5;
            }
            
        } else if(other.gameObject.tag == "GetLine")
        {
            GetOnTheLine();
        }
    }
   
    public void AddScore()
    {
        if (earnPoint)
        {
            playerScore++;
            score.text = playerScore.ToString();
        }
        earnPoint = false;
    }

    IEnumerator OpenLevelUp()
    {
        levelUpPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        levelUpPanel.SetActive(false);
    }

    public void GetOnTheLine()
    {
        if(Mathf.Abs(transform.localEulerAngles.y) <= 25)
        {
            transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.OutBounce);
        } else if(transform.localEulerAngles.y >= 65 && transform.localEulerAngles.y <=115)
        {
            transform.DOLocalRotate(new Vector3(0f,90f,0f), 0.2f).SetEase(Ease.OutBounce);
        } else if(transform.localEulerAngles.y <= -65 && transform.localEulerAngles.y >= -115)
        {
            transform.DOLocalRotate(new Vector3(0f, -90f, 0f), 0.2f).SetEase(Ease.OutBounce);
        }
    }

}
