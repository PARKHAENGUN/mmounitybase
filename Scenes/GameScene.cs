﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{


    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.showSceneUI<UI_Inven>();

        Dictionary<int,Data.Stat> dict = Managers.Data.StatDict;
      
    }


    public override void Clear()
    {
           
    }

   
}
