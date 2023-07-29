using System;
namespace 遊戲架構
{
    public partial class manager : Form
    {
            public manager()
        {
            InitializeComponent();
        }
        public int x, y, z;//位置
        public int health, nowhealth;//血量
        public int movespeed, nowmovespeed;//速度
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = x.ToString();
            label2.Text = y.ToString();
            label3.Text = z.ToString();
        }

        private void manager_Load(object sender, EventArgs e)
        {

        }
    }
    class worldmanager
    {
        static void test(int Int)
        {
            Console.WriteLine(Int);
            Console.ReadKey();
        }
    }
    /*class player : Form
    {
        public int x,y,z;//位置
        public int health, nowhealth;//血量
        public int movespeed, nowmovespeed;//速度

        enum condition//狀態
        {
            //待命
            //滯空
            //移動
            //死亡
        }
        private void button1_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            z = 0;
        }
        static void test(int Int)
        {
            Console.WriteLine(Int);
            Console.ReadKey();
        }
    }*/
}
