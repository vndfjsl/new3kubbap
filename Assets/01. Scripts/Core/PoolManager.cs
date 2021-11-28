//���α� Ǯ��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static Dictionary<string, object> poolDictionary = new Dictionary<string, object>();
    public static Dictionary<string, GameObject> prefabDictionary = new Dictionary<string, GameObject>();

    // Prefab�� Count��ŭ Parent�� �ڽ����� ����
    public static void CreatePool<T>(GameObject prefab, Transform parent, int count = 5)
    {
        Queue<T> queue = new Queue<T>(); // T = �����ҳ�
        for(int i=0; i<count; i++)
        {
            GameObject gameObject = GameObject.Instantiate(prefab, parent);
            T t = gameObject.GetComponent<T>();
            gameObject.SetActive(false); // ����� GetItem���� ���
            queue.Enqueue(t);
        }

        string key = typeof(T).ToString(); // T�� Ÿ���� string����
        poolDictionary.Add(key, queue); // T�� ������ Queue<T>�� ������ �߰�
        prefabDictionary.Add(key, prefab); // T�� ������ T�� Prefab�� ������ �߰�
    }

    public static T GetItem<T>() where T : MonoBehaviour
    {
        string key = typeof(T).ToString();
        T item = null;

        if(poolDictionary.ContainsKey(key)) // T -> Queue<T> ��ųʸ����� T���� ������
        {
            Queue<T> q = (Queue<T>)poolDictionary[key]; // Queue<T> ��������
            T firstItem = q.Peek(); // ó����
            if(firstItem.gameObject.activeSelf) // �� ���������� ���θ�������
            {
                GameObject prefab = prefabDictionary[key]; // GameObject<T> ��������
                GameObject g = GameObject.Instantiate(prefab, firstItem.transform.parent); // �����
                item = g.GetComponent<T>(); // prefab�� �ּ��ּ� T�־��ְ�
            }
            else // �� �Ⱦ��������� �ȸ�����
            {
                item = q.Dequeue();
                item.gameObject.SetActive(true);
            }
            q.Enqueue(item);
        }

        return item;
    }
}
