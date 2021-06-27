using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cow : MonoBehaviour
{

    public static cow instance;
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float gravity = -9.81f;
    public bool hasCowvid = false;
    private bool isDead = false;
    public bool isVaccinated = false;
    public Camera camera;
    public Collider collider;
    private bool hasDied = false;
    private enum direction
    {
        forward, back
    }
    [SerializeField] direction currentDirection;
    bool changeDirection = false;
    bool isChanging = false;
    private Vector3 velocity;
    [SerializeField] float timeToDeath = 8f;
    private void Awake()
    {
        instance = this;
        int currentSeed = Random.Range(1, 999999999);
        Random.InitState(currentSeed);
        currentDirection = (direction)Random.Range(0, 4);
    }

    public void move()
    {
        if (!isChanging)
        {
            if (changeDirection)
            {
                chooseNewDirection(currentDirection);
                changeDirection = Random.Range(0, 101) < 40 ? true : false;
            }
            else
            {
                StartCoroutine(changeChances());
            }
        }
        Vector3 move = Vector3.forward;
        switch (currentDirection)
        {
            case direction.forward:
                move = Vector3.forward;
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case direction.back:
                move = Vector3.forward * -1;
                transform.rotation = Quaternion.Euler(0, -90, 0);
                break;
        }
        controller.Move(move * speed);
    }

    void chooseNewDirection(direction current)
    {
        direction dir = (direction)Random.Range(0, 4);

        if (dir != current)
        {
            currentDirection = dir;
        }
        else
        {
            chooseNewDirection(current);
        }
    }

    IEnumerator changeChances()
    {
        isChanging = true;
        yield return new WaitForSeconds(5f);
        if (!changeDirection)
        {
            changeDirection = Random.Range(0, 101) < 40 ? true : false;
            isChanging = false;
        }
    }

    void Update()
    {
        if (!isDead)
        {
            move();
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            clicks();
        }
        else
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "border")
        {
            chooseNewDirection(currentDirection);
        }
        if (hit.gameObject.tag == "cow 1" || hit.gameObject.tag == "cow 2" || hit.gameObject.tag == "cow 3")
        {
            if (hasCowvid && (!hit.gameObject.transform.GetComponent<cow>().isVaccinated || isVaccinated))
            {
                hit.gameObject.transform.GetChild(hit.gameObject.transform.childCount - 1).gameObject.SetActive(true);
                hit.gameObject.transform.GetComponent<cow>().hasCowvid = true;
                StartCoroutine(death());
            }
        }
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(timeToDeath);
        if (!isVaccinated && !hasDied)
        {
            //the cow dies :(
            isDead = true;
            gameOver.instance.addDeadCow(gameObject, tag);
            Debug.Log("has died " + gameObject);
            hasDied = true;
        }
    }

    void clicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, 100.0f))
            {
                if (!isVaccinated)
                {
                    if (tag == "cow 1")
                    {
                        if (vaccine.instance.richShots > 0)
                        {
                            vaccine.instance.rich();
                            isVaccinated = true;
                            gameOver.instance.addVaccinatedCow(gameObject, tag);
                            transform.GetChild(0).gameObject.SetActive(true);
                            transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
                            Debug.Log("vaxxed");
                            hasCowvid = false;
                        }
                    }
                    else if (tag == "cow 2")
                    {
                        if (vaccine.instance.middleShots > 0)
                        {
                            vaccine.instance.middle();
                            isVaccinated = true;
                            gameOver.instance.addVaccinatedCow(gameObject, tag);
                            transform.GetChild(0).gameObject.SetActive(true);
                            transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
                            Debug.Log("vaxxed");
                            hasCowvid = false;
                        }

                    }
                    else if (tag == "cow 3")
                    {
                        if (vaccine.instance.poorShots > 0)
                        {
                            vaccine.instance.poor();
                            isVaccinated = true;
                            gameOver.instance.addVaccinatedCow(gameObject, tag);
                            transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
                            transform.GetChild(0).gameObject.SetActive(true);
                            Debug.Log("vaxxed");
                            hasCowvid = false;
                        }
                    }
                }
            }
        }
    }

}


