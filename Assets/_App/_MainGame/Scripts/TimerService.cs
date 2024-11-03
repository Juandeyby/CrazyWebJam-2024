using System;
using System.Collections;
using UnityEngine;

public class TimerService : MonoBehaviour
{
    public static TimerService Instance { get; private set; }
    
    public event Action OnTimePerSecond;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        StartCoroutine(UpdatePerSecond());
    }
    
    private IEnumerator UpdatePerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            OnTimePerSecond?.Invoke();
        }
    }
}
