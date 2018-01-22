#include<iostream>

using namespace std;

class Fraction {

private:

    int num, den;

public:

    Fraction(int n = 1, int d = 2) : num(n), den(d) {}

    void show() { cout << num << "/" << den; }

    Fraction operator+(Fraction f) const { return Fraction(num + f.num, den + f.den); }

    Fraction operator-(Fraction f) const { return Fraction(num - f.num, den - f.den); }

    Fraction operator*(Fraction f) const { return Fraction(num * f.num, den * f.den); }

    Fraction operator/(Fraction f) const {

        int rNum = (f.den * num) / den;

        return (rNum, f.num);

    }

    friend ostream &operator<<(ostream &out, Fraction &f) {
        cout << f.num << "/" << f.den;
        return out;
    }

    friend istream &operator>>(istream &in, Fraction &f) {
        cout << "\nEnter Numerator: ";
        cin >> f.num;
        cout << "Enter Denominator: ";

        cin >> f.den;
        cout << f.num << "/" << f.den;
        return in;
    }

    int ndMax() { return (num <= den) ? num : den; }

    void reduce() {

        for (int i = 2; i <= ndMax(); i++)

            if (num % i == 0 && den % i == 0) {
                num = num / i;
                den = den / i;
                i = 1;
            }

    }

}; //

int main() {

    Fraction f1(5, 6);

    Fraction f2(80, 1001);

    cout << f1 << " and " << f2 << endl;

    Fraction f3 = f1 / f2;

    f3.reduce();
    cout << f3;

    cout << endl;

    return 0;

}