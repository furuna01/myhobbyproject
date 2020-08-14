#include <iostream>
#include <math.h>
#include <fstream>

using namespace std;

bool isPrime(int number)
{
    for(int i = 2; i <= sqrt(number) + 1; i ++)
    {
        if(number % i == 0)
        {
            return false;
        }
    }
    return true;
}

int main()
{
    ofstream ofs("./temp.txt");
    if(!ofs)
    {
        cout << "We can't open the file" << endl;
        return 0;
    }
    int n = 0;

    cout << "Please input the number" << endl;
    cin >> n;

    for(int i = 2; i <= n; i ++)
    {
        cout << i << endl;
        float sum = 0;
        for(int j = 2; j <= i; j ++)
        {
            if(j == 2)
            {
                sum ++;
            }
            if(isPrime(j))
            {
                sum ++;
            }
        }
        ofs << sum / i << endl;
    }
}