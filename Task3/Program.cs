using Accord.Math.Optimization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			//odczyt parametru
			string pathTxt = AppDomain.CurrentDomain.BaseDirectory;
			int k = 4;

			try
			{
				pathTxt = pathTxt + args[0].Trim();

			}
			catch
			{
				Console.WriteLine("Problem z ustaleniem ścieżki do pliku CSV !");
				return;

			}


			//załadowanie pliku CSV do tablicy
			string[][] lines = File.ReadLines(pathTxt)
			 .Select(s => s.Split(",".ToCharArray())).ToArray().ToArray();


			double[][] arrayMatrix = new double[lines.Length][];
			int cnt = 0;
			foreach (var line in lines)
			{

				var z = Array.ConvertAll(line, s => Double.Parse(s));
				arrayMatrix[cnt] = z;
				cnt++;
			}


			try
			{
				Munkres m = new Munkres(arrayMatrix);
				bool success = m.Maximize();
				double[] solution = m.Solution;
				double maxVal = Math.Abs(m.Value);
				Console.WriteLine("Wynik: " + maxVal);

			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return;
			}
			Console.ReadLine();
		}
	}
}
