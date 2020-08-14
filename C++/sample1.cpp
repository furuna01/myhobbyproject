#include <iostream>
#include <string>

using namespace std;

class Neko {
    private:
        string name;
    public:
         Neko(string str) {
            name = str;
        }
        void naku() {
            cout << "Nya! I am a " << name << endl;

        }
};

int main() {
    string str;
    cout << "I'll make a cat. Please enter a cat name!" << endl;
    cin >> str;
    Neko dora(str);
    cout << "There are cat you named on PC memory." << endl;
    cout << "The cat will meow." << endl;
    dora.naku();
}