using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        char[,] tableOpen = new char[9, 9];
        char[,] tableFull = new char[9, 9];

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;

            tableOpen = new char[size, size];
            tableFull = new char[size, size];

        }

        public bool isPercolation()
        {
            return Percolate();
        }

        public void Open(int i, int j)
        {
            // Ouverture de la case [i,j]
            if (!isOpen(i, j))
            {
                tableOpen[i,j] = 'O';   
            }
            // Remplissage de la case [i,j]
            CloseNeighbors(i, j);   
        }

        public bool Percolate()
        {
            // determiner la position de imax et j0
            int indiceImax = Convert.ToInt32(Math.Sqrt(_size) -1);

            for (int j = 0; j < _size; j++)
            {
                if (isFull(indiceImax, j))
                { return true; } 
            }
            return false;
        }

        public bool isOpen(int i, int j)
        {
            // verifier si la case est ouverte:
            return isEquals(tableOpen[i,j], 'O');
        }

        private bool isFull(int i, int j)
        {
            // verifier si la case est pleine:
            return isEquals(tableFull[i,j], 'F');
        }

        private void CloseNeighbors(int i, int j)
        {
            // deternminer les cases voisines de [i,j]
            // voisin d'en haut [--i,j]
            int k = i - 1;
            if ((k <= 0) || ((k > 0 && isFull(k, j))))
            {
                tableFull[i, j] = 'F';
            }

            // voisin d'en bas [++i,j]
            k = i + 1;
            if (k < _size && isOpen(k, j))
            {
                tableFull[k, j] = 'F';
            }

            // voisin de gauche [i,--j]
            k = j - 1;
            if (k >= 0 && isFull(i, k))
            {
                tableFull[i, j] = 'F';
            }

            // voisin de droite [i,j++]
            k = j + 1;
            if (k < _size && isFull(i, k))
            {
                tableFull[i, j] = 'F';
            }
        }

        private bool isEquals(char tab, char eq)
        {
            if (tab.Equals(eq))
            { return true; }
            else { return false; }
        }
    }
}
