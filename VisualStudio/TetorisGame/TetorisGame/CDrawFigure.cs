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
        public void DrawBlockOrWall(int x, int y, Graphics graphics, int[,] screen_status)
        {
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {
                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    //壁を描く
                    if(screen_status[i,j] == CONST.BLOCK_STATUS)
                    {
                        DrawBlock(x, y, CONST.BLOCK_STATUS, graphics);
                    }
                    else if(screen_status[i,j] == CONST.WALL_STATUS)
                    {
                        DrawBlock(x, y, CONST.WALL_STATUS, graphics);
                    }
                    else if(screen_status[i, j] == CONST.NOTHING_STATUS)
                    {
                        DrawBlock(x, y, CONST.NOTHING_STATUS, graphics);
                    }
                    else
                    {
                        MessageBox.Show("何か悪い値を指定してます");
                    }
                }
            }

        }
        public void DrawBlock(int x, int y, int walltype, Graphics graphics)
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
