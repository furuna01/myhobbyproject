using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TetorisGame
{
    class CDrawFigure
    {
        /**************************************************************************************************************
         * 機能
         * 初期表示やonPaintイベント発生時に使う。、テトリスの壁やものを描く
         * ***********************************************************************************************************/
        public void DrawBlockOrWall(Graphics graphics, int[,] screen_status)
        {
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {
                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    //壁を描く
                    if(screen_status[i,j] == CONST.BLOCK_STATUS)
                    {
                        DrawFigure(CONST.DISTANCE_TO_SCREEN_WIDTH + CONST.BLOCK_SIZE * j, CONST.DISTANCE_TO_SCREEN_HEIGHT + CONST.BLOCK_SIZE * i
                            , CONST.BLOCK_STATUS, graphics);
                    }
                    else if(screen_status[i,j] == CONST.WALL_STATUS)
                    {
                        DrawFigure(CONST.DISTANCE_TO_SCREEN_WIDTH + CONST.BLOCK_SIZE * j, CONST.DISTANCE_TO_SCREEN_HEIGHT + CONST.BLOCK_SIZE * i
                           , CONST.WALL_STATUS, graphics);
                    }
                    else if(screen_status[i, j] == CONST.NOTHING_STATUS)
                    {
                        DrawFigure(CONST.DISTANCE_TO_SCREEN_WIDTH + CONST.BLOCK_SIZE * j, CONST.DISTANCE_TO_SCREEN_HEIGHT + CONST.BLOCK_SIZE * i
                           , CONST.NOTHING_STATUS, graphics);
                    }
                    else
                    {
                        MessageBox.Show("screen_statusで想定外の値を入れてます");
                    }
                }
            }

        }
        /*************************************************************************************************
         * 機能
         * テトリスミノを描く、タイマイベント発生時にミノが移動したりユーザーがミノを
         * 移動させたときに使う
         * **********************************************************************************************/
        public void DrawBlock(Graphics graphics, int[,] screen_status)
        {
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {
                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    //テトリスミノを描く
                    if (screen_status[i, j] == CONST.BLOCK_STATUS)
                    {
                        DrawFigure(CONST.DISTANCE_TO_SCREEN_WIDTH + CONST.BLOCK_SIZE * j, CONST.DISTANCE_TO_SCREEN_HEIGHT + CONST.BLOCK_SIZE * i
                            , CONST.BLOCK_STATUS, graphics);
                    }
                    else if (screen_status[i, j] == CONST.NOTHING_STATUS)
                    {
                        DrawFigure(CONST.DISTANCE_TO_SCREEN_WIDTH + CONST.BLOCK_SIZE * j, CONST.DISTANCE_TO_SCREEN_HEIGHT + CONST.BLOCK_SIZE * i
                           , CONST.NOTHING_STATUS, graphics);
                    }
                    else if(screen_status[i, j] == CONST.WALL_STATUS)
                    {
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("screen_statusの値がおかしいです、どっかで想定外の値を指定してます");
                    }
                }
            }

        }
        public void DrawFigure(int x, int y, int walltype, Graphics graphics)
        {
            if (walltype == CONST.WALL_STATUS)
            {
                //壁は黒で塗りつぶす
                graphics.FillRectangle(Brushes.Black, x, y, CONST.BLOCK_SIZE, CONST.BLOCK_SIZE);
            }
            else if (walltype == CONST.BLOCK_STATUS)
            {
                //テトリスの図形は赤で塗りつぶす
                graphics.FillRectangle(Brushes.Red, x, y, CONST.BLOCK_SIZE, CONST.BLOCK_SIZE);
            }
            else if (walltype == CONST.NOTHING_STATUS)
            {
                //何もないところは白
                graphics.FillRectangle(Brushes.White, x, y, CONST.BLOCK_SIZE, CONST.BLOCK_SIZE);
            }
            else
            {
                //プログラムで何か悪い値を指定している。
                MessageBox.Show("何か悪い値を指定しています。");
            }

        }
    }
}
