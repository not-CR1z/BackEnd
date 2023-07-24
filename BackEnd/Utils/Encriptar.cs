using System.Security.Cryptography;
using System.Text;

namespace BackEnd.Utils
{
	public static class Encriptar
	{
		public static String EncriptarPassword(String input)
		{
			MD5 md5Hash = MD5.Create();
			// Convert the input string to a byte array and compute the hash.
			Byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
			StringBuilder sBuilder = new StringBuilder();
			for (Int32 i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
			return sBuilder.ToString();
		}
	}
}

