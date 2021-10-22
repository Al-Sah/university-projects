#include "Graphs.h"
#include "GraphsContainer.h"
#include "GraphsContainer.cpp"

//Пример реаизации класса который может использовать Graph *graph
class [[maybe_unused]] graphController{

public:
    static void run(Graph *graph){
        std::cout << "\n*********************************************************** ";
        graph->print_info();
        graph->print_adjacency_matrix();
        graph->print_incidence_matrix();
    }
    static void HasArc(Graph *graph){
        std::cout << "\nHasArc (4,6): "
                  << graph->HasArc(4,6)
                  << "\nHasArc (2,3): "
                  << graph->HasArc(2,3)
                  << "\nHasArc (3,5): "
                  << graph->HasArc(3,5);
    }
    static void addArchs(Graph *graph, int arc_number){
        for(int i = 1; i <= arc_number; ++i){
            (*graph).AddArc(rand()%(graph->getVertex()-1)+1,rand()%(graph->getVertex()-1)+1);
        }
    }
};

int main() {
    //создание графов разных типов
    undirectedGraph undirectedGraph1(7), undirectedGraph2(15), undirectedGraph3(30);
    directedGraph directedGraph1(7), directedGraph2(15), directedGraph3(30);
    weightedGraph weightedGraph1(7), weightedGraph2(20), weightedGraph3(30);

    // Примеры использования коснтруктора копирования (тестирование)
    [[maybe_unused]] directedGraph directedGraph4(directedGraph1);
    [[maybe_unused]] undirectedGraph undirectedGraph4(undirectedGraph1);
    [[maybe_unused]] weightedGraph weightedGraph4(weightedGraph1);

    // Примеры использования коснтруктора перемещения (тестирование)
    [[maybe_unused]] weightedGraph weightedGraph5 = std::move(weightedGraph4);
    [[maybe_unused]] weightedGraph&& weightedGraph6 = weightedGraph(5);

    //Создание контейнера
    graphsContainer graphsContainer;

    graphsContainer.push_back(&undirectedGraph1);
    graphsContainer.push_back(&undirectedGraph2);
    graphsContainer.push_back(&undirectedGraph3);

    graphsContainer.push_back(&directedGraph1);
    graphsContainer.push_back(&directedGraph2);
    graphsContainer.push_back(&directedGraph3);

    graphsContainer.push_back(&weightedGraph1);
    graphsContainer.push_back(&weightedGraph2);
    graphsContainer.push_back(&weightedGraph3);

    //Добавление дуг и петель
    graphsContainer.addArchsToGraph(&directedGraph1, 10);
    graphsContainer.addArchsToGraph(&directedGraph2, 20);
    graphsContainer.addArchsToGraph(&directedGraph3, 40);

    graphsContainer.addArchsToGraph(&undirectedGraph1, 10);
    graphsContainer.addArchsToGraph(&undirectedGraph2, 20);
    graphsContainer.addArchsToGraph(&undirectedGraph3, 40);

    graphsContainer.addArchsToGraph(&weightedGraph1, 10);
    graphsContainer.addArchsToGraph(&weightedGraph2, 20);
    graphsContainer.addArchsToGraph(&weightedGraph3, 40);

    graphsContainer.printGraphsInfo();

    graphsContainer.printGraph(&directedGraph1);
    graphsContainer.printGraph(&directedGraph2);
    graphsContainer.printGraph(3); // &undirectedGraph1
    graphsContainer.printGraph(5); //&undirectedGraph3
    graphsContainer.printGraph(&weightedGraph1);
    graphsContainer.printGraph(&weightedGraph2);

    graphsContainer.pop_back();
    graphsContainer.clear();

    /*    GraphsContainer<Graph*> gc;
    GraphsContainer<class weightedGraph1*> gc1;
    GraphsContainer<class directedGraph1*> gc2;
    GraphsContainer<class undirectedGraph1*> gc3;
    gc3.addArchsToGraph(&undirectedGraph2, 5);*/
    return 0;
}