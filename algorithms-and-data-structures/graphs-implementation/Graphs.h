//
// Created by al_sah on 23.11.20.
//
#ifndef PRACTIC3_OOP_GRAPHS_H
#define PRACTIC3_OOP_GRAPHS_H

// "конфигурация"
// Вывод в консоль дополнительной информации ( 0 - нет, 1 - да)
#define INCLUDE_EXTRA_INFO 1
// Способ добавления цен на дугу во взвешенном графе (0 - вручную, 1 - рандом)
#define RANDOM_PRICE_GENERATION 1


//Базовый абстрактный класс
class Graph{
protected:
    //указатели на матрицы
    void *graph_pointer{}; // смежности
    void *incidence_matrix_pointer{}; //инцидентности

    int vertex_number{};
    int arc_number{};
    virtual void generate_incidence_matrix() = 0;
    virtual void check_input(int v1, int v2);
public:

    // Графы реализованы на основе матрицы смежности

    // Для реализации матриц использовался 2й вариант прошлого проекта "matrix-implementation"
    // Создаётся одномерный массив размером rows * cols (память выделена в одном месте),
    // после чего сводится к двумерному при помощи приведения типов

    //Определение количества ...
    virtual int getIsolatedVertices() const; //...изолированных вершин
    virtual int getLoopNumber() const;  //...петель
    virtual int getVertex() const; //...всех вершин
    virtual int getArchs() const;  //...всех дуг
    virtual int getMultipleArcs() const;  //...кратных дуг

    // Координаты "first_vertex" и "second_vertex" добавляются в матрицу смежноси
    virtual void AddArc(int first_vertex, int second_vertex) =0; //Добавление дуги
    virtual bool HasArc(int first_vertex, int second_vertex); //Проверка наличия дуги между вершинами
    virtual void print_adjacency_matrix();   // Вывод материалы смежности
    // Построение матрицы инцидентности происходит при каждом обращении к ней,
    // для этого используются данные из матрицы смежности
    //Генерирование матрицы инцидентности
    virtual void print_incidence_matrix(); // Вывод материалы инцидентности
    virtual void print_info() = 0; //Вывод информации про граф
};


//Реализация взвешенного графа
class weightedGraph : public Graph{
    void generate_incidence_matrix()override;
public:

    int getMultipleArcs() const override;
    //При добавлении дуги в мето где уже есть дуга, цена перезаписывается, а кл-во дуг не меняется
    void AddArc(int first_vertex, int second_vertex)override;
    void print_info()override;

    ~weightedGraph();
    weightedGraph(int vertex);
    weightedGraph(const weightedGraph &weightedGraph); // конструктор копирования
    weightedGraph(weightedGraph &&weightedGraph); // конструктор перемещения

};

//Реализация ориентированного графа
class directedGraph : public Graph{
    void generate_incidence_matrix()override;
public:

    //Переопределённые методы базового класса
    int getIsolatedVertices() const override;
    void AddArc(int first_vertex, int second_vertex)override;
    void print_info()override;

    ~directedGraph();
    directedGraph(int vertex);
    directedGraph(const directedGraph &directedGraph);  //констуктор копирования
    directedGraph(directedGraph &&directedGraph); // конструктор перемещения
};


class undirectedGraph : public Graph{
    void generate_incidence_matrix()override;
public:

    void AddArc(int first_vertex, int second_vertex)override;
    void print_info()override;
    ~undirectedGraph();
    undirectedGraph(int vertex);
    undirectedGraph(const undirectedGraph &undirectedGraph); //констуктор копирования
    undirectedGraph(undirectedGraph &&undirectedGraph); // конструктор перемещения

};

#endif //PRACTIC3_OOP_GRAPHS_H
