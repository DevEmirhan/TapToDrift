using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool isGameOn = false;
    public float movementSpeed = 1f;
    public bool isRight = true;
    private LineRenderer line;
    public GameObject activePin;
    private bool isTurning = false;
    public GameObject levelUpPanel;
    public TextMeshProUGUI score;
    public bool earnPoint = false;
    private int playerScore;
    void Start()
    {
        line = GetComponent<LineRenderer>();
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
            }
            else
            {
            transform.RotateAround(activePin.transform.position, new Vector3(0f, 1f, 0f), -90f * Time.deltaTime);
            }


            line.SetPosition(0, transform.position);
            line.SetPosition(1, activePin.transform.position);
        }
        else
        {
            isTurning = false;
            line.enabled = false;
        }
            
       

    }

    private void OnTriggerEnter(Collider other)
    {
        float curSpeed = movementSpeed;
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.Instance.gameState = GameState.Lose;
        } else if (other.gameObject.tag == "LevelUp")
        {
            StartCoroutine("OpenLevelUp");
            movementSpeed = 60;
        } else if(other.gameObject.tag == "Finish")
        {
            movementSpeed = curSpeed + 5f;
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


}
