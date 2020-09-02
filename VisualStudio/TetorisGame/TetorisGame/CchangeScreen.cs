using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TetorisGame
{
    class CchangeScreen
    {
        /**********************************************************************************************
         * 機能
         * テトリスミノが移動可能か判定する。移動した先が壁かテトリスのミノがすでに置かれている場所
         * だったらfalseを返し、それ以外はtrueを返す
         * *******************************************************************************************/
        public Boolean checkBlockIsMove(int pos_x, int pos_y, int[,] screen_status, int[,] minoArray, int minoNo)
        {
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {
                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    if (j == pos_x && i == pos_y)
                    {
                        if (minoNo == 1)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                for (int l = 0; l < 1; l++)
                                {
                                    //移動した先が壁か、テトリスミノがすでにあったらfalseを返す
                                    if ((screen_status[i + k, j + l] == CONST.WALL_STATUS || screen_status[i + k, j + l] == CONST.BLOCK_STATUS)
                                         && (minoArray[k, l] == CONST.WALL_STATUS || minoArray[k, l] == CONST.BLOCK_STATUS))
                                    {
                                        return false;
                                    }
                                }
                            }
                            return true;
                        }
                        if (minoNo == 2)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    //移動した先が壁か、テトリスミノがすでにあったらfalseを返す
                                    if ((screen_status[i + k, j + l] == CONST.WALL_STATUS || screen_status[i + k, j + l] == CONST.BLOCK_STATUS)
                                        && (minoArray[k, l] == CONST.WALL_STATUS || minoArray[k, l] == CONST.BLOCK_STATUS))
                                    {
                                        return false;
                                    }
                                }
                            }
                            return true;
                        }
                        else
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                for (int l = 0; l < 3; l++)
                                {
                                    //移動した先が壁か、テトリスミノがすでにあったらfalseを返す
                                    if ((screen_status[i + k, j + l] == CONST.WALL_STATUS || screen_status[i + k, j + l] == CONST.BLOCK_STATUS)
                                        && (minoArray[k, l] == CONST.WALL_STATUS || minoArray[k, l] == CONST.BLOCK_STATUS))
                                    {
                                        return false;
                                    }
                                }
                            }
                            return true;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return true;
        }

        /**********************************************************************************************
         * 機能
         * テトリスミノを画面に表示する
         * *******************************************************************************************/
        public void setScreen(int pos_x, int pos_y, int[,] screen_status, int[,] minoArray, int minoNo)
        {
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {
                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    if (j == pos_x && i == pos_y)
                    {
                        if (minoNo == 1)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                for (int l = 0; l < 1; l++)
                                {
                                    screen_status[i + k, j + l] = minoArray[k, l];
                                }
                            }
                            return;
                        }
                        if (minoNo == 2)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    screen_status[i + k, j + l] = minoArray[k, l];
                                }
                            }
                            return;
                        }
                        else
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                for (int l = 0; l < 3; l++)
                                {
                                    screen_status[i + k, j + l] = minoArray[k, l];
                                }
                            }
                            return;
                        }

                    }
                }
            }
        }
        /*********************************************************************************************************
         * 機能
         * テトリスミノの表示を消す
         * ******************************************************************************************************/
        public void deleteScreen(int pos_x, int pos_y, int[,] screen_status, int[,] minoArray, int minoNo)
        {
            for (int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i++)
            {

                for (int j = 0; j < CONST.BLOCK_NUM_WIDTH; j++)
                {
                    if (j == pos_x && i == pos_y)
                    {
                        if (minoNo == 1)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                for (int l = 0; l < 1; l++)
                                {
                                    if (minoArray[k, l] == CONST.BLOCK_STATUS)
                                    {
                                        screen_status[i + k, j + l] = CONST.NOTHING_STATUS;
                                    }
                                }

                            }
                            return;
                        }
                        else if (minoNo == 2)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    if (minoArray[k, l] == CONST.BLOCK_STATUS)
                                    {
                                        screen_status[i + k, j + l] = CONST.NOTHING_STATUS;
                                    }
                                }
                            }
                            return;
                        }
                        else
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                for (int l = 0; l < 3; l++)
                                {
                                    if (minoArray[k, l] == CONST.BLOCK_STATUS)
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
}
