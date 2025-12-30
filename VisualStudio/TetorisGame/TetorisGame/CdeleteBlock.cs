using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TetorisGame
{
    class CdeleteBlock
    {
        int[,] temp_screen_status;

        public CdeleteBlock()
        {
            temp_screen_status = new int[CONST.BLOCK_NUM_HEIGHT, CONST.BLOCK_NUM_WIDTH];
        }
        public void deleteBlock(Graphics graphics, int[,] screen_status)
        {
            CchangeScreen screen = new CchangeScreen();
            CDrawFigure figure = new CDrawFigure();
            int gyoucount = 0;
            int[,] outscreenstatus = new int[CONST.BLOCK_NUM_HEIGHT, CONST.BLOCK_NUM_WIDTH];
            int deletecount = 0;
            screen.SumNonCompeleteGyou(screen_status, outscreenstatus, ref gyoucount, ref deletecount);
            if(deletecount != 0)
            {
                screen.ShowAfterDeletingGyou(screen_status, outscreenstatus, gyoucount);
                figure.DrawBlock(graphics, screen_status);
            }

        }
        public void deleteAllBlock(Graphics graphics, int[,] screen_status)
        {
            for(int i = 1; i < CONST.BLOCK_NUM_HEIGHT - 1; i ++)
            {
                for(int j = 1; j < CONST.BLOCK_NUM_WIDTH - 1; j ++)
                {
                    screen_status[i, j] = CONST.NOTHING_STATUS;
                }
            }
        }
    }
}
