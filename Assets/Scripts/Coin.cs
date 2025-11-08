using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Coin : MonoBehaviour
{
    public UnityEvent Collect;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //using UnityEngine.Events;
            Collect?.Invoke();
            Disable();
            MoneyManager.instance.money++;
        }
    }

    public void Disable()
    {
        StartCoroutine(DesativeRoutine());
    }
    
    IEnumerator DesativeRoutine()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
