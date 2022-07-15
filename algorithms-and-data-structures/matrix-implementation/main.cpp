#include <iostream>
#include <iomanip>
#include <fstream>


//33. Предметна область: «Матриця довільної розмірності» (транспонування матриці).

/*
       Данная задача была решена двумя способами
       1) jagged array - массив массивов (память выделяется в разных местах памяти)
          Результат - класс Matrix
       2) создаётся одномерный  массив размером rows * cols (память выделена в одном месте),
        после чего сводится к двумерному при помощи магии)
         Результат - класс Matrix1

         По скольку элементы каждого из вариантов в памяти хранятся по разному,
         требуются разные способы взаимодействия с ними, но сами алгоритмы не меняются
*/

/*
    Обход всех элементов матрицы
    for(int y = 0;y<rows;y++){
        for(int x = 0;x<cols;x++){
        }
    }
 */
std::ifstream Matrix_in("Matrix_in.txt");
std::ofstream Matrix_out("Matrix_out.txt");

class Matrix{

    int rows, cols;
    int **matrix_pointer; //указатель на что то (динамическую память)


public:


    //Констуктор
    Matrix(int ox, int oy) {
        this->rows = oy;
        this->cols =ox;

        //Создание массива массивов в динамической памяти
        this->matrix_pointer = new int* [rows];
        for (int i = 0; i < rows; ++i ) {
            matrix_pointer[i] = new int[cols];
        }
        std::cout << "Создание матрицы на " << cols * rows << " элементов [ " << this << " ]\n";
    }

    //перегрузка конструктора копирования
    Matrix(const Matrix & matrix){
        this->rows = matrix.rows;
        this->cols = matrix.cols;

        this->matrix_pointer = new int* [rows];
        for (int i = 0; i < rows; ++i ) {
            matrix_pointer[i] = new int[cols];
        }

        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                //Поэлементное копирование
                this->matrix_pointer[y][x] = matrix.matrix_pointer[y][x];
            }
        }
        std::cout << "Создание матрицы [ " << this << " ] на " << cols * rows
                  << " элементов из [ " << matrix.matrix_pointer << " ]\n";
    }


    //деструктор
    ~Matrix() {
        //Описано удаление массива массивов
        for(int i = 0; i < rows; ++i){
            delete [] matrix_pointer[i];
        }
        std::cout << "\nУдаление матрицы на " << cols * rows
                  << " элементов [ " << this << " " << matrix_pointer << " ]";

        delete [] matrix_pointer;
    }


    //Рандомное заполнение всех элементов матрицы
    void fill_randomly(int range = 100){
        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                matrix_pointer[y][x] = rand()%range - range/4;
            }
        }
    }

    void print(int set_w = 4){
        std::cout << "\nprint_matrix ["<< rows << ":"<< cols <<"] \n";
        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                std::cout << std::setw(set_w) /*красивый вывод*/ << matrix_pointer[y][x] << " ";
            }
            std::cout << std::endl;
        }
    }

    //транспонирование матрицы
    // Происходит замена старой матрицы на созданую новую
    void transpose(){
        auto *new_matrix = new Matrix( this->rows, this->cols);
        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                //Транспонирование
                new_matrix->matrix_pointer[x][y] = matrix_pointer[y][x];
            }
        }
        this->rows = new_matrix->rows;
        this->cols = new_matrix->cols;
        for(int i = 0; i < rows; ++i){
            delete matrix_pointer[i];
        } // Удаление старых элементов
        delete [] this->matrix_pointer;
        this->matrix_pointer = new_matrix->matrix_pointer;
    }

    // Перегрузка оператора *
    Matrix operator * (const Matrix& matrix1){
        // Обработка некорректрных данных
        if(this->rows != matrix1.cols){
            throw  "Multiply ERROR: this->rows != matrix1.cols";
        }
        auto *new_matrix = new Matrix( matrix1.cols, this->rows);

        //Алгоритм перемножения
        for (int i = 0; i < rows; i++){
            for (int j = 0; j < matrix1.cols; j++){
                new_matrix->matrix_pointer[i][j] = 0;
                for (int k = 0; k < cols; k++) {
                    new_matrix->matrix_pointer[i][j] += this->matrix_pointer[i][k] * matrix1.matrix_pointer[k][j];
                }
            }
        }
        // Результатом операции перемножения матриц является новая матрица
        return *new_matrix;
    }

    void multiply_by_number(int number){
        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                // Умножение каждого элемента на число
                matrix_pointer[y][x] *= number;
            }
        }
    }
    int operator [] (const int index){
        if(index < 0 || index > rows*cols){
            throw  "Error: index < 0 || index > rows*cols";
        }
        int i= 0;
        int *arr = new int[rows*cols];
        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                arr[i] = matrix_pointer[y][x];
                i++;
            }
        }
        return arr[index];
    }

    //Перегрузка оператора сложения
    Matrix operator + (const Matrix& matrix1){
        // Обработка некорректрных данных
        if(cols != matrix1.cols || rows != matrix1.rows){
            throw  "Error: cols != matrix1.cols || rows != matrix1.rows";
        }

        auto *new_matrix = new Matrix( matrix1.cols, this->rows);

        //Алгоритм сложения
        for (int i = 0; i < rows; i++){
            for (int j = 0; j < cols; j++){
                new_matrix->matrix_pointer[i][j] = this->matrix_pointer[i][j] + matrix1.matrix_pointer[i][j];

            }
        }
        // Результатом операции сумирования матриц является новая матрица
        return *new_matrix;
    }

    //Проверка на равенство
    bool operator == (const Matrix& matrix1){
        if(this->cols == matrix1.cols && this->rows == matrix1.rows){
            for(int y = 0;y<rows;y++){
                for(int x = 0;x<cols;x++){
                    //поэлементное сравнение
                    if(this-> matrix_pointer[y][x] != matrix1.matrix_pointer[y][x]){
                        return false;
                    }
                }
            }
        } else return false;
        return true;
    }


    //Оператор присваивания (копирование)
    Matrix& operator = (const Matrix& matrix){

        this->rows = matrix.rows;
        this->cols = matrix.cols;
        this->matrix_pointer = (int **) new int[cols * rows];

        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                //Поэлементное копирование
                this->matrix_pointer[y][x] = matrix.matrix_pointer[y][x];
            }
        }
        return *this;
    }
    friend std::ostream&  operator << (std::ostream &Matrix_out, const Matrix &matrix);
    friend std::ofstream&  operator << (std::ofstream &Matrix_out, const Matrix &matrix);
    friend void  operator >> (std::ifstream &Matrix_in, const Matrix &matrix);
};
std::ostream& operator<< (std::ostream &out, const Matrix &matrix) {
    for (int y = 0; y < matrix.rows; y++) {
        for (int x = 0; x < matrix.cols; x++) {
            out << std::setw(3)<< matrix.matrix_pointer[y][x] << " ";
        }
        out << std::endl;
    }
    return out;
}

