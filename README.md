# FileHashValidator V1.0 🔍

A simple CLI tool to check if a file matches any known suspicious SHA256 hashes. Perfect as a beginner C# security utility runs fully offline and is open source.

## MAKE SURE TO CREATE A FOLDER AND PUT THE FILES IN THERE SO IT CAN RUN PROPERLY

## 🚀 Features

- 🧠 Checks file hash against a known list
- 🔒 Works fully locally
- 📁 Simple CLI usage
- 🧰 Written in C#

## 🧪 How to Use

1. Clone or download the repo.
2. Replace or edit `known_hashes.txt` with your own list of suspicious hashes.
3. Run with:

```bash
dotnet run -- path/to/file.exe
```

## 📂 Example

```bash
> dotnet run -- sample.exe
📄 File Hash: a7c4e6e5d7b0...
✅ File is clean (hash not in list).
```

## 🗂️ known_hashes.txt

Put one SHA256 hash per line of known malicious or unwanted files.

## Uses Net 8.0

I know this is a common thing but I wanted to make one for myself that is open source to build a rep.

Made by yours truly Sovereign Layer

## Psalm 18:2
    The Lord is my rock, my fortress and my deliverer; my God is my rock, in whom I take refuge, my shield and the horn of my salvation, my stronghold.
