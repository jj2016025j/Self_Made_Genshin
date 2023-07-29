using System.Collections;
using UnityEngine;

namespace abilityvalue
{
    public class player : MonoBehaviour
    {
        public string Player;
        public bool Death;
        public float Deathtime;
        public float Health;
        public float Attack;
        public float Movement;
        public player(string player, bool death, float deathtime, float health, float attack, float movement)
        {
            Player = player;
            Death = death;
            Deathtime = deathtime;
            Health = health;
            Attack = attack;
            Movement = movement;
        }
        // Use this for initialization
        void Start()
        {
            player p1 = new player("player1", false, 10, 100, 5, 100);
            Debug.Log(p1.Player);
        }

        // Update is called once per frame
        void Update()
        {

        }
                [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }

    }
}