//
// Created by al_sah on 20.11.20.
//

#ifndef PRACTIC3_OOP_GRAPHSCONTAINER_H
#define PRACTIC3_OOP_GRAPHSCONTAINER_H

#include <vector>
#include <cstdlib>
class Graph;

// класс-контейнер
template <class T >
class GraphsContainer{
private:
    std::vector<T> graphsVector; // структура данных позволяющая хранить объекты
public:
    void push_back(T graph);
    void pop_back();
    void clear();
    void printGraphsInfo(); // Вывод информации про все графы
    void printGraph(T graph); // Вывод информации, матрицы смежности и матрицы инцидентности одного графа
    void printGraph(unsigned int id); // Вывод информации, матрицы смежности и матрицы инцидентности одного графа (из вектора)
    void addArchsToGraph(T graph, int arc_number); // Добавление дуг в граф
    T operator [] (int index); // Получение <T> из вектора по индексу
};

typedef GraphsContainer<Graph*> graphsContainer;
#endif //PRACTIC3_OOP_GRAPHSCONTAINER_H
