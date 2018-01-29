using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    public Image visualHealth;
    public float currentStamina;
    public float minXValue;
    public float maxXvalue;
    public float cachedY;
    public float maxStamina; 

    void Awake()
    {
        //if(this.gameObject.tag == "Player")
        //{
        //    playerUnit = this.gameObject.GetComponent<playerUnits>();
        //    maxHealth = playerUnit.healthPoint;
        //} 
        //else if(this.gameObject.tag == "Enemy")
        //{
        //    enemyUnit = this.gameObject.GetComponent<enemyUnit>();
        //    maxHealth = enemyUnit.healthPoint;
        //}                  
    }
    // Use this for initialization
    void Start()
    {
        currentStamina = maxStamina;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.gameObject.activeSelf)
            HandleHealth();

        if(currentStamina >= 100)
        {
            currentStamina = 100;
        }

        //if (playerUnit != null)
        //    currentHealth = playerUnit.healthPoint;
        //else if (enemyUnit != null)
        //    currentHealth = enemyUnit.healthPoint;


    }

    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
    //private void HandleHealth()
    //{
    //    float currentXValue = MapValues(currentHealth, 0, maxHealth, minXValue, maxXvalue);
    //    //float currentXValue = minXValue;
    //    print(currentXValue);
    //    healthTransform.position = new Vector2(currentXValue, cachedY);
    //}

    void HandleHealth()
    {
        visualHealth.fillAmount = MapValues(currentStamina, 0, maxStamina, 0, 1);
    }
}
