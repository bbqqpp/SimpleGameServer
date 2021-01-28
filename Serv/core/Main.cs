using System;

namespace Serv
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			DataMgr dataMgr = new DataMgr ();
			ServNet servNet = new ServNet();
			servNet.proto = new ProtocolBytes ();
			servNet.Start("127.0.0.1",1234);

			while(true)
			{
				string str = Console.ReadLine();
				switch(str)
				{
				case "quit":
					servNet.Close();
					return;
				case "print":
					servNet.Print();
					break;
				case "test":
					test(dataMgr);
					break;
				}
			}

		}

        private static void test(DataMgr dataMgr)
        {
			bool ret = dataMgr.Register("a", "123456");
			if (ret)
				Console.WriteLine("注册成功");
			else
				Console.WriteLine("注册失败");

			ret = dataMgr.CreatePlayer("playerA");
			if (ret)
				Console.WriteLine("创建角色成功");
			else
				Console.WriteLine("创建角色失败");
			PlayerData pd = dataMgr.GetPlayerData("playerA");
			if (pd != null)
				Console.WriteLine("获取玩家成功，分数为 " + pd.score);
			else
				Console.WriteLine("获取玩家数据失败");


        }
    }
}
