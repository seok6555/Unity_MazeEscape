using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�ε��� �����͵��� ��� ���� ����
namespace Data
{
    #region Stat
    [Serializable]
    public class Stat
    {
        public int level; //ID
        public int hp;
        public int moveSpeed;
        public int jumpHeight;
    }

    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();  // json �����Ͱ� ����� ���

        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
            foreach (Stat stat in stats)
            {
                dict.Add(stat.level, stat);
            }
            return dict;
        }
    }
    #endregion

    #region ItemEffect
    [Serializable]
    public class ItemEffect
    {
        public int itemID;      // �������� ID (�ӽ�)
        public string itemName; // �������� �̸� (Ű��)
        //public string part;   // ����
        public int num;       // ��ġ
    }

    [Serializable]
    public class ItemEffectData : ILoader<int, ItemEffect>
    {
        public List<ItemEffect> itemEffects = new List<ItemEffect>();

        public Dictionary<int, ItemEffect> MakeDict()
        {
            Dictionary<int, ItemEffect> dict = new Dictionary<int, ItemEffect>();
            foreach (ItemEffect itemEffect in itemEffects)
            {
                dict.Add(itemEffect.itemID, itemEffect);
            }
            return dict;
        }
    }
    #endregion
}