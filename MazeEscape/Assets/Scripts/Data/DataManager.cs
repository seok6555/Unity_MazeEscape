using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ش� �������̽��� ��ӹ��� �ڽ�Ŭ������ Key, Value�� ����ִ� MakeDict �޼��带 �ݵ�� �����ؾ���.
public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    //���� ���� �����͵��� ��� ��ųʸ� ������Ƽ.
    //Key : int (���� ���� - 3��, NPC ���� - 4�� �̷������� id�� �ο��ؼ� �����͸� ã��.)
    //Value : Stat ��ü
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public Dictionary<string, Data.ItemEffect> ItemEffectDict { get; private set; } = new Dictionary<string, Data.ItemEffect>();

    public void Init()
    {
        //������ ���۵Ǹ� StatData.json ���Ϸκ��� �о���� �����Ͱ� ����� Stat ��ü���� ��� ��ųʸ��� ����� StatDict ������Ƽ�� ����.
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        ItemEffectDict = LoadJson<Data.ItemEffectData, string, Data.ItemEffect>("ItemEffectData").MakeDict();
    }

    //���׸� �Ű�����
    //Loader : ILoader�� ��ӹ޴� ��ü. ex) Stat ��ü���� ��ųʸ��� ��� �����ϴ� ����� �ϴ� StatData ��ü�� �� ��.
    //Key : int id���°� �ƴ� string���� �����͸� ã�� ���� �ֱ� ������.
    //Value : Stat��ü�� ���� ��. ���ȻӸ� �ƴ϶� �پ��� ������ �����Ͱ� ���� ���� �ֱ� ������.
    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = GameManager.Instance.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
