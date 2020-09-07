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
        private int minoNo = -1;
        private int MinoPos_x = CONST.START_MINO_POS;
        private int MinoPos_y = 0;
        private int direction = 0;
        private int tempMinoPos = 0;
        private int[,,] tetoris_mino;
        private int[,,] temp_mino;
        private int[,] var_sell_status;
        private Graphics timer_graphics;
        public CTetorisTimer(int[,] screen_status, TetorisForm form)
        {
            timer_graphics = form.CreateGraphics();
            var_sell_status = form.getScreenStatus();
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
            CdeleteBlock delete = new CdeleteBlock();
            /*if (MinoPos == 0 && flag ==false)
            {
                screen.setScreen(CONST.START_MINO_POS, tempMinoPos, var_sell_status, temp_mino, temp_minoNumber);
                return;
            }*/
            if(MinoPos_y != 0)
            {
                screen.deleteScreen(MinoPos_x, MinoPos_y - 1, var_sell_status, temp_mino, direction);
            }
            //１～７の乱数発生
            Random random = new System.Random();
            if (MinoPos_y == 0)
            {
                MinoPos_x = CONST.START_MINO_POS;
                minoNo = random.Next(1, 8);   //1から7の乱数を発生して、表示させるミノを決める
                //temp_minoNumber = minoNo;
                CLoad_block block = new CLoad_block();
                if (minoNo == 1)
                {
                    tetoris_mino = block.getTetorisMino1();
                    temp_mino = new int[4, 4, 4];
                }
                else if (minoNo == 2)
                {
                    tetoris_mino = block.getTetorisMino2();
                    temp_mino = new int[4, 4, 4];
                }
                else if (minoNo == 3)
                {
                    tetoris_mino = block.getTetorisMino3();
                    temp_mino = new int[4, 4, 4];
                }
                else if (minoNo == 4)
                {
                    tetoris_mino = block.getTetorisMino4();
                    temp_mino = new int[4, 4, 4];
                }
                else if (minoNo == 5)
                {
                    tetoris_mino = block.getTetorisMino5();
                    temp_mino = new int[4, 4, 4];
                }
                else if (minoNo == 6)
                {
                    tetoris_mino = block.getTetorisMino6();
                    temp_mino = new int[4, 4, 4];
                }
                else if (minoNo == 7)
                {
                    tetoris_mino = block.getTetorisMino7();
                    temp_mino = new int[4, 4, 4];
                }
                else
                {
                    MessageBox.Show("何か想定外の数値が入力されました MyClock");
                    return;
                }
            }
            //MessageBox.Show(minoNo.ToString());

            //ミノが動けるとき画面を表示
            if (screen.checkBlockIsMove(MinoPos_x, MinoPos_y, var_sell_status, tetoris_mino, direction))
            {
                //ミノの画面への状態をセット
                screen.setScreen(MinoPos_x, MinoPos_y, var_sell_status, tetoris_mino, direction);

                //ミノが移動できるのでミノを描写する
                figure.DrawBlock(timer_graphics, var_sell_status);
                //前の画面の状態を保持
                this.setPreviousScreen(tetoris_mino, temp_mino, direction);
                tempMinoPos = MinoPos_y;
                MinoPos_y++;

            }
            else
            {
                //ミノが動けない、以前のミノを表示する
                screen.setScreen(MinoPos_x, MinoPos_y - 1, var_sell_status, tetoris_mino, direction);
                figure.DrawBlock(timer_graphics, var_sell_status);
                //ここに一行そろっていたら消す処理を入れる
                delete.deleteBlock(timer_graphics, var_sell_status);
                MinoPos_y = 0;
            }
        }        
        private void setPreviousScreen(int[,,] previous, int[,,] after, int direction)
        {
            for (int i = 0; i < CONST.MINO_SIZE; i++)
            {
                for (int j = 0; j < CONST.MINO_SIZE; j++)
                {
                    after[direction, i, j] = previous[direction, i, j];
                }
            }
        }
        public void setGraphics(Graphics graphics)
        {
            timer_graphics = graphics;
        }
        public void setMinoNo(int minoNo)
        {
            this.minoNo = minoNo;
        }
        public int getMinoNo()
        {
            return this.minoNo;
        }
        public int[,,] getTetorisMino()
        {
            return this.tetoris_mino;
        }
        public void setMinoPos_x(int minopos_x)
        {
            this.MinoPos_x = minopos_x;
        }
        public int getMinoPos_x()
        {
            return this.MinoPos_x;
        }
        public void setMinoPos_y(int minopos_y)
        {
            this.MinoPos_y = minopos_y;
        }
        public int getMinoPos_y()
        {
            return this.MinoPos_y;
        }
        public void setDirection(int direction)
        {
            this.direction = direction;
        }
        public int getDirection()
        {
            return this.direction;
        }
        public void setTempMino(int[,,] temp_mino)
        {
            this.temp_mino = temp_mino;
        }
        public void setScreenStatus(int[,] screenstatus)
        {
            this.var_sell_status = screenstatus;
        }
        public int[,] getScreenStatus()
        {
            return this.var_sell_status;
        }    
    }
}
