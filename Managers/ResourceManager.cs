using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
   public T Load<T>(string path) where T : Object
    {   
        if(typeof(T) == typeof(GameObject)) // 1. original 이미 들고 있으면 바로 사용 
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null) // 프리팹에서 그 안의 경로 불러와 꺼내기 
    {   
        // 1. original 이미 들고 있으면 바로 사용 
        GameObject original = Load<GameObject>($"Prefabs/{path}"); // 오리지널 프리팹 
        if(original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
        }

        //2. 혹시 풀링된 애가 있을지.
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        // 만약에 풀링이 필요한 아이라면 -> 풀링 매니저 ! 
        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
        
}
