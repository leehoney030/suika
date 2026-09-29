using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    public float requiredStayTime = 2f;

    private Dictionary<MergeObj, float> stayTimers = new Dictionary<MergeObj, float>();

    private void OnTriggerStay2D(Collider2D other)
    {
        if(GameManager.Instance.IsGameOver) return;

        MergeObj obj = other.GetComponent<MergeObj>();

        if(obj == null) return;

        Rigidbody2D rb = other.attachedRigidbody;

        if(rb == null) return;
        if(rb.bodyType != RigidbodyType2D.Dynamic) return;

        if(!stayTimers.ContainsKey(obj))
        {
            stayTimers[obj] = 0f;
        }

        stayTimers[obj] += Time.deltaTime;

        if(stayTimers[obj] >= requiredStayTime)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        MergeObj obj = other.GetComponent<MergeObj>();

        if(obj == null) return;

        if(stayTimers.ContainsKey(obj))
        {
            stayTimers.Remove(obj);
        }
    }
}
