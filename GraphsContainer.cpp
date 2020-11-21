//
// Created by al_sah on 20.11.20.
//

#include "GraphsContainer.h"

template<class T>
void GraphsContainer<T>::push_back(T graph) {
    graphsVector.push_back(graph);
}

template<class T>
void GraphsContainer<T>::printGraphsInfo() {
    for(auto graph: graphsVector){
        graph->print_info();
    }
}

template<class T>
void GraphsContainer<T>::addArchsToGraph(T graph, int arc_number) {
    for(int i = 1; i <= arc_number; ++i){
        graph->AddArc(rand()%(graph->getVertex()-1)+1,rand()%(graph->getVertex()-1)+1);
    }
}

template<class T>
void GraphsContainer<T>::printGraph(T graph) {
    graph->print_info();
    graph->print_adjacency_matrix();
    graph->print_incidence_matrix();
}

template<class T>
void GraphsContainer<T>::printGraph(unsigned int id) {
    graphsVector[id]->print_info();
    graphsVector[id]->print_adjacency_matrix();
    graphsVector[id]->print_incidence_matrix();

}

template<class T>
void GraphsContainer<T>::pop_back() {
    graphsVector.pop_back();
}

template<class T>
void GraphsContainer<T>::clear() {
    graphsVector.clear();
}

template<class T>
T GraphsContainer<T>::operator[](const int index) {
    return graphsVector[index];
}
