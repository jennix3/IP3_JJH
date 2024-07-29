using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA4 : MonoBehaviour
{
    string currentState;
    string nextState;

    int hp = 4;

    [SerializeField]
    float recoverTime;

    [SerializeField]
    Material cubeMaterial;

    private void Start()
    {
        currentState = "Normal";
        nextState = "Normal";
        UpdateColor();
        SwitchState();
    }

    private void Update()
    {
        if (currentState != nextState)
        {
            currentState = nextState;
            UpdateColor();
        }
    }

    void SwitchState()
    {
        StartCoroutine(currentState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            --hp;
            UpdateColor();
            if (hp < 1)
            {
                Destroy(gameObject);
            }
        }
    }

    void UpdateColor()
    {
        if (hp == 4)
        {
            cubeMaterial.color = Color.green;
        }
        else if (hp == 3)
        {
            cubeMaterial.color = Color.yellow;
        }
        else if (hp == 2)
        {
            cubeMaterial.color = new Color(1.0f, 0.65f, 0.0f); // orange
        }
        else if (hp == 1)
        {
            cubeMaterial.color = Color.red;
        }
    }

    IEnumerator Normal()
    {
        while (hp > 1)
        {
            yield return new WaitForEndOfFrame();
        }
        nextState = "Critical";
        yield return new WaitForEndOfFrame();
        SwitchState();
    }

    IEnumerator Critical()
    {
        while (hp < 2)
        {
            yield return new WaitForSeconds(recoverTime);
            ++hp;
            UpdateColor();
        }
        nextState = "Normal";
        yield return new WaitForEndOfFrame();
        SwitchState();
    }
}
