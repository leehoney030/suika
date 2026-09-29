using UnityEngine;

public class MergeObj : MonoBehaviour
{
    public int level;
    public bool isMerging = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MergeObj other = collision.gameObject.GetComponent<MergeObj>();

        if (other == null) return;
        
        MergeManager.Instance.TryMerge(this, other);
    }
}
