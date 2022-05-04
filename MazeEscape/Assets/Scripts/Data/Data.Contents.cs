using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//∑ŒµÂ«— µ•¿Ã≈ÕµÈ¿ª µÈ∞Ì ¿÷¿ª ∆ƒ¿œ
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
        public List<Stat> stats = new List<Stat>();  // json µ•¿Ã≈Õ∞° ø©±‚∑Œ ¥„±Ë

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
<<<<<<< HEAD

    #region ItemEffect
    [Serializable]
    public class ItemEffect
    {
        public string itemName; // æ∆¿Ã≈€¿« ¿Ã∏ß (≈∞∞™)
        public string itemType; // æ∆¿Ã≈€¿« ≈∏¿‘
        public string part;     // æ∆¿Ã≈€¿« ¿˚øÎ ∫Œ¿ß
        public int num;         // æ∆¿Ã≈€¿« ºˆƒ°
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
=======
>>>>>>> parent of db07ee3 (2022.05.02. UI ÏàòÏ†ï ÏûëÏóÖ)
}