std::ofstream& operator<< (std::ofstream &out, const Matrix &matrix) {
    for (int y = 0; y < matrix.rows; y++) {
        for (int x = 0; x < matrix.cols; x++) {
            out << std::setw(3)<< matrix.matrix_pointer[y][x] << " ";
        }
        out << std::endl;
    }
    return out;
}

void operator>>(std::ifstream &in, const Matrix &matrix) {
    for (int y = 0; y < matrix.rows; y++) {
        for (int x = 0; x < matrix.cols; x++) {
            in >> matrix.matrix_pointer[y][x];
        }
    }
}

class Matrix1{

    int rows, cols;
    void *matrix_pointer; //указатель на что то (динамическую память)

public:

    void dump(const char *ctx){
        std::cout << "Matrix1: " << ctx<< " " << this << " " << matrix_pointer << std::endl;
    }
    //Констуктор
    Matrix1(int ox, int oy) {
        this->cols =ox;
        this->rows = oy;
        // создание матрицы (выделение памяти)
        this->matrix_pointer = (int **) new int[cols * rows];
        std::cout << "Создание матрицы на " << cols * rows << " элементов [ " << this << " ]\n";
    }
    //Перегрузка конструктора копирования
    Matrix1(const Matrix1 & matrix1){
        this->rows = matrix1.rows;
        this->cols = matrix1.cols;
        this->matrix_pointer = (int **) new int[cols * rows];

        auto new_matrix = (int (*)[cols]) matrix_pointer;
        auto matrix = (int (*)[cols]) matrix1.matrix_pointer;

        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                new_matrix[y][x] = matrix[y][x];
            }
        }
        std::cout << "Создание матрицы [ " << this << " ] на " << cols * rows
        << " элементов из [ " << matrix1.matrix_pointer << " ]\n";
    }

    //деструктор
    ~Matrix1() {
        //Описано удаление 'одномерного' массива
        //std::free(matrix_pointer);
        std::cout << "\nУдаление матрицы на " << cols * rows << " элементов [ " << this << " " << matrix_pointer << " ]";
        delete [] (int*)matrix_pointer ;
    }

    // По скольку элементы каждого из вариантов в памяти хранятся по разному,
    // требуются разные способы взаимодействия с ними, но сами алгоритмы не меняются

    //  отличие
    //  auto this_matrix = (int (*)[cols]) matrix_pointer;
    //  Приведение выделенной памяти указанной длины (одномрного массива) к двумерному массиву
    //

    void fill_randomly(int range = 100){
        auto matrix = (int (*)[cols]) matrix_pointer;
        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                matrix[y][x] = rand()%range - range/4;
            }
        }
    }

    void print(int set_w = 4){
        auto matrix = (int (*)[cols]) matrix_pointer;
        std::cout << "\nprint_matrix ["<< rows << ":"<< cols <<"] \n";
        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                std::cout << std::setw(set_w) /*красивый вывод матриц на консоль*/
                          << matrix[y][x] << " ";
            }
            std::cout << std::endl;
        }
    }

    void transpose(){
        auto matrix = (int (*)[cols]) matrix_pointer;

        Matrix1 *result_matrix = new Matrix1( this->rows, this->cols);
        result_matrix ->dump("temp");
        auto new_matrix = (int (*)[result_matrix->cols]) result_matrix->matrix_pointer;
        //  Приведение новой памяти (*result_matrix) под матрицу (int (*)[result_matrix->cols])

        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                new_matrix[x][y] = matrix[y][x];
            }
        }
        this->rows = result_matrix->rows;
        this->cols = result_matrix->cols;
        delete [] (int *)this->matrix_pointer;
        this->matrix_pointer = result_matrix->matrix_pointer;
    }

    Matrix1 operator * (const Matrix1& matrix1){
        if(this->rows != matrix1.cols){
            throw  "Multiply ERROR: this->rows != matrix1.cols";
        }

        //Приведение void указателя в указатель на двумерный массив
        auto this_matrix = (int (*)[cols]) matrix_pointer;
        auto Multiplied_matrix = (int (*)[matrix1.cols]) matrix1.matrix_pointer;

        //Создание новой матрицы и приведение void указателя в указатель на двумерный массив
        auto *result_matrix = new Matrix1( matrix1.cols, this->rows);
        auto new_matrix = (int (*)[matrix1.cols]) result_matrix->matrix_pointer;


        for (int i = 0; i < rows; i++){
            for (int j = 0; j < matrix1.cols; j++){
                new_matrix[i][j] = 0;
                for (int k = 0; k < cols; k++) {
                    new_matrix[i][j] += this_matrix[i][k] * Multiplied_matrix[k][j];
                }
            }
        }
        return *result_matrix;
    }

    void multiply_by_number(int number){
        auto matrix = (int (*)[cols]) matrix_pointer;
        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                matrix[y][x] *= number;
            }
        }
    }

    Matrix1 operator + (const Matrix1& matrix1){
        if(cols != matrix1.cols || rows != matrix1.rows){
            throw  "Error: cols != matrix1.cols || rows != matrix1.rows";
        }

        auto matrix = (int (*)[cols]) matrix_pointer;
        auto addition_matrix = (int (*)[matrix1.cols]) matrix1.matrix_pointer;
        auto *result_matrix = new Matrix1( matrix1.cols, this->rows);
        auto new_matrix = (int (*)[cols]) result_matrix->matrix_pointer;

        for (int i = 0; i < rows; i++){
            for (int j = 0; j < cols; j++){
                new_matrix[i][j] = matrix[i][j] + addition_matrix[i][j];

            }
        }
        return *result_matrix;
    }

    bool operator == (const Matrix1& matrix1){
        auto matrix = (int (*)[cols]) matrix_pointer;
        auto compare_matrix = (int (*)[matrix1.cols]) matrix1.matrix_pointer;
        if(this->cols == matrix1.cols && this->rows == matrix1.rows){
            for(int y = 0;y<rows;y++){
                for(int x = 0;x<cols;x++){
                    if(matrix [y][x] != compare_matrix[y][x]){
                        return false;
                    }
                }
            }
        } else{
            return false;
        }
        return true;
    }

    int operator [] (const int index){
        if(index < 0 || index > rows*cols){
            throw  "Error: index < 0 || index > rows*cols";
        }

        auto array = (int *)matrix_pointer;
        return array[index];
    }

    Matrix1& operator = (const Matrix1& matrix1){

        this->rows = matrix1.rows;
        this->cols = matrix1.cols;
        this->matrix_pointer = (int **) new int[cols * rows];

        auto new_matrix = (int (*)[cols]) matrix_pointer;
        auto matrix = (int (*)[cols]) matrix1.matrix_pointer;

        for(int y = 0;y<rows;y++){
            for(int x = 0;x<cols;x++){
                new_matrix[y][x] = matrix[y][x];
            }
        }

        return *this;
    }
    friend std::ostream& operator<< (std::ostream &Matrix_out, const Matrix1 &matrix);
    friend std::ofstream&  operator << (std::ofstream &Matrix_out, const Matrix1 &matrix1);
    friend void  operator >> (std::ifstream &Matrix_in, const Matrix1 &matrix1);
};

