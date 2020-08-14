#include <iostream>

using namespace std;

int resultSum(int number)
{
    int sum = 0;
    for(int i = 1; i < number; i ++)
    {
        if(number % i == 0)
        {
            sum += i;
        }
    }
    if(number > sum)
    {
        return -1;
    }
    else if(number == sum)
    {
        return 0;
    }
    else
    {
        return 1;
    }
    
}

int main()
{
    int n = 0;
    cout << "Please input the number" << endl;
    cin >> n;

    int less = 0;
    int equal = 0;
    int more = 0;
    for(int i = 1; i <= n; i ++)
    {
        cout << i << endl;
        int fRet = resultSum(i);
        if(fRet == -1)
        {
            less ++;
        }
        else if(fRet == 0)
        {
            equal ++;
        }
        else
        {
            more ++;
        }
    }
    cout << "The number that is small is " << less << endl;
    cout << "The number that is equal is " << equal << endl;
    cout << "The number that is big is " << more << endl;
}