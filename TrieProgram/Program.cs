﻿namespace TrieProgram
{
	public class Trie
	{
		private static readonly int ALPHABET_SIZE = 26;

		public class TrieNode
		{
			public TrieNode[] children;
			public bool IsEndOfWord;

            public TrieNode()
            {
                children = new TrieNode[ALPHABET_SIZE];
				IsEndOfWord = false;
            }
        }

		private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

		public void Insert(string key)
		{
			TrieNode crawl = root;

			for (int level = 0; level < key.Length; level++)
			{
				int index = key[level] - 'a';
				if (crawl.children[index] is null)
					crawl.children[index] = new TrieNode();

				crawl = crawl.children[index];
			}

			crawl.IsEndOfWord = true;
		}

		public bool Search(string key)
		{
			TrieNode crawl = root;
			int index;

			for (int level = 0; level < key.Length; level++)
			{
				index = key[level] - 'a';
				if (crawl.children[index] is null)
					return false;
					
				crawl = crawl.children[index];
			}

			return crawl.IsEndOfWord;
		}

		public void Remove(string key)
		{
			RemoveHelper(root, key, 0);
		}

		private TrieNode RemoveHelper(TrieNode node, string key, int depth)
		{
			if (node is null)
				return node;

			if (depth == key.Length)
			{
				if (node.IsEndOfWord)
					node.IsEndOfWord = false;

				if (IsLeafNode(node))
					return null;

				return node;
			}

			int index = key[depth] - 'a';
			node.children[index] = RemoveHelper(node.children[index], key, depth + 1);

			if (IsLeafNode(node) && !node.IsEndOfWord)
				return null;

			return node;
		}

		public void Print()
		{
			char[] str = new char[20];
			int level = 0;

			PrintHelper(root, str, level);
		}

		private void PrintHelper(TrieNode node, char[] str, int level)
		{
			if (IsLeafNode(node) || node.IsEndOfWord)
			{
				for (int i = level; i < 20; i++)
					str[i] = '\0';

                Console.WriteLine(str);
            }

			for (int i = 0; i < ALPHABET_SIZE; i++)
			{
				if (node.children[i] is not null)
				{
					str[level] = (char)(i + 'a');
					PrintHelper(node.children[i], str, level + 1);
				}
			}
		}

		private bool IsLeafNode(TrieNode root)
		{
			for (int i = 0; i < ALPHABET_SIZE; i++)
				if (root.children[i] is not null)
					return false;

			return true;
		}
    }

	internal class Program
	{
		static void Main(string[] args)
		{
			Trie t = new();
			t.Insert("and");
			t.Insert("ant");
			t.Insert("cat");
            Console.WriteLine(t.Search("a"));
            Console.WriteLine(t.Search("and"));
            Console.WriteLine();
			t.Remove("and");
			t.Print();
        }
	}
}