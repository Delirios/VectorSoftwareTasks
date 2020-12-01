using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RailFenceCipher
{
	class Program
	{
		static void Main(string[] args)
		{
			string result = Encode("WEAREDISCOVEREDFLEEATONCE", 3);
			Console.WriteLine(result);
			result = Decrypt("WECRLTEERDSOEEFEAOCAIVDEN", 3);
			Console.WriteLine(result);
		}

		public static string Encode(string textToEncode, int number)
		{
			if (textToEncode == string.Empty)
			{
				return textToEncode;
			}

			textToEncode = textToEncode.Trim().Replace(" ", string.Empty);

			var rows = new List<StringBuilder>();

			for (int i = 0; i < number; i++)
			{
				rows.Add(new StringBuilder());
			}

			int currentRow = 0;
			int direction = 1;

			for (int i = 0; i < textToEncode.Length; i++)
			{
				rows[currentRow].Append(textToEncode[i]);

				if (currentRow == 0)
				{
					direction = 1;
				}
				else if (currentRow == number - 1)
				{
					direction = -1;
				}

				currentRow += direction;
			}

			string result = "";

			for (int i = 0; i < number; i++)
			{
				result += rows[i].ToString();
			}

			return result;
		}

		public static string Decrypt(string textToDecode, int number)
		{
			if (textToDecode == string.Empty)
			{
				return textToDecode;
			}

			textToDecode = textToDecode.Trim().Replace(" ", string.Empty);

			var rows = new List<StringBuilder>();

			for (int i = 0; i < number; i++)
			{
				rows.Add(new StringBuilder());
			}

			int[] rowsLenght = Enumerable.Repeat(0, number).ToArray();

			int currentRow = 0;
			int direction = 1;

			for (int i = 0; i < textToDecode.Length; i++)
			{
				rowsLenght[currentRow]++;

				if (currentRow == 0)
				{
					direction = 1;
				}
				else if (currentRow == number - 1)
				{
					direction = -1;
				}

				currentRow += direction;
			}

			int currentChar = 0;

			for (int line = 0; line < number; line++)
			{
				for (int c = 0; c < rowsLenght[line]; c++)
				{
					rows[line].Append(textToDecode[currentChar]);
					currentChar++;
				}
			}

			string result = "";

			currentRow = 0;
			direction = 1;

			int[] currentReadLine = Enumerable.Repeat(0, number).ToArray();

			for (int i = 0; i < textToDecode.Length; i++)
			{

				result += (rows[currentRow][currentReadLine[currentRow]]);
				currentReadLine[currentRow]++;

				if (currentRow == 0)
				{
					direction = 1;
				}
				else if (currentRow == number - 1)
				{
					direction = -1;
				}
				currentRow += direction;
			}

			return result;
		}
	}
}
