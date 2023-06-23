using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiple = 2;
    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)//���ڵ�ǰδռ��ResoursePileʱ����
        {
            //ʹ��as�﷨����ת����m_Target���ڻ���Buliding��ResoursePileΪBuliding������
            //���as�ܽ�Bulidingת��ΪResoursePile���򷵻�ResoursePile����pile������ֵ�����򷵻�null
            //����pile�����Ƿ�Ϊnull�жϺ�������
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                //���ڴ�ϼ���ִ�У��ص�if��ͷ����ǰpile m_CurrentPile��ֵ�����ټ����ظ�ִ�У������ÿ֡���������ʷ���
                m_CurrentPile = pile;
                //ʵ��Ҫʵ�ֵ�Ч���������ʷ���
                m_CurrentPile.ProductionSpeed *= ProductivityMultiple;
            }
        }
    }
    void ResetProductivity()
    {   //���ڵ�ǰռ��m_CurrentPileʱִ��
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiple;
            m_CurrentPile = null;
        }
    }
    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }
    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
