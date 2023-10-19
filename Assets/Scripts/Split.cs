using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    public Transform m_ChildPointParent;//Ҫ�ƶ����Ӷ���ĸ�����
    private List<GameObject> m_Child;//�����Ӷ���
    private List<Vector3> m_InitPoint = new List<Vector3>();//��ʼλ��
    private Vector3 m_InitScale = new Vector3();//��ʼ��С

    public Transform m_TargetPointParent;//Ŀ������ĸ�����
    private List<GameObject> m_TargetChild;//Ŀ��������Ӷ���
    private List<Vector3> m_TargetPoint = new List<Vector3>();//Ҫ�ƶ���λ��
    private Vector3 m_TargetScale = new Vector3();//Ҫ�ƶ��Ĵ�С

    private void Start()
    {
        Initial(m_ChildPointParent, m_TargetPointParent);
    }

    internal void Initial(Transform Child, Transform Target)
    {
        m_Child = GetChild(Child);//��ȡ�����Ӷ���
        for (int i = 0; i < m_Child.Count; i++)
        {
            m_InitPoint.Add(m_Child[i].transform.position);
        }
        m_InitScale = Child.transform.localScale;

        m_TargetChild = GetChild(Target);//��ȡ����Ŀ����Ӷ���
        for (int i = 0; i < m_TargetChild.Count; i++)
        {
            m_TargetPoint.Add(m_TargetChild[i].transform.position);
        }
        m_TargetScale = Target.transform.localScale;
    }

    //��ȡ�����Ӷ���
    public List<GameObject> GetChild(Transform obj)
    {
        List<GameObject> tempArrayobj = new List<GameObject>();
        foreach (Transform child in obj)
        {
            tempArrayobj.Add(child.gameObject);
        }
        return tempArrayobj;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //���
            SplitObject();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //�ϲ�
            MergeObject();
        }
    }

    internal void SplitObject()
    {
        Debug.Log("split");
        for (int i = 0; i < m_Child.Count; i++)
        {
            m_Child[i].transform.DOMove(m_TargetPoint[i], 2f, false);

        }
        m_ChildPointParent.transform.DOScale(m_TargetScale, 2f);
    }

    internal void MergeObject()
    {
        Debug.Log("merge");
        for (int i = 0; i < m_InitPoint.Count; i++)
        {
            m_Child[i].transform.DOMove(m_InitPoint[i], 2f, false);
        }
        m_ChildPointParent.transform.DOScale(m_InitScale, 2f);

    }
}
