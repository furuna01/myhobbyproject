using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
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

        public void IsBlockDeletable(int[,] screen_status, int[] deletableGyou)
        {
            //全列消せないで初期化
            for(int i = 0; i < CONST.BLOCK_NUM_HEIGHT - 2; i ++)
            {
                deletableGyou[i] = 0;
            }
            for(int i = 1; i < CONST.BLOCK_NUM_HEIGHT - 1; i ++)
            {
                int fdeletable = 1;
                for(int j = 1; j < CONST.BLOCK_NUM_WIDTH - 1; j ++)
                {
                    if(screen_status[i, j] == CONST.NOTHING_STATUS)
                    {
                        fdeletable = 0;
                    }
                }
                if(fdeletable == 1)
                {
                    //この行は消せる
                    deletableGyou[i] = 1;
                }

            }
        }
        public void SumNonCompeleteGyou(int[,] screen_status, int[,] outscreenstatus, ref int gyoucount, ref int deletecount)
        {
            int exist_block = 0;
            int exist_complete_gyou = 1;
            int[] temp = new int[CONST.BLOCK_NUM_WIDTH];
            gyoucount = 0;
            deletecount = 0;
            int k = 1;
            int l = 1;
            for (int i = 1; i < CONST.BLOCK_NUM_HEIGHT -1; i ++)
            {
                for(int j = 1; j < CONST.BLOCK_NUM_WIDTH - 1; j ++)
                {
                    temp[j] = screen_status[i, j];
                    if(screen_status[i, j] == CONST.BLOCK_STATUS)
                    {
                        exist_block = 1;
                    }
                    if(screen_status[i, j] == CONST.NOTHING_STATUS)
                    {
                        exist_complete_gyou = 0;
                    }
                }
                if(exist_block == 1 && exist_complete_gyou == 0)
                {
                   for(int j = 1; j < CONST.BLOCK_NUM_WIDTH - 1; j ++)
                   {
                        outscreenstatus[k, l] = temp[j];
                        l++;
                   }
                    l = 1;
                    gyoucount++;
                    k++;
                }
                else if(exist_block == 1 && exist_complete_gyou == 1)
                {
                    deletecount++;
                    //前のブロックの状態を消す
                    for(int j = 1; j < CONST.BLOCK_NUM_WIDTH - 1; j ++)
                    {
                        screen_status[i, j] = CONST.NOTHING_STATUS;
                    }
                }
                /*else
                {
                    for(int j = 1; j < CONST.BLOCK_NUM_WIDTH - 1; j ++)
                    {
                        outscreenstatus[i, j] = CONST.NOTHING_STATUS;
                    }
                }*/
                exist_block = 0;
                exist_complete_gyou = 1;
            }
        }
        public void ShowAfterDeletingGyou(int[,] screen_status, int[,] outscreenstatus, int gyoucount)
        {
            //ミノを消した後の空白の部分の描写
            for(int i = 1; i < ((CONST.BLOCK_NUM_HEIGHT - 1) - gyoucount - 1); i ++)
            {
               for(int j = 1; j < CONST.BLOCK_NUM_WIDTH - 1; j ++)
                {
                    screen_status[i, j] = CONST.NOTHING_STATUS;
                }
            }
            int k = 1;
            int l = 1;
            for(int i = ((CONST.BLOCK_NUM_HEIGHT - 1) - gyoucount); i < CONST.BLOCK_NUM_HEIGHT - 1; i ++)
            {
                for(int j = 1; j < CONST.BLOCK_NUM_WIDTH - 1; j ++)
                {
                    screen_status[i, j] = outscreenstatus[k, l];
                    l++;
                }
                k++;
                l = 1;
            }
        }
    }
}
