using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public static class ScoreBoard // 不能繼承MonoBehaviour，不能掛在物件上面
    {
      public static int score;

      static ScoreBoard(){    //初始化，開啟應用程式時會執行一遍。
      score=0;          //初始化靜態類別成員
      }
    }