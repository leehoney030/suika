using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public static MergeManager Instance;
    public GameObject[] mergePrefabs;

    private void Awake()
    {
        Instance = this;
    }

    public void TryMerge(MergeObj first, MergeObj second)
    {
        if (first.level != second.level) return;

        if (first.isMerging || second.isMerging) return;

        if (first.gameObject.GetInstanceID() > second.gameObject.GetInstanceID()) return;

        int curLevel = first.level;

        if(curLevel < 3) SoundManager.Instance.PlaySFX(1);
        else if(curLevel < 6) SoundManager.Instance.PlaySFX(2);
        else SoundManager.Instance.PlaySFX(3);

        int nextLevel = curLevel + 1;

        if(nextLevel >= mergePrefabs.Length) return;

        first.isMerging = true;
        second.isMerging = true;

        Vector3 mergePosition = (first.transform.position + second.transform.position) / 2f;

        Destroy(first.gameObject);
        Destroy(second.gameObject);

        Instantiate(mergePrefabs[nextLevel], mergePosition, Quaternion.identity);

        ScoreManager.Instance.AddScore(curLevel);
    }
}
