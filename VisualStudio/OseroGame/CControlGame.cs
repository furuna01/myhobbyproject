using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OseroGame
{
    class CControlGame
    {
        /****************************************************************************************
         *  機能
         *  すべてのボードの石が黒かどうか判定する
         *  *************************************************************************************/
        private Boolean checkAllisBlack(int[,] sell_status)
        {
            for (int i = 0; i < CONST.MATH_NUM; ++i)
            {
                for (int j = 0; j < CONST.MATH_NUM; ++j)
                {
                    if(sell_status[i, j] == CONST.WHITE)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /*****************************************************************************************
         *  機能
         *  すべてのボードの石が白かどうか判定する
         *  **************************************************************************************/
        private Boolean checkAllisWhite(int[,] sell_status)
        {
            for (int i = 0; i < CONST.MATH_NUM; ++i)
            {
                for (int j = 0; j < CONST.MATH_NUM; ++j)
                {
                    if (sell_status[i, j] == CONST.BLACK)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /*******************************************************************************************
         * 機能
         * ボードの黒石と白石の数を数える
         * ****************************************************************************************/
        public void countAllBlockAndWhiteStone(int[,] sell_status, ref int black_num, ref int white_num)
        {
            black_num = 0;
            white_num = 0;

            for(int i = 0; i < CONST.MATH_NUM; ++i)
            {
                for(int j = 0; j < CONST.MATH_NUM; ++j)
                {
                    if(sell_status[i, j] == CONST.BLACK)
                    {
                        black_num ++;
                    }
                    else if(sell_status[i, j] == CONST.WHITE)
                    {
                        white_num++;
                    }
                }
            }
        }
        /********************************************************************************************
         *  機能
         *  ボード全体を見てひっくり返せる石があるかどうかチェックする
         *  返り値
         *      ひっくり返せる石がある true
         *      ひっくり返せる石がない false
         *  *****************************************************************************************/
         public Boolean checkAllAbletoReverse(int[,] sell_status, int fTeban)
        {
            int[] result_array = new int[CONST.DIRECTION_NUMBER];
            Boolean[] result_flag = new bool[CONST.DIRECTION_NUMBER];
            CcheckabletoPut able = new CcheckabletoPut();

            for(int i = 0; i < CONST.MATH_NUM; ++i)
            {
                for(int j = 0; j < CONST.MATH_NUM; ++j)
                {
                    if(sell_status[i,j] == -1)
                    {
                        result_flag = able.CountAbletoPut(i, j, fTeban, sell_status, result_array);
                        if (able.CheckAbleToPut(result_flag))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return false;
        }

        /*******************************************************************************************
         *  機能
         *  全部石が置かれているかチェックする
         *  ****************************************************************************************/
        private Boolean checkAbleToPut(int[,] sell_status)
        {
            for(int i = 0; i < CONST.MATH_NUM; ++i)
            {
                for(int j = 0; j < CONST.MATH_NUM; ++j)
                {
                    if(sell_status[i, j] == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
