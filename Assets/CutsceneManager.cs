using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;

    public float wait1;
    public float wait2;
    public float wait3;

    public GameObject door;
    public GameObject target;
    public float rotationSpeed;
    private bool opening;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cutscene());
    }

    void Update()
    {
        if (opening)
        {
            door.transform.RotateAround(target.transform.position, Vector3.forward,
            rotationSpeed * Time.deltaTime);
            // transform.Translate(Vector3.forward *rotationSpeed * Time.deltaTime);
        }
    }

    private IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(wait1);
        opening = true;
        Debug.Log("open");

        yield return new WaitForSeconds(wait2);
        opening = false;
        camera1.Priority = 1;

        yield return new WaitForSeconds(wait3);
        ToFirstLevel();

    }

    public void ToFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
