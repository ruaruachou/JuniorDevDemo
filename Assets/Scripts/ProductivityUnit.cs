using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiple = 2;
    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)//仅在当前未占用ResoursePile时进行
        {
            //使用as语法进行转化，m_Target属于基类Buliding，ResoursePile为Buliding的子类
            //如果as能将Buliding转化为ResoursePile，则返回ResoursePile并给pile变量赋值，否则返回null
            //根据pile变量是否为null判断后续操作
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                //用于打断继续执行，回到if开头，当前pile m_CurrentPile有值，则不再继续重复执行，否则会每帧都把生产率翻倍
                m_CurrentPile = pile;
                //实际要实现的效果：生产率翻倍
                m_CurrentPile.ProductionSpeed *= ProductivityMultiple;
            }
        }
    }
    void ResetProductivity()
    {   //仅在当前占有m_CurrentPile时执行
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
