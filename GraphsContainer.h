//
// Created by al_sah on 20.11.20.
//

#ifndef PRACTIC3_OOP_GRAPHSCONTAINER_H
#define PRACTIC3_OOP_GRAPHSCONTAINER_H

#include <vector>
#include <cstdlib>
class Graph;

template <class T >
class GraphsContainer{
private:
    std::vector<T> graphsVector;
public:
    void addToVector(T graph);
    void printElementsInfo();
    void printGraph(T graph);
    void printGraph(unsigned int id);
    void addArchsToGraph(T graph, int arc_number);
};

typedef GraphsContainer<Graph*> GraphContainer;
#endif //PRACTIC3_OOP_GRAPHSCONTAINER_H
