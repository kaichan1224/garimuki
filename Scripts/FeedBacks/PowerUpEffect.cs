using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PowerUpEffect : MonoBehaviour
{
    [SerializeField] private MMFeedbacks powerUpFeedback;
    // Start is called before the first frame update
    void Start()
    {
        PowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PowerUp()
    {
        
        powerUpFeedback.PlayFeedbacks();
    }
}
