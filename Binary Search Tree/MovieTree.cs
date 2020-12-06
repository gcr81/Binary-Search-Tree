using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class MovieTree : IComparable<MovieTree>
    { 
        private string tittle;
        private string director;
        private int releaseDate;
        private double imdb;
        private MovieTree left;
        private MovieTree right;

        //Creatin the properties
        public string Tittle { get { return tittle; }  }
        public string Director { get { return director; }  }
        public int ReleaseDate { get { return releaseDate; }  }
        public double IMDb { get { return imdb; }  }


        #region Tree nodes
        //The tree nodes and comparing it 
        //making sure they follow the rules
        //Tree is based on the imdb
        public MovieTree Left
        {
            get { return left; }
            set
            {
                if (value?.CompareTo(this) > 0)      //incoming "left" must be smaller than this.val
                    left = null;
                else
                    left = value;
            }
        }

      //Right side statment for the tree node
        public MovieTree Right
        {
            get { return right; }
            set
            {
                if (value?.CompareTo(this) < 0)      //incoming "right" must be greater than this.val
                    right = null;
                else
                    right = value;
            }
        }

        #endregion

        #region MovieTree Insert Method
        //Properties which will use on creating new nodes
        public MovieTree(string tittl, string direcc, int releasY , double imd)
        {
            tittle = tittl;
            director = direcc;
            releaseDate = releasY;
            imdb = imd;
            left = null;
            right = null;
        }
        #endregion
               
        #region Checking for similarity
        //Check for similar items
        public bool CheckSimilarity(MovieTree other)
            {
                if (other.imdb == this.imdb && other.tittle == this.tittle && other.director == this.director && other.releaseDate == this.releaseDate)
                    return true;
                else if (other.imdb < this.imdb)
                    return false;
                else
                    return false;
            }

        //Compare method which defines who is more powerful
        // or to compare the values which will be used later to
        //define where in th list will they go
        public int CompareTo(MovieTree other)
        {
            if (other.imdb > this.imdb)
                return 1;
            else if (other.imdb < this.imdb)
                return -1;
            else
            {
                if (other.releaseDate > this.releaseDate)
                    return -1;
                else if (other.releaseDate < this.releaseDate)
                    return -1;
                else
                    return 0;
            }

        }
        #endregion

    public override string ToString()
    {
        return $"Tittle: {tittle}   Director: {director}   Release Date: { releaseDate}   IMDb: {IMDb} \n";
    }

    }


}
