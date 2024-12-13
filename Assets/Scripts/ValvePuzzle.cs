using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValvePuzzle : MonoBehaviour
{
    public GameObject inttext, valve;
    public ValvePuzzle valve1, valve2, valve3, correctValve1, correctValve2, correctValve3, columnValve;
    public Renderer lamp, lamp1, lamp2, lamp3;
    public Material red, green, normal;
    public Material[] mat, mat1, mat2, mat3;
    public Animator valveAnim, doorAnim;

    public bool interactable, isCorrect, isSelected, isColumnSelected;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (columnValve.isColumnSelected == false)
            {
                inttext.SetActive(true);
                interactable = true;
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                valve1.isColumnSelected = true;
                valve2.isColumnSelected = true;
                valve3.isColumnSelected = true;
                isSelected = true;
                if (isCorrect)
                {
                    mat = lamp.materials;
                    mat[1] = green;
                    lamp.materials = mat;
                    Debug.Log("Correct Valve");
                }
                else
                {
                    mat = lamp.materials;
                    mat[1] = red;
                    lamp.materials = mat;
                    Debug.Log("Wrong Valve");
                }
                if (correctValve1.isColumnSelected && correctValve2.isColumnSelected && correctValve3.isColumnSelected)
                {
                    if (correctValve1.isSelected && correctValve2.isSelected && correctValve3.isSelected)
                    {
                        StartCoroutine(rightValve());
                        doorAnim.SetTrigger("Open");
                    }
                    else
                    {
                        StartCoroutine(wrongValve());
                        correctValve1.isColumnSelected = false;
                        correctValve2.isColumnSelected = false;
                        correctValve3.isColumnSelected = false;
                        correctValve1.isSelected = false;
                        correctValve2.isSelected = false;
                        correctValve3.isSelected = false;
                    }
                }

                valveAnim.SetTrigger("Rotate");
                StartCoroutine(waitForTrigger());

            }
        }
    }

    IEnumerator waitForTrigger()
    {
        yield return new WaitForSeconds(1);
        valveAnim.ResetTrigger("Rotate");
    }
    IEnumerator rightValve()
    {
        yield return new WaitForSeconds(1);
        mat1 = lamp1.materials;
        mat2 = lamp2.materials;
        mat3 = lamp3.materials;
        mat1[1] = green;
        mat2[1] = green;
        mat3[1] = green;
        lamp1.materials = mat1;
        lamp2.materials = mat2;
        lamp3.materials = mat3;
        Debug.Log("Right Combination");
        yield return new WaitForSeconds(1);
        mat1 = lamp1.materials;
        mat2 = lamp2.materials;
        mat3 = lamp3.materials;
        mat1[1] = normal;
        mat2[1] = normal;
        mat3[1] = normal;
        lamp1.materials = mat1;
        lamp2.materials = mat2;
        lamp3.materials = mat3;
        yield return new WaitForSeconds(1);
        mat1 = lamp1.materials;
        mat2 = lamp2.materials;
        mat3 = lamp3.materials;
        mat1[1] = green;
        mat2[1] = green;
        mat3[1] = green;
        lamp1.materials = mat1;
        lamp2.materials = mat2;
        lamp3.materials = mat3;
        yield return new WaitForSeconds(1);
        mat1 = lamp1.materials;
        mat2 = lamp2.materials;
        mat3 = lamp3.materials;
        mat1[1] = normal;
        mat2[1] = normal;
        mat3[1] = normal;
        lamp1.materials = mat1;
        lamp2.materials = mat2;
        lamp3.materials = mat3;

    }

    IEnumerator wrongValve()
    {
        yield return new WaitForSeconds(1);
        mat1 = lamp1.materials;
        mat2 = lamp2.materials;
        mat3 = lamp3.materials;
        mat1[1] = red;
        mat2[1] = red;
        mat3[1] = red;
        lamp1.materials = mat1;
        lamp2.materials = mat2;
        lamp3.materials = mat3;
        Debug.Log("Wrong Combination");
        yield return new WaitForSeconds(1);
        mat1 = lamp1.materials;
        mat2 = lamp2.materials;
        mat3 = lamp3.materials;
        mat1[1] = normal;
        mat2[1] = normal;
        mat3[1] = normal;
        lamp1.materials = mat1;
        lamp2.materials = mat2;
        lamp3.materials = mat3;
        yield return new WaitForSeconds(1);
        mat1 = lamp1.materials;
        mat2 = lamp2.materials;
        mat3 = lamp3.materials;
        mat1[1] = red;
        mat2[1] = red;
        mat3[1] = red;
        lamp1.materials = mat1;
        lamp2.materials = mat2;
        lamp3.materials = mat3;
        yield return new WaitForSeconds(1);
        mat1 = lamp1.materials;
        mat2 = lamp2.materials;
        mat3 = lamp3.materials;
        mat1[1] = normal;
        mat2[1] = normal;
        mat3[1] = normal;
        lamp1.materials = mat1;
        lamp2.materials = mat2;
        lamp3.materials = mat3;
    }
}
