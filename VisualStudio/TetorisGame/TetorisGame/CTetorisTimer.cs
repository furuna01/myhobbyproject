using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetorisGame
{
    class CTetorisTimer
    {
        int temp_minoNumber = 0;
        int[,] temp_mino;
        int[,] var_sell_status;
        Graphics timer_graphics;
        public CTetorisTimer(int[,] sell_status)
        {
            for(int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i ++)
            {
                for(int j = 0; j < CONST.BLOCK_NUM_WIDTH; j ++)
                {
                    var_sell_status[i, j] = sell_status[i, j];
                }
            }
        }
        public void Run()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(MyClock);
            timer.Interval = 1000;
            timer.Enabled = true; // timer.Start()と同じ
        }
        /********************************************************************************************
         * 機能
         * 乱数で7種類のテトリスミノのうち何を発生させるか決めて、タイマが発生するたびに
         * ミノを一つ下げる
         *******************************************************************************************/
        public void MyClock(object sender, EventArgs e)
        {
            //前の表示をクリア

            //１～７の乱数発生
            Random random = new System.Random();

            int minoNo = random.Next(1, 8);   //1から7
            //MessageBox.Show(minoNo.ToString());
            temp_minoNumber = minoNo;
            int[,] tetoris_mino;
            CLoad_block block = new CLoad_block();
            block.LoadCsv(minoNo);
            if(minoNo == 1)
            {
                tetoris_mino = block.getTetorisMino1();
                temp_mino = new int[4, 1];
            }
            else if(minoNo == 2)
            {
                tetoris_mino = block.getTetorisMino2();
                temp_mino = new int[2, 2];
            }
            else if (minoNo == 3)
            {
                tetoris_mino = block.getTetorisMino3();
                temp_mino = new int[2, 3];
            }
            else if (minoNo == 4)
            {
                tetoris_mino = block.getTetorisMino4();
                temp_mino = new int[2, 3];
            }
            else if (minoNo == 5)
            {
                tetoris_mino = block.getTetorisMino5();
                temp_mino = new int[2, 3];
            }
            else if (minoNo == 6)
            {
                tetoris_mino = block.getTetorisMino6();
                temp_mino = new int[2, 3];
            }
            else if (minoNo == 7)
            {
                tetoris_mino = block.getTetorisMino7();
                temp_mino = new int[2, 3];
            }
            else
            {
                MessageBox.Show("何か想定外の数値が入力されました MyClock");
                return;
            }
            //画面を表示

            //前の画面の状態を保持
            this.setPreviousScreen(tetoris_mino, temp_mino, minoNo);
            

        }
        private void setScreen(int pos_x, int pos_y, int[,] minoArray, int minoNo)
        {
            for(int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i ++)
            {
                for(int j = 0; j < CONST.BLOCK_NUM_WIDTH; j ++)
                {
                    if(j == pos_x && i == pos_y)
                    {
                        if(minoNo == 1)
                        {

                        }
                    }

                }
            }
        }
        private void setPreviousScreen(int[,] previous, int[,] after, int minoNo)
        {
            if(minoNo == 1)
            {
                for(int i = 0; i < 4; i ++)
                {
                    for(int j = 0; j < 1; j ++)
                    {
                        after[i, j] = previous[i, j];
                    }
                }
            }
            else if(minoNo == 2)
            {
                for(int i = 0; i < 2; i ++)
                {
                    for(int j = 0; j < 2; j ++)
                    {
                        after[i, j] = previous[i, j];
                    }
                }
            }
            else
            {
                for(int i = 0; i < 2; i ++)
                {
                    for(int j = 0; j < 3; j ++)
                    {
                        after[i, j] = previous[i, j];
                    }
                }
            }

        }
        public void setGraphics(Graphics graphics)
        {
            timer_graphics = graphics;
        }
    }
}
