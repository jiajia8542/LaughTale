using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public bool IsMoving => isMoving;

    [SerializeField] CharacterData data;
    [SerializeField] bool healthRegeneration;
    [SerializeField] int hot = 1;
    [SerializeField] float hotInterval = 1f;

    int currentHealth;

    protected bool isMoving;

    private float t;



    protected Vector2 moveTarget;
    protected Vector2 currentPosition;
    Coroutine moveTowadTargetCoroutine;
    Coroutine healthRegenerationCoroutine;
    WaitForSeconds waitForHotInterval;
    WaitForSeconds waitFor3s;


    protected virtual void Awake()
    {
        currentHealth = data.maxHealth;
        isMoving = false;
        waitForHotInterval = new WaitForSeconds(hotInterval);
        waitFor3s = new WaitForSeconds(3);
    }

    protected virtual void Start()
    {
        
    }
    protected virtual Vector2 GetMoveTarget()
    {
        return Vector2.zero;
    }
        

    #region MOVE

    public virtual void Move(Vector2 target)
    {
        if (moveTowadTargetCoroutine != null)
        {
            StopCoroutine(moveTowadTargetCoroutine);
        }

        moveTowadTargetCoroutine = StartCoroutine(MoveTowardTargetCoroutine(target));
    }

    

    IEnumerator MoveTowardTargetCoroutine(Vector2 targetPosition)
    {
        isMoving = true;
        t = Time.fixedDeltaTime * data.moveSpeed;
        currentPosition = transform.position;
        while (Vector2.Distance(targetPosition, transform.position) > t)
        {
            transform.Translate((targetPosition - currentPosition).normalized * t);

            yield return null;
        }
        isMoving = false;
    }
    #endregion
    #region HEALTH

    public void TakeDamage(int value)
    {
        currentHealth -= value;

        if (currentHealth <= 0)
        {
            Die();
        }


        if (gameObject.activeSelf)
        {
            if (healthRegeneration)
            {
                if (healthRegenerationCoroutine != null)
                {
                    StopCoroutine(healthRegenerationCoroutine);
                }

                healthRegenerationCoroutine = StartCoroutine(HealthRegenerationCoroutine(hot));
            }
        }
    }

    IEnumerator HealthRegenerationCoroutine(int hot)
    {
        while (currentHealth < data.maxHealth)
        {
            Debug.Log(currentHealth);
            currentHealth += hot;
            yield return waitForHotInterval;
        }
    }

    void Die()
    {
        currentHealth = 0;
        Debug.Log("die");

    }

    //IEnumerator Test()
    //{
    //    while (true)
    //    {
    //        TakeDamage(50);
    //        yield return waitFor3s;
    //    }

    //}
    #endregion

}


