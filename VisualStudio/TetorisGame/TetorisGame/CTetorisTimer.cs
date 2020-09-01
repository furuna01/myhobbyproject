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
        List<int[,]> tetoris_mino_array;
        int[,] tetoris_mino;
        int[,] temp_mino;
        int[,] var_sell_status;
        int flag = 0;
        TetorisForm var_form;
        Graphics timer_graphics;
        public CTetorisTimer(int[,] screen_status, TetorisForm form)
        {
            var_sell_status = new int[CONST.BLOCK_NUM_HEIGHT, CONST.BLOCK_NUM_WIDTH];
            for(int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i ++)
            {
                for(int j = 0; j < CONST.BLOCK_NUM_WIDTH; j ++)
                {
                    var_sell_status[i, j] = screen_status[i, j];
                }
            }
            tetoris_mino_array = new List<int[,]>();
            var_form = form;
            timer_graphics = var_form.CreateGraphics();
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
            CchangeScreen screen = new CchangeScreen();
            CDrawFigure figure = new CDrawFigure();
            //前の表示をクリア
            if (MinoPos != 0 && flag == 0)
            {
                screen.deleteScreen(CONST.START_MINO_POS, tempMinoPos, var_sell_status, temp_mino, temp_minoNumber);
            }
            //１～７の乱数発生
            Random random = new System.Random();
            if (MinoPos == 0)
            {
                minoNo = random.Next(1, 8);   //1から7の乱数を発生して、表示させるミノを決める
                temp_minoNumber = minoNo;
            }
            //MessageBox.Show(minoNo.ToString());
            CLoad_block block = new CLoad_block();
            block.LoadCsv(minoNo);
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
            tetoris_mino_array.Add(tetoris_mino);
            //ミノが動けるとき画面を表示
            if(screen.checkBlockIsMove(CONST.START_MINO_POS, MinoPos, var_sell_status, tetoris_mino, minoNo))
            {
                //ミノの画面への状態をセット
                screen.setScreen(CONST.START_MINO_POS, MinoPos, var_sell_status, tetoris_mino, minoNo);

                //ミノが移動できるのでミノを描写する
                figure.DrawBlock(timer_graphics, var_sell_status);
                flag = 0;

            }
            else
            {
                //ミノが動けない、次のミノを表示する
                MinoPos = 0;
                flag = 1;
            }
            //前の画面の状態を保持
            this.setPreviousScreen(tetoris_mino, temp_mino, minoNo);
            tempMinoPos = MinoPos;
            MinoPos++;

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
