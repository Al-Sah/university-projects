#ifndef GRAPHS_H
#define GRAPHS_H

#include <iostream>
#include <iomanip>
#include <vector>
#include <cstdlib>

// "конфигурация"
// Вывод в консоль дополнительной информации ( 0 - нет, 1 - да)
#define INCLUDE_EXTRA_INFO 0
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

    virtual void * getGraphPointer()const;
    virtual void * getIncidenceMatrixPointer()const;
    virtual std::string getVertexList() =0;
    virtual void setArces(int arch) ;

};


//Реализация взвешенного графа
class weightedGraph : public Graph{
    void generate_incidence_matrix()override;
public:

    int getMultipleArcs() const override;
    //При добавлении дуги в мето где уже есть дуга, цена перезаписывается, а кл-во дуг не меняется
    void AddArc(int first_vertex, int second_vertex)override;
    std::string getVertexList()override;

    ~weightedGraph();
    weightedGraph(int vertex);
};
// класс-контейнер
class GraphsContainer{
private:
    std::vector<Graph*> graphsVector; // структура данных позволяющая хранить объекты
public:
    void push_back(Graph* graph);
    void addArchsToGraph(Graph* *graph); // Добавление дуг в граф
    Graph* operator [] (int index); // Получение <T> из вектора по индексу
};

#endif // GRAPHS_H