std::ostream& operator<< (std::ostream &out, const Matrix1 &matrix) {
    auto matr = (int (*)[matrix.cols]) matrix.matrix_pointer;
    for (int y = 0; y < matrix.rows; y++) {
        for (int x = 0; x < matrix.cols; x++) {
            out << std::setw(3)<< matr[y][x] << " ";
        }
        out << std::endl;
    }
    return out;
}
std::ofstream&  operator << (std::ofstream &out, const Matrix1 &matrix) {
    auto matr = (int (*)[matrix.cols]) matrix.matrix_pointer;
    for (int y = 0; y < matrix.rows; y++) {
        for (int x = 0; x < matrix.cols; x++) {
            out << std::setw(3)<< matr[y][x] << " ";
        }
        out << std::endl;
    }
    return out;
}

void operator >> (std::ifstream &in, const Matrix1 &matrix) {
    auto matr = (int (*)[matrix.cols]) matrix.matrix_pointer;
    for (int y = 0; y < matrix.rows; y++) {
        for (int x = 0; x < matrix.cols; x++) {
            in >> matr[y][x];
        }
    }
}


int main() {


    srand(time(nullptr));

    // Создание на куче
    auto *heap_matrix1_1 = new Matrix1(10,5);
    auto *heap_matrix1_2 = new Matrix1(15,5);

    // Создание на стеке
    Matrix1 matrix1_1 (12,7);
    Matrix1 matrix1_2 (9,6);



    // тестирование методов
    Matrix1 matrix1_test(matrix1_2);
    // "heap_matrix1_1->" заменяет "(*heap_matrix1_1)."
    heap_matrix1_1->fill_randomly(20);
    heap_matrix1_2->fill_randomly(40);
    Matrix_in >> matrix1_1;
    matrix1_2.fill_randomly(10);

    std::cout << matrix1_2;

    heap_matrix1_1->print();
    heap_matrix1_2->print();
    matrix1_1.print();
    matrix1_2.print();

    Matrix_out << matrix1_2;

    try {
        //Обработка ошибки перемножения матриц
        Matrix1 matrix1_3 = *heap_matrix1_1 * *heap_matrix1_2;
      /*  Matrix1 matrix1_3 = heap_matrix1_1->operator+(*heap_matrix1_2);*/
        matrix1_2.print();

    } catch (const char* &error) {
        std::cerr << std::endl << error << std::endl;
    }

    heap_matrix1_2->transpose();
    Matrix1 matrix1_3 = *heap_matrix1_1 * *heap_matrix1_2;
    matrix1_3.print();
    matrix1_3.multiply_by_number(-1);
    matrix1_3.print(5);

    std::cout << matrix1_3[24] << " Обращение по индексу\n";
    std::cout << matrix1_3[14] << " Обращение по индексу\n";
    std::cout << matrix1_3[8] << " Обращение по индексу\n";
    try {
        std::cout << matrix1_3[266];
    } catch (const char* &error) {
        std::cerr << std::endl << error << std::endl;
    }

    delete heap_matrix1_1;
    delete heap_matrix1_2;

    std::cout<<"\n\n-----------------------------\n\n";

    auto *heap_matrix_1 = new Matrix(5,10);
    auto *heap_matrix_2 = new Matrix(15,5);

    // Создание на стеке

    Matrix matrix_2 (15,5);

    // тестирование методов
    Matrix matrix_test(matrix_2);
    // "heap_matrix_1->" заменяет "(*heap_matrix_1)."
    heap_matrix_1->fill_randomly(20);
    heap_matrix_2->fill_randomly(40);
    matrix_2.fill_randomly(10);

    heap_matrix_1->print();
    heap_matrix_1->transpose();
    heap_matrix_1->print();
    heap_matrix_2->print();
    matrix_2.print();
    std::cout << "Matrix1 \n" << matrix_2;


    try {
        //Обработка ошибки перемножения матриц
        Matrix matrix1_3 = *heap_matrix_1 + *heap_matrix_2;
        matrix_2.print();

    } catch (const char* &error) {
        std::cerr << std::endl << error << std::endl;
    }

    Matrix matrix_3 = *heap_matrix_2 + matrix_2;
    matrix_3.print();
    matrix_3.multiply_by_number(-1);
    matrix_3.print();


    delete heap_matrix_1;
    delete heap_matrix_2;
    return 0;
}