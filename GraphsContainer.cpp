//
// Created by al_sah on 20.11.20.
//

#include "GraphsContainer.h"

template<class T>
void GraphsContainer<T>::addToVector(T graph) {
    graphsVector.push_back(graph);
}

template<class T>
void GraphsContainer<T>::printElementsInfo() {
    for(auto graph: graphsVector){
        graph->print_info();
    }
}

template<class T>
void GraphsContainer<T>::addArchsToGraph(T graph, int arc_number) {
    for(int i = 1; i <= arc_number; ++i){
        graph->AddArc(rand()%graph->getVertex(),rand()%graph->getVertex());
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
