using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static HealthController instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public float startHealth = 10f;
    private Animator anim;
    private PlayerController playerController;
    private bool isDead = false;
    private bool isDamageable = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        GameStats.health = startHealth;
    }

    public void ApplyDamage(float damage)
    {    
        if(isDamageable)
        {
            GameStats.health -= damage;
            GameStats.health = Mathf.Max (0f,GameStats.health);

            if (!isDead)
            {
                if (GameStats.health == 0)
                {
                    isDead = true;
                    Dying();
                }
                else
                {
                    if(isDamageable)
                    {
                        anim.SetBool("Damage", true);
                        StartCoroutine(Damage());
                    }
                }

                isDamageable = false;
                Invoke("ResetIsDamageable", 1);
            }
        } 
    }

    void ResetIsDamageable()
    {
        isDamageable = true;
    }

    void Dying ()
    {
        GameStats.lifes--;
        playerController.enabled = false;

        if (GameStats.lifes <= 0)
        {
            Level_Loader.instance.SetCurrentScene(12);
        }
        else
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        GameStats.health = startHealth;
        playerController.enabled = true;
        isDead = false;
        Level_Loader.instance.ReloadLevel();
    }

    public void Healing (int healing) 
    {
        GameStats.health += healing;
        CatFix();
    }

    IEnumerator Damage ()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Damage", false);
    }

    public void CatFix ()
    {
        anim.SetBool("Damage", false);
    }
}