using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//해당 인터페이스를 상속받은 자식클래스는 Key, Value를 뱉어주는 MakeDict 메서드를 반드시 구현해야함.
public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    //스탯 관련 데이터들을 담는 딕셔너리 프로퍼티.
    //Key : int (몬스터 스탯 - 3번, NPC 스탯 - 4번 이런식으로 id를 부여해서 데이터를 찾음.)
    //Value : Stat 객체
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public Dictionary<string, Data.ItemEffect> ItemEffectDict { get; private set; } = new Dictionary<string, Data.ItemEffect>();

    public void Init()
    {
        //게임이 시작되면 StatData.json 파일로부터 읽어들인 데이터가 저장된 Stat 객체들이 담긴 딕셔너리를 만들어 StatDict 프로퍼티에 저장.
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        ItemEffectDict = LoadJson<Data.ItemEffectData, string, Data.ItemEffect>("ItemEffectData").MakeDict();
    }

    //제네릭 매개변수
    //Loader : ILoader를 상속받는 객체. ex) Stat 객체들을 딕셔너리에 담아 리턴하는 기능을 하는 StatData 객체가 들어갈 것.
    //Key : int id형태가 아닌 string으로 데이터를 찾을 수도 있기 때문에.
    //Value : Stat객체가 들어올 것. 스탯뿐만 아니라 다양한 형식의 데이터가 있을 수도 있기 때문에.
    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = GameManager.Instance.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
