
using Unity.VisualScripting;
using UnityEngine;

internal static class Instance<T> where T : MonoBehaviour
{
   public static GameObject LoadToScean(GameObject prefab, Transform container = null)
    {
        bool isParant = container == null ? false : true;
        GameObject objectview;
        if (isParant)
            objectview = GameObject.Instantiate(prefab, container, false);
        else objectview = GameObject.Instantiate(prefab);


        return objectview;
    }
    public static T GetView (GameObject prefab)  => prefab.GetComponent<T>();
    
}
