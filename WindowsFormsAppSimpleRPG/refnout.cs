using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSimpleRPG
{
    public partial class refnout : Form
    {
        int num;
        int[] arr1 = new int[10];
        int[] arr2;
        public refnout()
        {
            InitializeComponent();
            setArray(ref arr1);
            //num=int.Parse(Console.ReadLine());
            setArray2(out arr2,arr2.Length);
        }
        void setArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i+1;
            }
        }
        void setArray2(out int[] arr,int size)
        {
            arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
        }
    }
}