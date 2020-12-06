using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class BST
    { //reference to the root node
        private MovieTree root;
        private static MovieTree searchValue;

        public MovieTree Root
        {
            get { return root; }
        }

        #region BST Recursive method
        public BST(List<MovieTree> elementsList)
        {
            //recursive method call, builds the entire tree and returns the root node.
            root = BuildNode(elementsList, 0, elementsList.Count - 1);
        }

        
        private static MovieTree BuildNode(List<MovieTree> elementsList, int startIndex, int endIndex)
        {
            if (startIndex > endIndex) return null;

            int mid = (int)Math.Floor(((double)startIndex + (double)endIndex) / 2);
            //Finding the middle of each element from the list 
            MovieTree newNode = new MovieTree(elementsList[mid].Tittle, elementsList[mid].Director , elementsList[mid].ReleaseDate, elementsList[mid].IMDb);

            newNode.Left = BuildNode(elementsList, startIndex, mid - 1);
            newNode.Right = BuildNode(elementsList, mid + 1, endIndex);

            return newNode;
        }
        #endregion

        #region BreadthFirstTraversal method 
        //This Method is not special, something that i have taken from 
        //Binary Tree example from the class
        public string BreadthFirstTraversal()
        {
            Queue<MovieTree> q = new Queue<MovieTree>();

            string output = "";

            q.Enqueue(root);

            while (q.Count > 0)
            {
                MovieTree popped = q.Dequeue();  
                if (popped.Left != null)
                    q.Enqueue(popped.Left);
                if (popped.Right != null)   
                    q.Enqueue(popped.Right);

                output += popped.ToString();
            }

            return output;
        }
        #endregion
        
        #region Search Recursive
        public MovieTree Search_Recursive(string searchName)
        {//Simple recrusive call method
            searchName = searchName.ToLower();
            searchValue = null;

            Search_Recursive(searchName, root);

            return searchValue;
        }
        //There are 2 ways to search on this method
        private void Search_Recursive(string searchName, MovieTree current)
        {       //validation
            if (current == null) return;

            //Firstone would be by the the Title which is common
            if (current.Tittle.ToLower().Contains(searchName))
                if (searchValue == null)
                    searchValue = current;
            //The second one will be with director name 
            if (current.Director.ToLower().Contains(searchName))
                if (searchValue == null)
                    searchValue = current;
            //and the last one will be with movie IMDb
                else if (current.IMDb< searchValue.IMDb)
                    searchValue = current;

            Search_Recursive(searchName, current.Left);
            Search_Recursive(searchName, current.Right);

            return;
        }
        #endregion
    }
}
