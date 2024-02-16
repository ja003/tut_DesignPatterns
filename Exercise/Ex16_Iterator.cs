using Coding.Exercise16;
using System;
using System.Collections.Generic;

namespace tut_DesignPatterns.Exercise
{
	class Ex16_Iterator
	{
		public static void Start()
		{
			Node<int> n1 = new Node<int>(1);
			Node<int> n2 = new Node<int>(2);
			Node<int> n0 = new Node<int>(0, n1, n2);

			foreach(var n in n0.PreOrder)
			{
				Console.WriteLine(n);
			}
		}
	}
}

namespace Coding.Exercise16
{
	public class Node<T>
	{
		public T Value;
		public Node<T> Left, Right;
		public Node<T> Parent;

		public Node(T value)
		{
			Value = value;
		}

		public Node(T value, Node<T> left, Node<T> right)
		{
			Value = value;
			Left = left;
			Right = right;

			left.Parent = right.Parent = this;
		}

		private IEnumerable<Node<T>> Traverse(Node<T> current)
		{
			yield return current;
			if(current.Left != null)
			{
				foreach(var left in Traverse(current.Left))
					yield return left;
			}
			if(current.Right != null)
			{
				foreach(var right in Traverse(current.Right))
					yield return right;
			}
		}

		public IEnumerable<T> PreOrder
		{
			get
			{
				foreach(var node in Traverse(this))
					yield return node.Value;
			}
		}
	}
}