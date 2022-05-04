using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ÇØ´ç ÀÎÅÍÆäÀÌ½º¸¦ »ó¼Ó¹ŞÀº ÀÚ½ÄÅ¬·¡½º´Â Key, Value¸¦ ¹ñ¾îÁÖ´Â MakeDict ¸Ş¼­µå¸¦ ¹İµå½Ã ±¸ÇöÇØ¾ßÇÔ.
public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    //½ºÅÈ °ü·Ã µ¥ÀÌÅÍµéÀ» ´ã´Â µñ¼Å³Ê¸® ÇÁ·ÎÆÛÆ¼.
    //Key : int (¸ó½ºÅÍ ½ºÅÈ - 3¹ø, NPC ½ºÅÈ - 4¹ø ÀÌ·±½ÄÀ¸·Î id¸¦ ºÎ¿©ÇØ¼­ µ¥ÀÌÅÍ¸¦ Ã£À½.)
    //Value : Stat °´Ã¼
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
<<<<<<< HEAD
    public Dictionary<string, Data.ItemEffect> ItemEffectDict { get; private set; } = new Dictionary<string, Data.ItemEffect>();
=======
>>>>>>> parent of db07ee3 (2022.05.02. UI ìˆ˜ì • ì‘ì—…)

    public void Init()
    {
        //°ÔÀÓÀÌ ½ÃÀÛµÇ¸é StatData.json ÆÄÀÏ·ÎºÎÅÍ ÀĞ¾îµéÀÎ µ¥ÀÌÅÍ°¡ ÀúÀåµÈ Stat °´Ã¼µéÀÌ ´ã±ä µñ¼Å³Ê¸®¸¦ ¸¸µé¾î StatDict ÇÁ·ÎÆÛÆ¼¿¡ ÀúÀå.
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
<<<<<<< HEAD
        ItemEffectDict = LoadJson<Data.ItemEffectData, string, Data.ItemEffect>("ItemEffectData").MakeDict();
=======
>>>>>>> parent of db07ee3 (2022.05.02. UI ìˆ˜ì • ì‘ì—…)
    }

    //Á¦³×¸¯ ¸Å°³º¯¼ö
    //Loader : ILoader¸¦ »ó¼Ó¹Ş´Â °´Ã¼. ex) Stat °´Ã¼µéÀ» µñ¼Å³Ê¸®¿¡ ´ã¾Æ ¸®ÅÏÇÏ´Â ±â´ÉÀ» ÇÏ´Â StatData °´Ã¼°¡ µé¾î°¥ °Í.
    //Key : int idÇüÅÂ°¡ ¾Æ´Ñ stringÀ¸·Î µ¥ÀÌÅÍ¸¦ Ã£À» ¼öµµ ÀÖ±â ¶§¹®¿¡.
    //Value : Stat°´Ã¼°¡ µé¾î¿Ã °Í. ½ºÅÈ»Ó¸¸ ¾Æ´Ï¶ó ´Ù¾çÇÑ Çü½ÄÀÇ µ¥ÀÌÅÍ°¡ ÀÖÀ» ¼öµµ ÀÖ±â ¶§¹®¿¡.
    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = GameManager.Instance.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
