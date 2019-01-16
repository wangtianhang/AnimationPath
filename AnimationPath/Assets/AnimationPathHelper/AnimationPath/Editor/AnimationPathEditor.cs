using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimationPath))]
public class AnimationPathEditor : Editor
{
    static AnimationClip m_cacheClip = null;
    public static System.Action m_clipChange = null;

    void Update()
    {

    }

    public override void OnInspectorGUI()
    {
         if(m_cacheClip != AnimationWindowUtil.GetActiveAnimationClip())
         {
             m_cacheClip = AnimationWindowUtil.GetActiveAnimationClip();
             if(m_clipChange != null)
             {
                 m_clipChange();
                Debug.Log("clip change");
             }
         }

        AnimationPathSceneUI.OnInspectorGUI((target as MonoBehaviour).gameObject);
    }

    private void OnSceneGUI()
    {
        AnimationPathSceneUI.OnSceneGUI();
    }
}
