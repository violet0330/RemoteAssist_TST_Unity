using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WholeModelCtrl : MonoBehaviour
{

    public GameObject Model;
    public GameObject ModelSplit;
    public float spinSpeed = 0.3f;

    Quaternion initialRotation;
    private int rotate;

    public void Detail()
    {
        SceneManager.LoadScene("WholeModelDetailScene");
    }

    public void Restart()
    {
        Model.transform.localRotation= initialRotation;
    }

    public void Split()
    {
        Restart();
        GameObject.Find("wholeProject").GetComponentInChildren<Split>().SplitObject();
    }

    public void Merge()
    {
        Restart();
        GameObject.Find("wholeProject").GetComponentInChildren<Split>().MergeObject();
    }

    internal void StopTurning()
    {
        Quaternion currentRotation = Model.transform.localRotation;
        Model.transform.localRotation = currentRotation;
    }

    internal void Turning(int direct)
    {

        if (direct == 0)
            Model.transform.Rotate(Vector3.up * spinSpeed, Space.World);
        else
            Model.transform.Rotate(Vector3.down * spinSpeed, Space.World);
    }

    public void TurningClick()
    {
        Merge();
        if (rotate == 0)
        {
            Model.transform.Rotate(Vector3.up * spinSpeed, Space.Self);
            rotate++;
        }
        else if (rotate == 1)
        {
            Model.transform.Rotate(Vector3.down * spinSpeed, Space.Self);
            rotate++;
        }
        else
        {
            Quaternion currentRotation = Model.transform.localRotation;
            Model.transform.localRotation = currentRotation;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        initialRotation = Model.transform.localRotation;
        Debug.Log("rotation"+initialRotation.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
