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
        int minoNo = -1;
        int temp_minoNumber = 0;
        int MinoPos = 0;
        int tempMinoPos = 0;
        int[,] tetoris_mino;
        int[,] temp_mino;
        int[,] var_sell_status;
        Boolean flag = false;
        Graphics timer_graphics;
        public CTetorisTimer(int[,] screen_status, TetorisForm form)
        {
            timer_graphics = form.CreateGraphics();
            var_sell_status = form.getScreenStatus();
        }
        public void Run()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(MyClock);
            timer.Interval = 300;
            timer.Enabled = true; // timer.Start()と同じ
        }
        /********************************************************************************************
         * 機能
         * 乱数で7種類のテトリスミノのうち何を発生させるか決めて、タイマが発生するたびに
         * ミノを一つ下げる
         *******************************************************************************************/
        public void MyClock(object sender, EventArgs e)
        {
            CchangeScreen screen = new CchangeScreen();
            CDrawFigure figure = new CDrawFigure();
            /*if (MinoPos == 0 && flag ==false)
            {
                screen.setScreen(CONST.START_MINO_POS, tempMinoPos, var_sell_status, temp_mino, temp_minoNumber);
                return;
            }*/
            if(MinoPos != 0)
            {
                screen.deleteScreen(CONST.START_MINO_POS, tempMinoPos, var_sell_status, temp_mino, temp_minoNumber);
            }
            //１～７の乱数発生
            Random random = new System.Random();
            if (MinoPos == 0)
            {
                minoNo = random.Next(1, 8);   //1から7の乱数を発生して、表示させるミノを決める
                temp_minoNumber = minoNo;
                CLoad_block block = new CLoad_block();
                if (minoNo == 1)
                {
                    tetoris_mino = block.getTetorisMino1();
                    temp_mino = new int[4, 1];
                }
                else if (minoNo == 2)
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
            }
            //MessageBox.Show(minoNo.ToString());

            //ミノが動けるとき画面を表示
            if (screen.checkBlockIsMove(CONST.START_MINO_POS, MinoPos, var_sell_status, tetoris_mino, minoNo))
            {
                //ミノの画面への状態をセット
                screen.setScreen(CONST.START_MINO_POS, MinoPos, var_sell_status, tetoris_mino, minoNo);

                //ミノが移動できるのでミノを描写する
                figure.DrawBlock(timer_graphics, var_sell_status);
                //前の画面の状態を保持
                this.setPreviousScreen(tetoris_mino, temp_mino, minoNo);
                tempMinoPos = MinoPos;
                MinoPos++;

            }
            else
            {
                //ミノが動けない、以前のミノを表示する
                screen.setScreen(CONST.START_MINO_POS, tempMinoPos, var_sell_status, tetoris_mino, minoNo);
                figure.DrawBlock(timer_graphics, var_sell_status);
                MinoPos = 0;
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
        public int[,] getTetorisMino()
        {
            return this.tetoris_mino;
        }
        public int getMinoPos()
        {
            return this.MinoPos;
        }
    }
}
