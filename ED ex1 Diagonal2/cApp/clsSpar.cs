using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cApp
{
    public class clsSpar
    {
        /*ATRIBUTOS*/

        const int Max = 1000;                          // Cantidad de filas del arreglo SP Sparce
        public int[,] SP = new int[Max, 3];            // Arreglo donde se almacena los datos de las Matris  original
        public int Cant = 0;                           // Cantidad de celdas llenas en el  arreglo SP Sparce
        public int m = 0;                             // Cantidad de columnas de la Matriz original
        public int n = 0;                             // Cantidad de filas de la Matriz original


        /*CONSTRUCTORES*/
        public clsSpar()
        {
            Cant = 0; n = 0; m = 0;
            int i = 0;
            while (i < Max)
            {
                SP[i, 0] = 0; SP[i, 1] = 0; SP[i, 2] = 0;
                i++;
            }
        }

        public clsSpar(clsSpar x)
        {
            Cant = x.Cant; n = x.n; m = x.m;
            int i = 0;
            while (i < Max)
            {
                SP[i, 0] = x.SP[i, 0]; SP[i, 1] = x.SP[i, 1]; SP[i, 2] = x.SP[i, 2];
                i++;
            }
        }

        // Limpiar el Arreglo SP
        public void ClearArreglo()
        {
            int i = 0; Cant = 0;
            while (i < Max)
            {
                SP[i, 0] = 0; SP[i, 1] = 0; SP[i, 2] = 0;
                i++;
            }
        }

        // Funcion para mostrar la Matriz A
        public string MostraArreglo(int[,] A)
        {
            int i, j = 0;
            string cad = "";
            for (i = 0; i < n; i++)
            {
                cad += "\n";
                for (j = 0; j < m; j++)
                    cad += "[" + A[i, j] + "]";
            }
            return cad;
        }



        // Funcion para mostrar arreglo Spar V(t,3)
        public string MostrarVector()
        {
            string cad = "";

            for (int i = 0; i < Cant; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cad += " [" + SP[i, j] + "]";
                }
                cad += "\n";
            }
            return cad;
        }

        // Aqui escriba el codigo de la funciones
        /*Sparce(A) --> SP 
         * Copia los elementos de una matriz A con números 
        naturales distintos de 0 a un arreglo Sparce SP.*/
        public clsSpar Sparce(int[,] A)
        {
            n = A.GetLength(0); //fila
            m = A.GetLength(1); //cola
            SP[Cant, 0] = n;//filas
            SP[Cant, 1] = m;//columnas
            Cant = 1;
            for (int i = 0; i < n; i++)//filas
            {
                for (int j = 0; j < m; j++)//columnas
                {
                    if (A[i, j] != 0)
                    {
                        SP[Cant, 0] = i;
                        SP[Cant, 1] = j;
                        SP[Cant, 2] = A[i, j];
                        Cant++;
                    }
                }
            }
            Cant--;
            SP[0, 2] = Cant;
            return this;
        }

        public int getvalor(int f, int c, clsSpar SP)
        {
            int valor = 0;
            for(int i = 1; i <= SP.Cant; i++)
            {
                if(SP.SP[i,0]==f && SP.SP[i,1]==c)
                {
                    valor = SP.SP[i, 2];
                }
            }

            return valor;
        }

        //Diagonal2(SP)-- > Q

        public clsCola Diagonal2(clsSpar SP)
        {   // n filas
            // m columnas
            clsCola Q = new clsCola();
            int i = 0;
            int j = SP.m - 1;
           
            while(j>=0 && i < SP.n)
            {
                if (getvalor(i, j, SP) != 0)
                {
                    Q.Add(getvalor(i, j, SP));
                }
                j--;
                i++;
            }


            return Q;
        }
    }

}


