//오민규 풀링
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static Dictionary<string, object> poolDictionary = new Dictionary<string, object>();
    public static Dictionary<string, GameObject> prefabDictionary = new Dictionary<string, GameObject>();

    // Prefab을 Count만큼 Parent의 자식으로 생성
    public static void CreatePool<T>(GameObject prefab, Transform parent, int count = 5)
    {
        Queue<T> queue = new Queue<T>(); // T = 생성할놈
        for(int i=0; i<count; i++)
        {
            GameObject gameObject = GameObject.Instantiate(prefab, parent);
            T t = gameObject.GetComponent<T>();
            gameObject.SetActive(false); // 사용은 GetItem에서 사용
            queue.Enqueue(t);
        }

        string key = typeof(T).ToString(); // T의 타입을 string으로
        poolDictionary.Add(key, queue); // T를 넣으면 Queue<T>가 나오게 추가
        prefabDictionary.Add(key, prefab); // T를 넣으면 T의 Prefab이 나오게 추가
    }

    public static T GetItem<T>() where T : MonoBehaviour
    {
        string key = typeof(T).ToString();
        T item = null;

        if(poolDictionary.ContainsKey(key)) // T -> Queue<T> 딕셔너리에서 T값이 있으면
        {
            Queue<T> q = (Queue<T>)poolDictionary[key]; // Queue<T> 꺼내오고
            T firstItem = q.Peek(); // 처음꺼
            if(firstItem.gameObject.activeSelf) // 가 쓰고있으면 새로만들어야함
            {
                GameObject prefab = prefabDictionary[key]; // GameObject<T> 꺼내오고
                GameObject g = GameObject.Instantiate(prefab, firstItem.transform.parent); // 만들고
                item = g.GetComponent<T>(); // prefab에 주섬주섬 T넣어주고
            }
            else // 가 안쓰고있으면 안만들어도됨
            {
                item = q.Dequeue();
                item.gameObject.SetActive(true);
            }
            q.Enqueue(item);
        }

        return item;
    }
}
