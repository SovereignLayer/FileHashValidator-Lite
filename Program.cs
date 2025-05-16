using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class FileHashValidator
{
    static void Main(string[] args)
    {
        Console.WriteLine("🔍 FileHashValidator - Multi-Hash File Integrity Checker");

        if (args.Length != 1)
        {
            Console.WriteLine("Usage: FileHashValidator <path-to-file>");
            return;
        }

        string filePath = args[0];
        if (!File.Exists(filePath))
        {
            Console.WriteLine("❌ File not found.");
            return;
        }

        Console.WriteLine($"📄 File: {Path.GetFileName(filePath)}");
        string md5 = ComputeHash(filePath, MD5.Create());
        string sha1 = ComputeHash(filePath, SHA1.Create());
        string sha256 = ComputeHash(filePath, SHA256.Create());

        Console.WriteLine($"MD5:    {md5}");
        Console.WriteLine($"SHA1:   {sha1}");
        Console.WriteLine($"SHA256: {sha256}");

        var suspiciousHashes = File.ReadAllLines("known_hashes.txt");
        foreach (var hash in suspiciousHashes)
        {
            if (md5.Equals(hash.Trim(), StringComparison.OrdinalIgnoreCase) ||
                sha1.Equals(hash.Trim(), StringComparison.OrdinalIgnoreCase) ||
                sha256.Equals(hash.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("⚠️ Warning: This file matches a known suspicious hash.");
                return;
            }
        }

        Console.WriteLine("✅ File is clean (hash not in list).");
    }

    static string ComputeHash(string filePath, HashAlgorithm algorithm)
    {
        using var stream = File.OpenRead(filePath);
        var hashBytes = algorithm.ComputeHash(stream);
        var sb = new StringBuilder();
        foreach (byte b in hashBytes)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
}
