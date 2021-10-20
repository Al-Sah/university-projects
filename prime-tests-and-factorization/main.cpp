#include <iostream>
#include <cmath>
#include <vector>

typedef long long MyType;
using namespace std;


void eratosthenes_sieve(MyType arr[], size_t size) {
    for(int i = 0, j = 2; i < size; ++i, j +=1){
        arr[i] = j;
    }
    int p = 0, k = 0, index = 0;
    double a = sqrt(size);
    while (p < a) {
    for (index; index < size; index) {
        if (arr[index] == 0) {
            index++;
            continue;
        }
        if (arr[index] != 0) {
            p = arr[index];
            k = 0;
            index++;
            break;
        }
    }
    int start = index-1+p;
        for (int i = start; i < size; i) {
            arr[i] = 0;
            i = p + k * p+ start;
            ++k;
        }
    }
}
void out_arr(MyType *arr, size_t size){
    int counter = 0;
    for(int i = 0; i < size; i++) {
        if (arr[i] != 0) {
            ++counter;
            cout << arr[i] << " ";
        }
    }
    cout << "\nвсего простых чисел от 0 до " << size + 1 <<": " << counter << endl;
}

MyType mul(MyType a, MyType  b, MyType m){
    if(b==1)
        return a;
    if(b%2==0){
        long long t = mul(a, b/2, m);
        return (2 * t) % m;
    }
    return (mul(a, b-1, m) + a) % m;
}

MyType pows(MyType a, MyType b, MyType m){
    if(b==0)
        return 1;
    if(b%2==0){
        MyType t = pows(a, b/2, m);
        return mul(t , t, m) % m;
    }
    return ( mul(pows(a, b-1, m) , a, m)) % m;
}

MyType N_O_D(MyType a, MyType b){
    if(b==0)
        return a;
    return N_O_D(b, a % b);
}
MyType N_O_K(MyType a, MyType b) {
    return a / N_O_D(a, b) * b;
}


bool ferma(long long x){
    if(x == 2)
        return true;
    srand(time(NULL));
    for(int i=0;i<100;i++){
        MyType a = (rand() % (x - 2)) + 2;
        if (N_O_D(a, x) != 1)
            return false;
        if( pows(a, x-1, x) != 1)
            return false;
    }

    return true;
}
void factorize_number(MyType x, vector<int> &factorized){
    for (int i = 2; i <= sqrt(x); i++) {
        while (x % i == 0) {
            factorized.push_back(i);
            x /= i;
        }
    }

    if (x != 1) {
        factorized.push_back(x);
    }
}


void input_check(MyType &input_data) {
    MyType a;
    while (!(cin >> a)) {
        cout << "Ошибка ввода, нужен long long" ;
        cin.clear();
        while (cin.get() != '\n');
    }
    input_data = a;
}
void operation_check(int &operation){
    while (!(cin >> operation)) {
        cout << "Ошибка ввода, нужен int\n";
        cin.clear();
        while (cin.get() != '\n');
    }
}
void Help_me(){
    cout << "Start\n";
    cout << "0. Завершить работу\n";
    cout << "1. Тесты простоты\n";
    cout << "2. Факторизация числа\n";
    cout << "3. Найти НОД двух чисел\n";
    cout << "4. Найти НОK двух чисел\n";
}

int main() {
    vector<int> factorized;
    MyType input_data, a,b;


    int operation;
    Help_me();
    do {
         operation_check(operation);

        switch (operation) {
            case 0:
                cout << "\n|--------------------------|";
                cout << "\n|***  Работа завершена  ***|";
                cout << "\n|--------------------------|\n";
                break;
            case 1:
                cout << "1способ. Решето Эратосфена(вывод простых чисел от 2 до n)\n2способ. Тест ферма (ввывод простое/составное)\n";
                int zz;
                operation_check(zz);
                if(zz == 1){
                    cout << "До какого числа выводить: ";
                    input_check(input_data);
                    MyType size = input_data - 1;
                    MyType *arr = new MyType[size];
                    eratosthenes_sieve(arr, size);
                    out_arr(arr, size);
                    delete[] arr;
                }else if(zz == 2){
                    cout << " Введите число: ";
                    input_check(input_data);
                    if(ferma(input_data)){
                        cout << "Число простое\n";
                    }else{
                        cout << "Число составное\n";
                    }
                }else{
                    cout << "Wrong option; ";
                }
                cout << "Введите номер следующей операции: ";
                break;
            case 2:
                cout << " Введите число: ";
                input_check(input_data);
                factorize_number( input_data, factorized);
                for(int i : factorized){
                    cout << i << " ";
                }
                factorized.clear();
                cout << "\nВыполнено\nВведите номер следующей операции: ";
                break;
            case 3:
                cout << "Введите первое число: ";
                input_check(a);
                cout << "Введите второе число: ";
                input_check(b);
                cout << "НОД: " << N_O_D( a, b);
                cout << "\nВведите номер следующей операции: ";
                break;
            case 4:
                cout << "Введите первое число: ";
                input_check(a);
                cout << "Введите второе число: ";
                input_check(b);
                cout << "НОK: " << N_O_K( a, b);
                cout << "\nВведите номер следующей операции: ";
                break;
            default:
                cout << " Error ";
                break;
        }
    } while (operation != 0);
    return 0;
}