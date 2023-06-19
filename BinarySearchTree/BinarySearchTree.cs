using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }

    public class BinarySearchTree
    {
        public static bool Contains(Node root, int value)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            if (root.Value == value)
                return true;
            // Si la valeur recherchée est plus grande on cherche à droite
            else if (root.Value < value && root.Right != null)
            {
                return Contains(root.Right, value);
            }
            // Si la valeur recherchée est plus petite on cherche à gauche
            else if (root.Value > value && root.Left != null)
            {
                return Contains(root.Left, value);
            }

            // La valeur n'est pas dans l'arbre
            return false;
        }

        public static void Main(string[] args)
        {
            Node n1 = new Node(1, null, null);
            Node n3 = new Node(3, null, null);
            Node n2 = new Node(2, n1, n3);

            Console.WriteLine(Contains(n2, 3));
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
