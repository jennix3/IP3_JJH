using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthCubeFSM : MonoBehaviour
{
    public int hp = 4;
    public float recoveryTime = 2f; // Time in seconds to recover to Normal state
    public Slider healthSlider; // Reference to the Slider component

    private enum CubeState { Normal, Critical }
    private CubeState currentState;
    private Renderer cubeRenderer;

    private void Start()
    {
        currentState = CubeState.Normal;
        cubeRenderer = GetComponent<Renderer>();
        UpdateHealthSlider();
        UpdateCubeColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (currentState == CubeState.Critical && hp == 1)
            {
                Destroy(gameObject); // Destroy the cube if it is in Critical state and hp is 1
            }
            else
            {
                hp--;
                UpdateCubeState();
                UpdateHealthSlider();
                UpdateCubeColor();
            }
        }
    }

    private void UpdateCubeState()
    {
        if (hp <= 0)
        {
            Destroy(gameObject); // Destroy the cube if hp is 0
        }
        else if (hp == 1)
        {
            EnterCriticalState();
        }
        else
        {
            EnterNormalState();
        }
    }

    private void EnterCriticalState()
    {
        currentState = CubeState.Critical;
        StartCoroutine(RecoverToNormalState());
    }

    private void EnterNormalState()
    {
        currentState = CubeState.Normal;
    }

    private IEnumerator RecoverToNormalState()
    {
        yield return new WaitForSeconds(recoveryTime);
        if (currentState == CubeState.Critical)
        {
            hp = 2; // Recover to 2 hp
            EnterNormalState();
            UpdateHealthSlider();
            UpdateCubeColor();
        }
    }

    private void UpdateCubeColor()
    {
        if (cubeRenderer != null)
        {
            switch (hp)
            {
                case 4:
                    cubeRenderer.material.color = Color.green; // Green for 4 hp
                    break;
                case 3:
                    cubeRenderer.material.color = Color.yellow; // Yellow for 3 hp
                    break;
                case 2:
                    cubeRenderer.material.color = new Color(1.0f, 0.65f, 0.0f); // Orange for 2 hp
                    break;
                case 1:
                    cubeRenderer.material.color = Color.red; // Red for 1 hp
                    break;
            }
        }
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = hp;
        }
    }
}
