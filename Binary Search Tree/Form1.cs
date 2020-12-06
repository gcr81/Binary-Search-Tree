using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
/// <summary>
/// Student:Oligert Crroj
/// ST#:4341654
/// Sample work of working with node tree
/// Thank You and I hope you enjoy it :)
/// </summary>
namespace lab3
{
    public partial class movieSort : Form
    {
        //Decaring the items that will be used more than 1
        string filePath;
        string[] entries;
        List<string> listholder = new List<string>();
        List<MovieTree> storeData;     
        static BST stockBST;

        public movieSort()
        {
            InitializeComponent();
        }

        #region Populating the list
        private void btnLoad_Click(object sender, EventArgs e)
        {

            //System Io to pick up the file and than we only use the filepath to 
            //Interact with the txt file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            //Filepath
            filePath = ofd.FileName;

            //Reads the txt file
            List<string> lines = File.ReadAllLines(filePath).ToList();



            //Loop will go through the txt file and then split will 
            //split each word which will be stored later in list of string (listHOlder)
            foreach (var line in lines)
            {
                entries = line.Split(',');
                listholder.AddRange(entries);
            }

            //calling the list fuction
            storeData = PopulateMovieList();
            //sorting that list function and sending it to creating a tree
            storeData.Sort();
            stockBST = new BST(storeData);

        }


        //List Class and this is created to populate the class in correct order
        private List<MovieTree> PopulateMovieList()
        {
            List<MovieTree> listnames = new List<MovieTree>();

            //the loop would go through listholder and will use the custom list
            //to properly devide the items.
            for (int i = 0; i < listholder.Count(); i++)
            {
                listnames.Add(new MovieTree(listholder[i], listholder[++i], Convert.ToInt32(listholder[++i]),Convert.ToDouble(listholder[++i]))) ;
            }
              return listnames;
        }
        #endregion

        #region Search / Insert methods

        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            //This  is search field 
            string searchName = txtSearchMovie.Text.ToString();
            //Validation
            if (searchName.Length <= 0)
                MessageBox.Show("Please insert a value in Search Box", "Warning", MessageBoxButtons.OK);
           //Using the search Recursive from the BST class
           var search= stockBST.Search_Recursive(searchName);
              lblSearchResult.Text = Convert.ToString(search);
        }


        private void btnLoadAllMov_Click(object sender, EventArgs e)
        {
            //Using the BreadthFirstTraversal and showing all element
            //in the list.(the idea of method is from Binary Search Tree)
            llbShowAllMovies.Text= stockBST.BreadthFirstTraversal();
        }


        private void btnInsertNewMovie_Click(object sender, EventArgs e)
        {
            //Convrting to string the new values to insert in txt
            string txtMovie = txtNewMovieName.Text.ToString();
            string txtDirectore = txtNewDirectorName.Text.ToString();

            string txtReleaseDate = txtNewReleaseDate.Text.ToString();
            string txtImdb = txtxNewImdb.Text.ToString();

            //Validation to check if field completed
            if (txtMovie.Length <= 0 && txtDirectore.Length <= 0 && txtReleaseDate.Length <= 0 && txtImdb.Length <= 0)
                MessageBox.Show("Please insert a value in Search Box", "Warning", MessageBoxButtons.OK);
            
            string output = $"{txtMovie}, {txtDirectore}, {txtReleaseDate}, {txtImdb}";

            if(listholder.Contains(output))
                MessageBox.Show("Movie is already on the list", "Warning", MessageBoxButtons.OK);

             //adding the new info to the txt
            File.AppendAllText(filePath, output);

        }
        #endregion

        #region Clearing field / close buttons
        private void button8_Click(object sender, EventArgs e)
        {   //Clearing the Textboxes
            llbShowAllMovies.Text = ":";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelNewMov_Click(object sender, EventArgs e)
        {   //Clearing the Textboxes

            txtNewMovieName.Text = "";
            txtNewDirectorName.Text = "";
            txtNewReleaseDate.Text = "";
            txtxNewImdb.Text = "";
        }

        private void btnCancelResearch_Click(object sender, EventArgs e)
        {   //Clearing the Textboxes
            txtSearchMovie.Text = "";
            lblSearchResult.Text = "";
        }
        #endregion
    }
}

