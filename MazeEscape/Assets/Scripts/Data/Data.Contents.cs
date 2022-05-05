using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//로드한 데이터들을 들고 있을 파일
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
        public List<Stat> stats = new List<Stat>();  // json 데이터가 여기로 담김

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
        public string itemName; // 아이템의 이름 (키값)
        public string part;     // 부위
        public int num;         // 수치
    }

    [Serializable]
    public class ItemEffectData : ILoader<string, ItemEffect>
    {
        public List<ItemEffect> itemEffects = new List<ItemEffect>();

        public Dictionary<string, ItemEffect> MakeDict()
        {
            Dictionary<string, ItemEffect> dict = new Dictionary<string, ItemEffect>();
            foreach (ItemEffect itemEffect in itemEffects)
            {
                dict.Add(itemEffect.itemName, itemEffect);
            }
            return dict;
        }
    }
    #endregion
}