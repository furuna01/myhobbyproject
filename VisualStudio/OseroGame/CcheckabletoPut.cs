using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OseroGame
{
    class CcheckabletoPut
    {
        /*********************************************************************
         * 機能   指定した場所のひっくり返せる石の数を8方向にわたって取得する
         * param
         *      x   調べる場所の深さの座標
         *      y   調べる場所の横の位置
         *      fTeban 　黒番か白番化のフラグ
         *      sellstatus  セルの石が置かれている状況を保存したもの
         *      array_count_num 指定した位置のセルの8方向のひっくり返せる石の数を保存
         ***********************************************************************/
        public Boolean[] CountAbletoPut(int x, int y, int fTeban, int[,] sellstatus, int[] array_count_num)
        {
            Boolean[] flagableput = new Boolean[CONST.DIRECTION_NUMBER];

            for(int i = 0; i < CONST.DIRECTION_NUMBER; i ++)
            {
                array_count_num[i] = 0;
            }
            //自分の上方向にひっくり返せる石がないかチェック
            if(fTeban == 1)
            {
                for(int i = 1; i < CONST.MATH_NUM; i ++ )
                {
                    if (x - i == CONST.MATH_NUM || x - i == -1 ||
                        y == CONST.MATH_NUM || y == -1)
                    {
                        flagableput[0] = false;
                        array_count_num[0] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x - i, y] == CONST.WHITE)
                        {
                            array_count_num[0]++;
                        }
                        else if(sellstatus[x - i, y] == CONST.BLACK)
                        {
                            if (array_count_num[0] > 0)
                            {
                                flagableput[0] = true;
                                break;
                            }else
                            {
                                flagableput[0] = false;
                                break;
                            }
                        }else
                        {
                            flagableput[0] = false;
                            array_count_num[0] = 0;
                            break;
                        }
                    }
                }

                //石が斜め右上で反転できるかどうかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x - i == CONST.MATH_NUM || x - i == -1 ||
                        y + i == CONST.MATH_NUM || y + i == -1)
                    {
                        flagableput[1] = false;
                        array_count_num[1] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x - i, y + i] == CONST.WHITE)
                        {
                            array_count_num[1]++;
                        }
                        else if (sellstatus[x - i, y + i] == CONST.BLACK)
                        {
                            if (array_count_num[1] > 0)
                            {
                                flagableput[1] = true;
                                break;
                            }
                            else
                            {
                                flagableput[1] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[1] = false;
                            array_count_num[1] = 0;
                            break;
                        }
                    }
                }
                //石が右側で反転できるかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x == CONST.MATH_NUM || x == -1 ||
                       y + i == CONST.MATH_NUM || y + i == -1)
                    {
                        flagableput[2] = false;
                        array_count_num[2] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x, y + i] == CONST.WHITE)
                        {
                            array_count_num[2]++;
                        }
                        else if (sellstatus[x, y + i] == CONST.BLACK)
                        {
                            if (array_count_num[2] > 0)
                            {
                                flagableput[2] = true;
                                break;
                            }
                            else
                            {
                                flagableput[2] = false;
                                break;
                            }
                        }
                        else
                        {
                            array_count_num[2] = 0;
                            flagableput[2] = false;
                            break;
                        }
                    }
                }
                //石が右下で反転できるものがないかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x + i == CONST.MATH_NUM || x + i == -1 ||
                       y + i == CONST.MATH_NUM || y + i == -1)
                    {
                        flagableput[3] = false;
                        array_count_num[3] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x + i, y + i] == CONST.WHITE)
                        {
                            array_count_num[3]++;
                        }
                        else if (sellstatus[x + i, y + i] == CONST.BLACK)
                        {
                            if (array_count_num[3] > 0)
                            {
                                flagableput[3] = true;
                                break;
                            }
                            else
                            {
                                flagableput[3] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[3] = false;
                            array_count_num[3] = 0;
                            break;
                        }
                    }
                }
                //石が下側で反転できるかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x + i == CONST.MATH_NUM || x + i == -1 ||
                        y == CONST.MATH_NUM || y == -1)
                    {
                        flagableput[4] = false;
                        array_count_num[4] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x + i, y] == CONST.WHITE)
                        {
                            array_count_num[4]++;
                        }
                        else if (sellstatus[x + i, y] == CONST.BLACK)
                        {
                            if (array_count_num[4] > 0)
                            {
                                flagableput[4] = true;
                                break;
                            }
                            else
                            {
                                flagableput[4] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[4] = false;
                            array_count_num[4] = 0;
                            break;
                        }
                    }
                }
                //石が斜め左下で反転できるかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x + i == CONST.MATH_NUM || x + i == -1 ||
                        y - i == CONST.MATH_NUM || y - i == -1)
                    {
                        flagableput[5] = false;
                        array_count_num[5] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x + i, y - i] == CONST.WHITE)
                        {
                            array_count_num[5]++;
                        }
                        else if (sellstatus[x + i, y - i] == CONST.BLACK)
                        {
                            if (array_count_num[5] > 0)
                            {
                                flagableput[5] = true;
                                break;
                            }
                            else
                            {
                                flagableput[5] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[5] = false;
                            array_count_num[5] = 0;
                            break;
                        }
                    }
                }
                //石が左側で反転できるものがないかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x == CONST.MATH_NUM || x == -1 ||
                        y - i == CONST.MATH_NUM || y - i == -1)
                    {
                        flagableput[6] = false;
                        array_count_num[6] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x, y - i] == CONST.WHITE)
                        {
                            array_count_num[6]++;
                        }
                        else if (sellstatus[x, y - i] == CONST.BLACK)
                        {
                            if (array_count_num[6] > 0)
                            {
                                flagableput[6] = true;
                                break;
                            }
                            else
                            {
                                flagableput[6] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[6] = false;
                            array_count_num[6] = 0;
                            break;
                        }
                    }
                }
                //石が左上側で反転できるものがないかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x - i == CONST.MATH_NUM || x - i == -1 ||
                        y - i == CONST.MATH_NUM || y - i == -1)
                    {
                        flagableput[7] = false;
                        array_count_num[7] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x - i, y - i] == CONST.WHITE)
                        {
                            array_count_num[7]++;
                        }
                        else if (sellstatus[x - i, y - i] == CONST.BLACK)
                        {
                            if (array_count_num[7] > 0)
                            {
                                flagableput[7] = true;
                                break;
                            }
                            else
                            {
                                flagableput[7] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[7] = false;
                            array_count_num[7] = 0;
                            break;
                        }
                    }
                }
            }
            else
            {
                //上方向のひっくり返せる石をチェックする
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x - i == CONST.MATH_NUM || x - i == -1 ||
                        y == CONST.MATH_NUM || y == -1)
                    {
                        flagableput[0] = false;
                        array_count_num[0] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x - i, y] == CONST.BLACK)
                        {
                            array_count_num[0]++;
                        }
                        else if (sellstatus[x - i, y] == CONST.WHITE)
                        {
                            if (array_count_num[0] > 0)
                            {
                                flagableput[0] = true;
                                break;
                            }
                            else
                            {
                                flagableput[0] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[0] = false;
                            array_count_num[0] = 0;
                            break;
                        }
                    }
                }

                //石が斜め右上で反転できるかどうかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x - i == CONST.MATH_NUM || x - i == -1 ||
                        y + i == CONST.MATH_NUM || y + i == -1)
                    {
                        flagableput[1] = false;
                        array_count_num[1] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x - i, y + i] == CONST.BLACK)
                        {
                            array_count_num[1]++;
                        }
                        else if (sellstatus[x - i, y + i] == CONST.WHITE)
                        {
                            if (array_count_num[1] > 0)
                            {
                                flagableput[1] = true;
                                break;
                            }
                            else
                            {
                                flagableput[1] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[1] = false;
                            array_count_num[0] = 0;
                            break;
                        }
                    }
                }
                //石が右側で反転できるかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x == CONST.MATH_NUM || x == -1 ||
                       y + i == CONST.MATH_NUM || y + i == -1)
                    {
                        flagableput[2] = false;
                        array_count_num[2] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x, y + i] == CONST.BLACK)
                        {
                            array_count_num[2]++;
                        }
                        else if (sellstatus[x, y + i] == CONST.WHITE)
                        {
                            if (array_count_num[2] > 0)
                            {
                                flagableput[2] = true;
                                break;
                            }
                            else
                            {
                                flagableput[2] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[2] = false;
                            array_count_num[2] = 0;
                            break;
                        }
                    }
                }
                //石が右下で反転できるものがないかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x + i == CONST.MATH_NUM || x + i == -1 ||
                       y + i == CONST.MATH_NUM || y + i == -1)
                    {
                        flagableput[3] = false;
                        array_count_num[3] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x + i, y + i] == CONST.BLACK)
                        {
                            array_count_num[3]++;
                        }
                        else if (sellstatus[x + i, y + i] == CONST.WHITE)
                        {
                            if (array_count_num[3] > 0)
                            {
                                flagableput[3] = true;
                                break;
                            }
                            else
                            {
                                flagableput[3] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[3] = false;
                            array_count_num[3] = 0;
                            break;
                        }
                    }
                }
                //石が下側で反転できるかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x + i == CONST.MATH_NUM || x + i == -1 ||
                        y == CONST.MATH_NUM || y == -1)
                    {
                        flagableput[4] = false;
                        array_count_num[4] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x + i, y] == CONST.BLACK)
                        {
                            array_count_num[4]++;
                        }
                        else if (sellstatus[x + i, y] == CONST.WHITE)
                        {
                            if (array_count_num[4] > 0)
                            {
                                flagableput[4] = true;
                                break;
                            }
                            else
                            {
                                flagableput[4] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[4] = false;
                            array_count_num[4] = 0;
                            break;
                        }
                    }
                }
                //石が斜め左下で反転できるかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x + i == CONST.MATH_NUM || x + i == -1 ||
                        y - i == CONST.MATH_NUM || y - i == -1)
                    {
                        flagableput[5] = false;
                        array_count_num[5] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x + i, y - i] == CONST.BLACK)
                        {
                            array_count_num[5]++;
                        }
                        else if (sellstatus[x + i, y - i] == CONST.WHITE)
                        {
                            if (array_count_num[5] > 0)
                            {
                                flagableput[5] = true;
                                break;
                            }
                            else
                            {
                                flagableput[5] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[5] = false;
                            array_count_num[5] = 0;
                            break;
                        }
                    }
                }
                //石が左側で反転できるものがないかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x == CONST.MATH_NUM || x == -1 ||
                        y - i == CONST.MATH_NUM || y - i == -1)
                    {
                        flagableput[6] = false;
                        array_count_num[6] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x, y - i] == CONST.BLACK)
                        {
                            array_count_num[6]++;
                        }
                        else if (sellstatus[x, y - i] == CONST.WHITE)
                        {
                            if (array_count_num[6] > 0)
                            {
                                flagableput[6] = true;
                                break;
                            }
                            else
                            {
                                flagableput[6] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[6] = false;
                            array_count_num[6] = 0;
                            break;
                        }
                    }
                }
                //石が左上側で反転できるものがないかチェック
                for (int i = 1; i < CONST.MATH_NUM; i++)
                {
                    if (x - i == CONST.MATH_NUM || x - i == -1 ||
                        y - i == CONST.MATH_NUM || y - i == -1)
                    {
                        flagableput[7] = false;
                        array_count_num[7] = 0;
                        break;
                    }
                    else
                    {
                        if (sellstatus[x - i, y - i] == CONST.BLACK)
                        {
                            array_count_num[7]++;
                        }
                        else if (sellstatus[x - i, y - i] == CONST.WHITE)
                        {
                            if (array_count_num[7] > 0)
                            {
                                flagableput[7] = true;
                                break;
                            }
                            else
                            {
                                flagableput[7] = false;
                                break;
                            }
                        }
                        else
                        {
                            flagableput[7] = false;
                            array_count_num[7] = 0;
                            break;
                        }
                    }
                }
            }
            return flagableput;
        }
        /******************************************************************************************************
         *  機能  オセロ版の一番左上、右上、左下、右下のひっくり返せる石の数を
         *  それぞれの位置で取得し、一番、ひっくり返す数が大きい場所を保存して
         *  返す
         *  param
         *      fTeban              黒番か白番かを保存するフラグ
         *      sellstatus          オセロ版の石の置いてある状態を保存した配列
         *      array_count_num     4隅で一番ひっくり返せる場所の8方向のひっくり返せる数を保存した配列
         *      fable_reverse       4隅で一番ひっくり返せる場所の8方向のひっくり返せるかどうかの真偽を格納した配列
         *      ref pos_x           4隅で一番ひっくり返せる垂直方向の場所
         *      ref pos_y           ４隅で一番ひっくり返せる横方向の場所
         * return
         *      max_num             4隅で一番ひっくり返せる石の数
         *******************************************************************************************************/
        public int ChekcYonsumiIsAvaiable(int fTeban, int[,] sellstatus, int[] array_count_num, Boolean[] fable_reverse, ref int pos_x, ref int pos_y)
        {
            int max_num = 0;
            int[,] yon_array_num = new int[2, 2];
            int[, ,] num_of_yosumi = new int[2, 2, CONST.MATH_NUM];
            Boolean[, ,] flag_of_yousumi = new bool[2, 2, CONST.MATH_NUM];
            Boolean[] fable = new bool[CONST.MATH_NUM - 1];
            //8方向初期化
            for (int i = 0; i < CONST.MATH_NUM - 1; i++)
            {
               array_count_num[i]= 0;
                fable[i] = false;
            }
            //四つの位置初期化
            for(int i = 0; i < 2; i ++)
            {
                for(int j = 0; j < 2; j ++)
                {
                    yon_array_num[i, j] = 0;
                    for(int k = 0; k < CONST.DIRECTION_NUMBER; ++k)
                    {
                        num_of_yosumi[i, j, k] = 0;
                        flag_of_yousumi[i, j, k] = false;
                    }
                }
            }

            //左上の位置
            if (sellstatus[0, 0] == -1)
            {
                fable = CountAbletoPut(0, 0, fTeban, sellstatus, array_count_num);
                if (this.CheckAbleToPut(fable))
                {
                    int sum = 0;
                    for (int i = 0; i < CONST.DIRECTION_NUMBER - 1; i++)
                    {
                        sum += array_count_num[i];
                        num_of_yosumi[0, 0, i] = array_count_num[i];
                        flag_of_yousumi[0, 0, i] = fable[i];

                    }
                    yon_array_num[0, 0] = sum;
                    
                }
                for (int i = 0; i < CONST.DIRECTION_NUMBER; i++)
                {
                    array_count_num[i] = 0;
                    fable[i] = false;
                }
            }
            if(sellstatus[0, CONST.MATH_NUM - 1] == -1)
            {
                //右上の位置
                fable = CountAbletoPut(0, CONST.MATH_NUM - 1, fTeban, sellstatus, array_count_num);
                if (CheckAbleToPut(fable))
                {
                    int sum = 0;
                    for (int i = 0; i < CONST.DIRECTION_NUMBER; i++)
                    {
                        sum += array_count_num[i];
                        num_of_yosumi[0, 1, i] = array_count_num[i];
                        flag_of_yousumi[0, 1, i] = fable[i];
                    }
                    yon_array_num[0, 1] = sum;
                }
                for (int i = 0; i < CONST.DIRECTION_NUMBER; i++)
                {
                    array_count_num[i] = 0;
                    fable[i] = false;
                }
            }
            if(sellstatus[CONST.MATH_NUM - 1, 0] == -1)
            {
                //左下の位置
                fable = CountAbletoPut(CONST.MATH_NUM - 1, 0, fTeban, sellstatus, array_count_num);
                if (CheckAbleToPut(fable))
                {
                    int sum = 0;
                    for (int i = 0; i < CONST.DIRECTION_NUMBER; i++)
                    {
                        sum += array_count_num[i];
                        num_of_yosumi[1, 0, i] = array_count_num[i];
                        flag_of_yousumi[1, 0, i] = fable[i];
                    }
                    yon_array_num[1, 0] = sum;
                }
                for (int i = 0; i < CONST.DIRECTION_NUMBER; i++)
                {
                    array_count_num[i] = 0;
                    fable[i] = false;
                }
            }
            if(sellstatus[CONST.MATH_NUM - 1, CONST.MATH_NUM - 1] == -1)
            {
                fable = CountAbletoPut(CONST.MATH_NUM - 1, CONST.MATH_NUM - 1, fTeban, sellstatus, array_count_num);
                if (CheckAbleToPut(fable))
                {
                    int sum = 0;
                    for (int i = 0; i < CONST.DIRECTION_NUMBER; i++)
                    {
                        sum += array_count_num[i];
                        num_of_yosumi[1, 1, i] = array_count_num[i];
                        flag_of_yousumi[1, 1, i] = fable[i];
                    }
                    yon_array_num[1, 1] = sum;
                }
            }
            //四隅のうち一番ひっくり返せる場所の位置を取得
            max_num = getMaxYosumiNum(yon_array_num, ref pos_x, ref pos_y);
            for(int i = 0; i < CONST.DIRECTION_NUMBER; ++i)
            {
                array_count_num[i] = num_of_yosumi[pos_x, pos_y, i];
                fable_reverse[i] = flag_of_yousumi[pos_x, pos_y, i];
            }
            return max_num;
        }
        /************************************************************************************************************
         * 機能
         * 四隅と端以外でひっくり返せる場所のうち、一番多く意思をひっくり返せる場所とひっくり返せる個数を取得する
         * param
         *      fTeban                  先手か後手かを表すフラグ
         *      sellstatus              オセロ盤上の、石の状態を表す配列
         *      array_count_numq        オセロの盤の四隅でそれぞれの8方向のひっくり返せる石の数の最大数を保存した2×2の配列
         *      f_count_array           オセロの盤の四隅でそれぞれの8方向のひっくり返せるかどうかのフラグを保存した2×2の配列
         *      pos_x                   一番石をひっくり返せる場所のy座標
         *      pos_y                   一番石をひっくり返せる場所のx座標
         * return
         *      max_num                 一番ひっくり返せる場所のひっくり返せる石の個数
         *****************************************************************************************************************/
        public int CountCenterAbaiable(int fTeban, int [,] sellstatus, int [] array_count_num, Boolean [] f_count_array, ref int pos_x, 
            ref int pos_y)
        {
            Boolean[] fable = new Boolean[CONST.DIRECTION_NUMBER];
            int[] able_array = new int[CONST.DIRECTION_NUMBER];
            //x,y のひっくり返せる石の数を保存する
            int[,] result_array = new int[CONST.MATH_NUM, CONST.MATH_NUM];
            int[, , ] local_number = new int[CONST.MATH_NUM, CONST.MATH_NUM, CONST.DIRECTION_NUMBER];
            Boolean[, , ] local_fput = new Boolean[CONST.MATH_NUM, CONST.MATH_NUM, CONST.DIRECTION_NUMBER];

            //パラメータの初期化
            for (int i = 0; i < CONST.DIRECTION_NUMBER - 1; i ++)
            {
                fable[i] = false;
                able_array[i] = 0;
            }
            for (int i = 0; i < CONST.MATH_NUM - 1; i ++)
            {
                for(int j = 0; j < CONST.MATH_NUM - 1; j ++)
                {
                    result_array[i, j] = 0;
                }
            }
            for (int i = 0; i < CONST.MATH_NUM; i ++)
            {
                for(int j = 0; j < CONST.MATH_NUM; j ++)
                {
                    for(int k = 0; k < CONST.DIRECTION_NUMBER - 1; k ++ )
                    {
                        local_number[i, j, k] = 0;
                        local_fput[i, j, k] = false;
                    }
                }
            }
            //四隅と端以外で石をひっくり返す場所をチェックして数え上げる
            for (int i = 0; i < CONST.MATH_NUM; i ++)
            {
                for(int j = 0; j < CONST.MATH_NUM; j ++)
                {
                    //四隅は置ける場所が存在するなら既に置かれているので飛ばす
                    //(1, 1)は飛ばす
                    if(i == 0 && j == 0)
                    {
                        continue;
                    }
                    if(i == 0 && j == CONST.MATH_NUM - 1)
                    {
                        //(1, 8)は飛ばす
                        continue;
                    }
                    if(i == CONST.MATH_NUM - 1 && j == 0)
                    {
                        //(8, 1)は飛ばす
                        continue;
                    }
                    if(i == CONST.MATH_NUM - 1 && j == CONST.MATH_NUM - 1)
                    {
                        //(8, 8)は飛ばす
                        continue;
                    }
                    if(sellstatus[i, j] == -1)
                    {
                        fable = this.CountAbletoPut(i, j, fTeban, sellstatus, able_array);
                    }
                    if (CheckAbleToPut(fable))
                    {
                        int sum = 0;
                        for(int k = 0; k < CONST.DIRECTION_NUMBER; k ++)
                        {
                            local_number[i, j, k] = able_array[k];
                            local_fput[i, j, k] = fable[k];
                            if (able_array[k] > 0)
                            {
                                sum += able_array[k];
                            }
                        }
                        result_array[i, j] = sum;
                        if (sum > 0)
                        {
                            //MessageBox.Show(i.ToString() + "" + j.ToString() + sum.ToString());
                        }
                    }
                }
            }

            //一番石をひっくり返せる場所とひっくり返せる個数、方向でひっくり返すかどうかのフラグ、ひっくり返すを取得する。
            int max_num = getNumAndPos(result_array, ref pos_x, ref pos_y);
            for(int i = 0; i < CONST.DIRECTION_NUMBER; ++i )
            {
                array_count_num[i] = local_number[pos_x, pos_y, i];
                f_count_array[i] = local_fput[pos_x, pos_y, i];
            }
            return max_num;
            
        }
        private int getNumAndPos(int [,] array, ref int pos_x, ref int pos_y)
        {
            int max = 0;
                for (int i = 0; i < CONST.MATH_NUM - 1; i++)
                {
                    for(int j = 0; j < CONST.MATH_NUM - 1; j ++)
                    {
                        if(max < array[i,j])
                        {
                            max = array[i, j];
                        }
                    }
                }


            //一番ひっくり返せる位置を保存
            for (int i = 0; i < CONST.MATH_NUM - 1; i++)
            {
                for (int j = 0; j < CONST.MATH_NUM - 1; j++)
                {
                    if (max == array[i, j])
                    {
                        pos_x = i;
                        pos_y = j;
                        return max;
                    }
                }
            }
            return max;
        }
        //四隅のうち一番石をひっくり返せる場所とひっくり返せる意思の個数を保存
        private int getMaxYosumiNum(int [,] array, ref int pos_x, ref int pos_y)
        {
            int max = 0;
            for(int i = 0; i < 2; i ++)
            {
                for(int j = 0; j < 2; j ++)
                if(max < array[i, j])
                {
                    max = array[i, j];
                }
            }
            
            for(int i = 0; i < 2; i ++)
            {
                for(int j = 0; j < 2; j ++)
                {
                    if(max == array[i, j])
                    {
                        pos_x = i;
                        pos_y = j;
                        return max;
                    }
                }
            }
            return max;
        }
        public Boolean CheckAbleToPut(Boolean[] flagable)
        {
            for(int i = 0; i < CONST.DIRECTION_NUMBER; i ++)
            {
                if(flagable[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
