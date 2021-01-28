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
				Console.WriteLine("ע��ɹ�");
			else
				Console.WriteLine("ע��ʧ��");

			ret = dataMgr.CreatePlayer("playerA");
			if (ret)
				Console.WriteLine("������ɫ�ɹ�");
			else
				Console.WriteLine("������ɫʧ��");
			PlayerData pd = dataMgr.GetPlayerData("playerA");
			if (pd != null)
				Console.WriteLine("��ȡ��ҳɹ�������Ϊ " + pd.score);
			else
				Console.WriteLine("��ȡ�������ʧ��");


        }
    }
}
