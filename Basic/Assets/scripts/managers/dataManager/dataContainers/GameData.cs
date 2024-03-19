using System;
using System.Collections;
using UnityEngine;

namespace Global.Managers.Datas
{
    [Serializable]
    public class GameData
    {
        public bool isInit = false;

        public MainData mainData = new MainData();

        public enum GameStage
        {
            Main
        }

        public GameStage currentStageData = GameStage.Main;

        public void PostInitData()
        {
            mainData.PostInit();
        }
    }

}
