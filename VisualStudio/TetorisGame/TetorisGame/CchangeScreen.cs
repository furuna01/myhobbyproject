using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetorisGame
{
    class CchangeScreen
    {
        /**********************************************************************************************
         * 機能
         * テトリスミノが移動可能か判定する。移動した先が壁かテトリスのミノがすでに置かれている場所
         * だったらfalseを返し、それ以外はtrueを返す
         * *******************************************************************************************/
        public Boolean checkBlockIsMove(int pos_x, int pos_y, int[,] screen_status, int[,,] minoArray, int direction)
        {
            if(direction < 0 || direction > 3)
            {
                MessageBox.Show("ミノの方向を表す変数の値がおかしいです");
            }
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {
                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    if (j == pos_x && i == pos_y)
                    {

                        for (int k = 0; k < CONST.MINO_SIZE; k++)
                        {
                            for (int l = 0; l < CONST.MINO_SIZE; l++)
                            {
                                //移動した先が壁か、テトリスミノがすでにあったらfalseを返す
                                if ((screen_status[i + k, j + l] == CONST.WALL_STATUS || screen_status[i + k, j + l] == CONST.BLOCK_STATUS)
                                     && (minoArray[direction, k, l] == CONST.WALL_STATUS || minoArray[direction, k, l] == CONST.BLOCK_STATUS))
                                {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            return true;
        }

        /**********************************************************************************************
         * 機能
         * テトリスミノを画面に表示する
         * *******************************************************************************************/
        public void setScreen(int pos_x, int pos_y, int[,] screen_status, int[,,] minoArray, int direction)
        {
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {
                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    if (j == pos_x && i == pos_y)
                    {
                        for (int k = 0; k < CONST.MINO_SIZE; k++)
                        {
                            for (int l = 0; l < CONST.MINO_SIZE; l++)
                            {
                                if (screen_status[i + k, j + l] == CONST.BLOCK_STATUS && minoArray[direction, k, l] == CONST.NOTHING_STATUS)
                                {
                                    screen_status[i + k, j + l] = CONST.BLOCK_STATUS;
                                }
                                else if(screen_status[i + k, j + l] == CONST.WALL_STATUS && minoArray[direction, k, l] ==CONST.NOTHING_STATUS)
                                {
                                    screen_status[i + k, j + l] = CONST.WALL_STATUS;
                                }
                                else
                                {
                                    screen_status[i + k, j + l] = minoArray[direction, k, l];
                                }
                            }
                        }
                        return;
                    }


                }
            }
        }
        /*********************************************************************************************************
         * 機能
         * テトリスミノの表示を消す
         * ******************************************************************************************************/
        public void deleteScreen(int pos_x, int pos_y, int[,] screen_status, int[,,] minoArray, int direction)
        {
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {

                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    if (j == pos_x && i == pos_y)
                    {
                        for (int k = 0; k < CONST.MINO_SIZE; k++)
                        {
                            for (int l = 0; l < CONST.MINO_SIZE; l++)
                            {
                                if (minoArray[direction, k, l] == CONST.BLOCK_STATUS)
                                {
                                    screen_status[i + k, j + l] = CONST.NOTHING_STATUS;
                                }
                            }

                        }
                        return;
                    }
                }

            }
        }
    }
}
