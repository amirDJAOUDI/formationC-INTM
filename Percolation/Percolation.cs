using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool _percolate;
        private int[] caseOpen = new int[36];
        private int[] caseFull = new int[36];
        private int k = 0;
        int position = 0;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public Percolation()
        {
        }

        public bool IsOpen(int i, int j)
        {
            // determination de la position de la case:
            if (i == 0)
            {
                position = j--;
            } else { 
                position = (i--) * _size + j--;
            }

            if (caseOpen.Contains(position)) { return true; }

            return false;
        }

        private bool IsFull(int i, int j)
        {
            // determination de la position de la case:
            if (i == 0)
            {
                position = j--;
            }
            else
            {
                position = (i--) * _size + j--;
            }

            if (caseFull.Contains(position)) { return true; }
            return false;
        }

        public bool Percolate()
        {
            // determiner la position de imax et j0
            int positionImaxJ0 = Convert.ToInt32(_size - Math.Sqrt(_size));

            // boucle sur les positions suivantes, si une seul des position est vrais, alors il y'a percolation
            for (int x = positionImaxJ0; x < _size; x++)
            if (caseFull.Contains(position))
            {
                return true;
            }
                return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            return null;
        }

        public void Open(int i, int j)
        {

            IsOutOfRange(i, j);

            if (!IsOpen (i, j))
            {
                // ouverture de la case
                caseOpen[k] = position;

                // remplissage de la case:
                //verfification des positions des voisins: gauche -1/ droite +1/ haut -i/ bas +i
                if (i==0 || caseFull.Contains(position -1 ) || caseFull.Contains(position + 1) || caseFull.Contains(position - i) || caseFull.Contains(position + i))
                {
                    caseFull[k] = position;
                }
            }

        }

        private void IsOutOfRange(int i, int j)
        {
            if( i > _size || j > _size)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
