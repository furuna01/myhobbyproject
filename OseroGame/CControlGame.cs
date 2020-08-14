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
        private void countAllBlockAndWhiteStone(int[,] sell_status, ref int black_num, ref int white_num)
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
         *  *****************************************************************************************/
         private Boolean checkAllAbletoReverse(int[,] sell_status, int fTeban)
        {
            int[] result_array = new int[CONST.DIRECTION_NUMBER];
            Boolean[] result_flag = new bool[CONST.DIRECTION_NUMBER];
            CcheckabletoPut able = new CcheckabletoPut();

            for(int i = 0; i < CONST.MATH_NUM; ++i)
            {
                for(int j = 0; j < CONST.MATH_NUM; ++j)
                {
                    result_flag = able.CountAbletoPut(i, j, fTeban, sell_status, result_array);
                    if(able.CheckAbleToPut(result_flag))
                    {
                        return true;
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
        /********************************************************************************************
         * 機能
         * ゲームの終了判定を行って、終わりの時勝ち負けの結果と、黒石と白石の数を提示する
         * ******************************************************************************************/
        public Boolean showGameResult(int[,] sell_status, int fTeban)
        {
            if(this.checkAllisBlack(sell_status))
            {
                //すべて黒なのでゲームを終了して黒の勝ちであることと石の数を表示する
                int black_num = 0;
                int white_num = 0;
                this.countAllBlockAndWhiteStone(sell_status, ref black_num, ref white_num);
                MessageBox.Show("黒の勝ちです。黒石の個数: " + black_num.ToString());
                return true;
            }
            if(this.checkAllisWhite(sell_status))
            {
                //すべて白なのでゲームを終了して白の勝ちであることと石の数を表示する
                int black_num = 0;
                int white_num = 0;
                this.countAllBlockAndWhiteStone(sell_status, ref black_num, ref white_num);
                MessageBox.Show("白の勝ちです。白石の個数: " + white_num.ToString());
                return true;
            }
            if(this.checkAbleToPut(sell_status))
            {
                int black_num = 0;
                int white_num = 0;
                this.countAllBlockAndWhiteStone(sell_status, ref black_num, ref white_num);
                if(black_num > white_num)
                {
                    MessageBox.Show("黒の勝ちです。黒石の個数: " + black_num.ToString() + " 白石の個数: " + white_num.ToString());
                }else if(black_num == white_num)
                {
                    MessageBox.Show("引き分けです。黒石の個数: " + black_num.ToString() + " 白石の個数: " + white_num.ToString());
                }else
                {
                    MessageBox.Show("白の勝ちです。黒石の個数: " + black_num.ToString() + " 白石の個数: " + white_num.ToString());
                }
                return true;
            }
            if(!(this.checkAllAbletoReverse(sell_status, fTeban)))
            {
                int black_num = 0;
                int white_num = 0;
                this.countAllBlockAndWhiteStone(sell_status, ref black_num, ref white_num);
                if (black_num > white_num)
                {
                    MessageBox.Show("黒の勝ちです。黒石の個数: " + black_num.ToString() + " 白石の個数: " + white_num.ToString());
                }
                else if (black_num == white_num)
                {
                    MessageBox.Show("引き分けです。黒石の個数: " + black_num.ToString() + " 白石の個数: " + white_num.ToString());
                }
                else
                {
                    MessageBox.Show("白の勝ちです。黒石の個数: " + black_num.ToString() + " 白石の個数: " + white_num.ToString());
                }
                return true;
            }
            return false;
        }
    }
}
