using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetorisGame
{
    class CLoad_block
    {
        private int[,] tetoris_mino1;
        private int[,] tetoris_mino2;
        private int[,] tetoris_mino3;
        private int[,] tetoris_mino4;
        private int[,] tetoris_mino5;
        private int[,] tetoris_mino6;
        private int[,] tetoris_mino7;

        public CLoad_block()
        {
            //■
            //■
            //■
            //■
            tetoris_mino1 = new int[4, 1];
            //■■
            //■■
            tetoris_mino2 = new int[2, 2];
            //　■■
            //■■
            tetoris_mino3 = new int[2, 3];
            //■■
            //　■■
            tetoris_mino4 = new int[2, 3];
            //■
            //■■■
            tetoris_mino5 = new int[2, 3];
            //   ■
            //■■■
            tetoris_mino6 = new int[2, 3];
            //  ■
            //■■■
            tetoris_mino7 = new int[2, 3];
        }

        public Boolean LoadCsv(int minotype)
        {
            try
            {
                StreamReader reader;
                int retu_number = 0;
                if(minotype == 1)
                {
                    reader = new StreamReader("mino1.csv");
                    retu_number = 4;
                }
                else if(minotype == 2)
                {
                    reader = new StreamReader("mino2.csv");
                    retu_number = 2;
                }
                else if(minotype == 3)
                {
                    reader = new StreamReader("mino3.csv");
                    retu_number = 2;
                }
                else if(minotype == 4)
                {
                    reader = new StreamReader("mino4.csv");
                    retu_number = 2;
                }
                else if(minotype == 5)
                {
                    reader = new StreamReader("mino5.csv");
                    retu_number = 2;
                }
                else if(minotype == 6)
                {
                    reader = new StreamReader("mino6.csv");
                    retu_number = 2;
                }
                else if(minotype == 7)
                {
                    reader = new StreamReader("mino7.csv");
                    retu_number = 2;
                }
                else
                {
                    MessageBox.Show("不正な値が渡されました LoadCsv");
                    return false;
                }
                int i = 0;
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] value = line.Split(',');
                    for(int j = 0; j < retu_number; j ++)
                    {
                        if(minotype == 1)
                        {
                            tetoris_mino1[i, j] = int.Parse(value[j]);
                        }
                        else if(minotype == 2)
                        {
                            tetoris_mino2[i, j] = int.Parse(value[j]);
                        }
                        else if(minotype == 3)
                        {
                            tetoris_mino3[i, j] = int.Parse(value[j]);
                        }
                        else if(minotype == 4)
                        {
                            tetoris_mino4[i, j] = int.Parse(value[j]);
                        }
                        else if (minotype == 5)
                        {
                            tetoris_mino5[i, j] = int.Parse(value[j]);
                        }
                        else if (minotype == 6)
                        {
                            tetoris_mino6[i, j] = int.Parse(value[j]);
                        }
                        else if (minotype == 7)
                        {
                            tetoris_mino7[i, j] = int.Parse(value[j]);
                        }
                    }
                    i++;
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString() + "ファイルの読み込みに失敗したか、不適切なデータを読み込みました。");
                return false;
            }
        }
        public int[,] getTetorisMino1()
        {
            return this.tetoris_mino1;
        }
        public int[,] getTetorisMino2()
        {
            return this.tetoris_mino2;
        }
        public int[,] getTetorisMino3()
        {
            return this.tetoris_mino3;
        }
        public int[,] getTetorisMino4()
        {
            return this.tetoris_mino4;
        }
        public int[,] getTetorisMino5()
        {
            return this.tetoris_mino5;
        }
        public int[,] getTetorisMino6()
        {
            return this.tetoris_mino6;
        }
        public int[,] getTetorisMino7()
        {
            return this.tetoris_mino7;
        }
    }
}
