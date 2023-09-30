using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;
using Random = UnityEngine.Random;

public abstract class TruongUtils
{
    public static int GetRandomIndexInList(int listCount)
    {
        return Random.Range(0, listCount);
    }

    public static int CreateRandomId()
    {
        return Random.Range(100000, 1000000);
    }

    public static double ConvertToUnixTime(DateTime time)
    {
        DateTime epoch = new System.DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        return (time - epoch).TotalSeconds;
    }

    public static DateTime ConvertFromUnixTime(double timeStamp)
    {
        DateTime epoch = new System.DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        DateTime time = epoch.AddSeconds(timeStamp);
        return time;
    }

    public static int GetHours(float totalSeconds)
    {
        return (int)(totalSeconds / 3600f);
    }

    public static int GetMinutes(float totalSeconds)
    {
        return (int)((totalSeconds / 60) % 60);
    }

    public static int GetSeconds(float totalSeconds)
    {
        return (int)(totalSeconds % 60);
    }

    public static string FormatTime(int timeMinute)
    {
        int hour = timeMinute / 60;
        int minute = timeMinute % 60;
        if (hour == 0)
        {
            return String.Format("{0:00}:{1:00}", minute, 0);
        }

        return String.Format("{0:0}:{1:00}:{2:00}", hour, minute, 0);
    }

    public static string FormatTimeSecond(int timeSecond)
    {
        int hour = timeSecond / 3600;
        int minute = (timeSecond / 60) % 60;
        int second = timeSecond % 60;
        if (hour == 0)
        {
            return String.Format("{0:00}:{1:00}", minute, second);
        }

        return String.Format("{0:0}:{1:00}:{2:00}", hour, minute, second);
    }

    #region Cryptography

    public static string XOROperator(string input, string key)
    {
        char[] output = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
            output[i] = (char)(input[i] ^ key[i % key.Length]);
        return new string(output);
    }

    public static string GenerateSHA256NonceFromRawNonce(string rawNonce)
    {
        var sha = new SHA256Managed();
        var utf8RawNonce = Encoding.UTF8.GetBytes(rawNonce);
        var hash = sha.ComputeHash(utf8RawNonce);

        var result = string.Empty;
        for (var i = 0; i < hash.Length; i++)
        {
            result += hash[i].ToString("x2");
        }

        return result;
    }

    public static string GenerateRandomString(int length)
    {
        if (length <= 0)
        {
            throw new Exception("Expected nonce to have positive length");
        }

        const string charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvwxyz-._";
        var cryptographicallySecureRandomNumberGenerator = new RNGCryptoServiceProvider();
        var result = string.Empty;
        var remainingLength = length;
        var randomNumberHolder = new byte[1];
        while (remainingLength > 0)
        {
            var randomNumbers = new List<int>(16);
            for (var randomNumberCount = 0; randomNumberCount < 16; randomNumberCount++)
            {
                cryptographicallySecureRandomNumberGenerator.GetBytes(randomNumberHolder);
                randomNumbers.Add(randomNumberHolder[0]);
            }

            for (var randomNumberIndex = 0; randomNumberIndex < randomNumbers.Count; randomNumberIndex++)
            {
                if (remainingLength == 0)
                    break;
                var randomNumber = randomNumbers[randomNumberIndex];
                if (randomNumber < charset.Length)
                {
                    result += charset[randomNumber];
                    remainingLength--;
                }
            }
        }

        return result;
    }

    #endregion

    #region Other

    public static void Shuffle<T>(IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static String ConvertToString(Enum eff)
    {
        return Enum.GetName(eff.GetType(), eff);
    }

    public static EnumType ConvertToEnum<EnumType>(String enumValue)
    {
        return (EnumType)Enum.Parse(typeof(EnumType), enumValue);
    }

    #endregion
}