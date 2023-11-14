// Maths.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.

#include <stdio.h>
#include <math.h>
#include <iostream>
#include <stdlib.h>
#include <iomanip>

using namespace std;
//const float a = -2, b = -1, e = 0.001;
const float a = -0.1, b = 0.35, e = 0.001;

float f(float x)
{
    return (x*x*x +3*x*x + 6*x -1);
}

float f1(float x)
{
    return (3*x*x + 6*x +6);
}

float f2(float x)
{
    return (6*x +6);
}
//const float a = -2, b = -1, e = 0.001;
//float f(float x)
//{
//    return (x*x*x -x +1);
//}
//
//float f1(float x)
//{
//    return (3*x*x - 1);
//}
//
//float f2(float x)
//{
//    return (6*x);
//}

float MHord_b(float xn, float k)
{
    return (xn - (f(xn)) / (f(k) - f(xn)) * (k - xn));
}

float MHord_a(float xn, float k)
{
    return (xn - (f(xn)) / (f(xn) - f(k)) * (xn - k));
}

int main()
{
    setlocale(LC_ALL, "Russian");
    float xn, k, x;
    bool stop = false;
    int n = 0;
    cout<<"Интервал ["<<a<<" ; "<<b<<"]"<<endl;
    cout <<"f(a)="<< f(a) << endl;
    cout <<"f(b)="<< f(b) << endl;
    cout<<"f'(a)="<<f1(a)<<endl;
    cout<<"f'(b)="<<f1(b)<< endl;
    cout<<"f''(a)="<<f2(a)<<endl;
    cout<<"f''(b)="<<f2(b)<<endl<<"\n";

    if (f(a) * f2(a) > 0)
    {
        k = b;
        xn = a;
        cout << "xn=a=" << xn << "\n" << "k=b=" << k << "\n" << endl;

        while ((!stop) && (n < 10))
        {
            xn = MHord_b(xn, k);
            if (fabs(k - xn) < e) stop = true;
            n++;
            cout << "n" << n << " = " << xn << endl;
        }
    }
    else
        if (f(b) * f2(b) > 0)
        {
            k = a;
            xn = b;
            cout << "xn=b=" << xn << "\n" << "k=a=" << k << "\n" << endl;

            while ((!stop) && (n < 10))
            {
                xn = MHord_a(xn, k);
                if (fabs(k - xn) < e) stop = true;
                n++;
                cout << "n" << n << " = " << xn << endl;
            }
        }
    cout<<"Ответ: " << setprecision(2) <<xn<<"\n\n\n";
    return 0;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
