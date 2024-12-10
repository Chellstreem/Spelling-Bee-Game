using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject correctLetterSalute;
    [SerializeField] GameObject wrongLetterPrefab;
    [SerializeField] GameObject wordCompletedSalute;
    [SerializeField] GameObject dancerPrefab;
    [SerializeField] GameObject confettiPrefab;
    [SerializeField] GameObject sparkPrefab;
   

    void Start()
    {
        

        animator = GetComponent<Animator>();
    }

    

    private void OnWordCompleted()
    {
        GameObject salute = Instantiate(wordCompletedSalute, gameObject.transform.position + new Vector3(0, 5f, 0), Quaternion.identity);
        Destroy(salute, 2f);
    }

    

    private void SaluteOnGameOver()
    {
        GameObject salute = Instantiate(wrongLetterPrefab, gameObject.transform.position + new Vector3(0, 5f, 0), Quaternion.identity);
        Destroy(salute, 2f);
    }

    private void EnableDancers()
    {
        float offsetZ = 6f;
        float offsetY = 12f;
        Vector3 dancerPosition = new Vector3(transform.position.x, 0, transform.position.z + offsetZ);
        Vector3 confettiPosition = new Vector3(transform.position.x, offsetY, transform.position.z);
        Instantiate(dancerPrefab, dancerPosition, Quaternion.Euler(0, 150f, 0));
        
        GameObject spark = Instantiate(sparkPrefab, dancerPosition, Quaternion.identity);
        Destroy(spark, 2f);
        Instantiate(confettiPrefab, confettiPosition, Quaternion.identity);
    }

}
