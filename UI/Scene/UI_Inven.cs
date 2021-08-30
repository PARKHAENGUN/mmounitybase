using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    
    enum GameObjects
    {
        GridPanel
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform) // 트랜스폼이 들고 있는 모든 아이들 순회 
            Managers.Resource.Destroy(child.gameObject);

        //실제 인벤토리 정보 참고
        for(int i = 0; i < 8; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(parent : gridPanel.transform).gameObject;
         
            //item.GetOrAddComponent<> ~ Extension 에서 확장
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>(); // item 에 UI_Inven_Item 추가
            invenItem.SetInfo($"인벤토리{i}번");
        }

    }

    
}
