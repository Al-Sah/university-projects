#include <iostream>
#include <iomanip>
#include <map>
#include "GraphsContainer.h"

// цветной вывод в консоль
#define CLR_NORMAL "\033[0m"
#define CLR_GREEN "\033[32;1;1m"

//Базовый абстрактный класс
class Graph{
protected:
    //указатели на матрицы
    void *graph_pointer; // смежности
    void *incidence_matrix_pointer; //инцидентности

    int vertex_number;
    int arc_number;
    virtual void generate_incidence_matrix() = 0;
public:

    // Графы реализованы на основе матрицы смежности

    // Для реализации матриц использовался 2й вариант прошлого проекта "matrix-implementation"
    // Создаётся одномерный массив размером rows * cols (память выделена в одном месте),
    // после чего сводится к двумерному при помощи приведения типов

    //Определение количества ...
    virtual int getIsolatedVertices(); //...изолированных вершин
    virtual int getLoopNumber() const;  //...петель
    virtual int getVertex() const; //...всех вершин
    virtual int getArchs() const;  //...всех дуг
    virtual int getMultipleArcs() const;  //...кратных дуг

    // Координаты "first_vertex" и "second_vertex" добавляются в матрицу смежноси
    virtual void AddArc(int first_vertex, int second_vertex) =0; //Добавление дуги
    virtual bool HasArc(int first_vertex, int second_vertex) =0; //Проверка наличия дуги между вершинами
    virtual void print_adjacency_matrix();   // Вывод материалы смежности
    // Построение матрицы инцидентности происходит при каждом обращении к ней,
    // для этого используются данные из матрицы смежности
    //Генерирование матрицы инцидентности
    virtual void print_incidence_matrix(); // Вывод материалы инцидентности
    virtual void print_info() = 0; //Вывод информации про граф

    virtual void * getPointer(){
        return this->graph_pointer;
    }
};

int Graph::getVertex() const {
    return vertex_number;
}

int Graph::getArchs() const {
    return arc_number;
}

int Graph::getLoopNumber() const {
    int res = 0;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    //Обход по диагонали (кл-во итераций == колличеству вершин)
    for(int i = 0; i<vertex_number;i++){
        if( graph[i][i] >= 1){
            res += 1;
        }
    }
    return res;
}

int Graph::getIsolatedVertices(){
    auto graph = (int (*)[vertex_number]) graph_pointer;
    int count = vertex_number;
    //Обход всех элементов матрицы
    // Если вершина изолирована, все элементы в столбце соответствующей вершине равны 0
    for(int y = 0;y<vertex_number;y++) {
        for (int x = 0; x < vertex_number; x++) {
            if (graph[y][x] >= 1) {
                --count;
                break;
            }
        }
    }
    return count;
}
int Graph::getMultipleArcs() const {
    auto graph = (int (*)[vertex_number]) graph_pointer;
    int res = 0;
    for(int y = 0;y<vertex_number - y;y++) {
        for (int x = 0; x < vertex_number; x++) {
            if (graph[y][x] > 1) {
                ++res;
            }
        }
    }
    return res;
}


void Graph::print_adjacency_matrix(){
    auto graph = (int (*)[vertex_number]) graph_pointer;
    std::cout<< CLR_GREEN "\n  Adjacency matrix" << CLR_NORMAL << std::endl;
    std::cout << CLR_GREEN " V";
    for(int i = 1; i <= vertex_number;i++ ){
        std::cout << std::setw(3) << i;
    }
    std::cout << CLR_NORMAL << std::endl;
    for(int y = 0, i = 1; y < vertex_number; y++, i++){
        std::cout << CLR_GREEN << std::setw(2) << i << " " << CLR_NORMAL;
        for(int x = 0; x < vertex_number; x++){
            std::cout << std::setw(2) << graph[y][x] << " ";
        }
        std::cout << std::endl;
    }
}

void Graph::print_incidence_matrix() {
    generate_incidence_matrix();
    auto incidence_matrix = (int(*)[arc_number]) incidence_matrix_pointer;

    std::cout<<CLR_GREEN "\nIncidence matrix\n";
    std::cout << "V/arcs" << CLR_NORMAL << std::endl;
    for(int y = 0, i = 1; y < vertex_number; y++, i++){
        std::cout << CLR_GREEN << std::setw(2) << i << " " << CLR_NORMAL;
        for(int x = 0; x < arc_number; x++){
            std::cout << std::setw(2) << incidence_matrix[y][x] << " ";
        }
        std::cout << std::endl;
    }
}



class weightedGraph : public Graph{
    void generate_incidence_matrix()override;
public:

    int getMultipleArcs() const override;
    void AddArc(int first_vertex, int second_vertex)override;
    bool HasArc(int first_vertex, int second_vertex)override;
    void print_info()override;

    ~weightedGraph();
    weightedGraph(int vertex);

};

void weightedGraph::print_info() {
// Формирование и вывод информации про граф
    std::cout << "\n\nweightedGraph with " << getVertex() << " vertices and " << getArchs() << " arcs";
    std::cout << "\nLoop number: " << getLoopNumber();
    std::cout << "\nVertex number: " << getVertex();
    std::cout << "\nIsolated vertices: " << getIsolatedVertices();
    std::cout << "\nMultiple arcs: " << getMultipleArcs();
}

weightedGraph::~weightedGraph() {
    // Освобождение памяти
    std::cout<< "\n Deletion weightedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ][inc_matrix_ptr: " << incidence_matrix_pointer << " ]" << std::flush;
    delete [] (int*)graph_pointer ;
    if(incidence_matrix_pointer != nullptr){
        delete []  (int*)incidence_matrix_pointer;
    }
}

weightedGraph::weightedGraph(int vertex) {
    this->vertex_number = vertex;
    this->arc_number = 0;
    this->graph_pointer = (int **) new int[vertex * vertex];
    this->incidence_matrix_pointer = nullptr;
    std::cout<< "\n Created weightedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ]";
}


int weightedGraph::getMultipleArcs() const {
    return 0;
}

int price_check() {
    int price;
    while (!(std::cin >> price)) {
        std::cout << "Input error, you need type: (int)\nEnter correct data:";
        std::cin.clear();
        while (std::cin.get() != '\n');
    }
    return price;
}
void weightedGraph::AddArc(int first_vertex, int second_vertex) {
    //Проверка на корректность введённых данных
    if(first_vertex < 0 || first_vertex > vertex_number || second_vertex < 0 || second_vertex > vertex_number ){
        throw "Param Error";
    }else {
        //int price = price_check();
        int price = rand()%50;
        auto graph = (int (*)[vertex_number]) graph_pointer; // Добавление дуги в матрицу смежности
        int check = graph[first_vertex-1][second_vertex-1];
        if(first_vertex != second_vertex){ // Проверка на дугу
            graph[first_vertex-1][second_vertex-1] = price;
        }
        graph[second_vertex-1][first_vertex-1] = price;
        if(check == 0){
            arc_number += 1;
        }
    }
}

bool weightedGraph::HasArc(int first_vertex, int second_vertex) {
    //Проверка на корректность введённых данных
    if(first_vertex < 0 || first_vertex > vertex_number || second_vertex < 0 || second_vertex > vertex_number ){
        throw "Param Error";
    }else{
        auto graph = (int (*)[vertex_number]) graph_pointer;
        return graph [first_vertex-1][second_vertex-1];
    }
}

void weightedGraph::generate_incidence_matrix() {
    if(incidence_matrix_pointer != nullptr){
        //Если мы вызывали ранее generate_incidence_matrix,
        //осталась не освобождённая память, которую нужно отчистить
        delete []  (int*)incidence_matrix_pointer;
    }

    // Выделение памяти под матрицу инцидентности
    auto incidence_matrix_memory = (int(*)[arc_number]) new int[vertex_number * arc_number];
    // Привязка указателя на выделеную память
    this->incidence_matrix_pointer = incidence_matrix_memory;
    // Приведение типов (одномерный массив к двмерному)
    auto incidence_matrix = (int (*)[arc_number]) incidence_matrix_pointer;


    int iter = 0;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    // Алгоритм заполнения матрицы корректными данными
    for(int y = 0;y< vertex_number;y++){
        for(int x = y; x < vertex_number; x++){
            //incidence_matrix[y][iter] = graph[y][x];
            if(graph[y][x] >= 1 ){
                    if(x == y ){
                        incidence_matrix[y][iter] = graph[y][x];
                        iter++;
                    } else {
                        incidence_matrix[y][iter] = graph[y][x];
                        incidence_matrix[x][iter] = graph[y][x];
                        iter++;
                    }


            }
        }
    }
}







//Реализация ориентированного графа
class directedGraph : public Graph{
public:

    //Переопределённые методы базового класса
    int getIsolatedVertices() override;

    void AddArc(int first_vertex, int second_vertex)override;
    bool HasArc(int first_vertex, int second_vertex)override;
    void generate_incidence_matrix()override;
    void print_info()override;

    void * getPointer()override{
        return this->graph_pointer;
    }

    ~directedGraph();
    directedGraph(int vertex);
};

void directedGraph::print_info() {
// Формирование и вывод информации про граф
    std::cout << "\n\ndirectedGraph with " << getVertex() << " vertices and " << getArchs() << " arcs";
    std::cout << "\nLoop number: " << getLoopNumber();
    std::cout << "\nVertex number: " << getVertex();
    std::cout << "\nIsolated vertices: " << getIsolatedVertices();
    std::cout << "\nMultiple arcs: " << getMultipleArcs();
}

directedGraph::~directedGraph() {
    // Освобождение памяти
    std::cout<< "\n Deletion directedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ][inc_matrix_ptr: " << incidence_matrix_pointer << " ]" << std::flush;
    delete [] (int*)graph_pointer ;
    if(incidence_matrix_pointer != nullptr){
        delete []  (int*)incidence_matrix_pointer;
    }
}

directedGraph::directedGraph(int vertex) {
    this->vertex_number = vertex;
    this->arc_number = 0;
    this->graph_pointer = (int **) new int[vertex * vertex];
    this->incidence_matrix_pointer = nullptr;
    std::cout<< "\n Created directedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ]";
}


int directedGraph::getIsolatedVertices() {
    this->generate_incidence_matrix();
    auto incidence_matrix = (int(*)[arc_number]) incidence_matrix_pointer;
    int count = vertex_number;
    //Обход всех элементов матрицы
    // Если вершина изолирована, все элементы в столбце соответствующей вершине равны 0
    for(int y = 0;y<vertex_number;y++) {
        for (int x = 0; x < arc_number; x++) {
            if (incidence_matrix[y][x] >= 1) {
                --count;
                break;
            }
        }
    }
    return count;
}


void directedGraph::AddArc(int first_vertex, int second_vertex) {
    //Проверка на корректность введённых данных
    if(first_vertex < 0 || first_vertex > vertex_number || second_vertex < 0 || second_vertex > vertex_number ){
        throw "Param Error";
    }else{
        auto graph = (int (*)[vertex_number]) graph_pointer;
        graph[first_vertex-1][second_vertex-1] += 1; // Добавление дуги в матрицу смежности
        arc_number += 1;
    }
}

bool directedGraph::HasArc(int first_vertex, int second_vertex) {
    //Проверка на корректность введённых данных
    if(first_vertex < 0 || first_vertex > vertex_number || second_vertex < 0 || second_vertex > vertex_number ){
        throw "Param Error";
    }else{
        auto graph = (int (*)[vertex_number]) graph_pointer;
        return graph [first_vertex-1][second_vertex-1];
    }
}

void directedGraph::generate_incidence_matrix() {
    if(incidence_matrix_pointer != nullptr){
        //Если мы вызывали ранее generate_incidence_matrix,
        //осталась не освобождённая память, которую нужно отчистить
        delete []  (int*)incidence_matrix_pointer;
    }

    // Выделение памяти под матрицу инцидентности
    auto incidence_matrix_memory = (int(*)[arc_number]) new int[vertex_number * arc_number]{};
    // Привязка указателя на выделеную память
    this->incidence_matrix_pointer = incidence_matrix_memory;
    // Приведение типов (одномерный массив к двмерному)
    auto incidence_matrix = (int (*)[arc_number]) incidence_matrix_pointer;

    int iter = 0;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    // Алгоритм заполнения матрицы корректными данными
    for(int y = 0;y< vertex_number;y++){
        for(int x = 0; x < vertex_number; x++){
            //incidence_matrix[y][iter] = graph[y][x];
            if(graph[y][x] >= 1 ){
                for(int i = 0; i < graph[y][x]; ++i){
                    if(x == y ){
                        incidence_matrix[y][iter] = 1; // дуга
                        iter++;
                    } else {
                        incidence_matrix[y][iter] = 1;
                        incidence_matrix[x][iter] = -1; // направление
                        iter++;
                    }
                }

            }
        }
    }
}


class undirectedGraph : public Graph{
    void generate_incidence_matrix()override;
public:
    void AddArc(int first_vertex, int second_vertex)override;
    bool HasArc(int first_vertex, int second_vertex)override;

    void print_info()override;
    void * getPointer()override{
        return this->graph_pointer;
    }

    ~undirectedGraph();
    undirectedGraph(int vertex);

};

void undirectedGraph::print_info() {
// Формирование и вывод информации про граф
    std::cout << "\n\nundirectedGraph with " << getVertex() << " vertices and " << getArchs() << " arcs";
    std::cout << "\nLoop number: " << getLoopNumber();
    std::cout << "\nVertex number: " << getVertex();
    std::cout << "\nIsolated vertices: " << getIsolatedVertices();
    std::cout << "\nMultiple arcs: " << getMultipleArcs();
}

undirectedGraph::~undirectedGraph() {
    // Освобождение памяти
    std::cout<< "\n Deletion undirectedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ][inc_matrix_ptr: " << incidence_matrix_pointer << " ]" << std::flush;
    delete [] (int*)graph_pointer ;
    if(incidence_matrix_pointer != nullptr){
        delete []  (int*)incidence_matrix_pointer;
    }
}

undirectedGraph::undirectedGraph(int vertex){
    this->vertex_number = vertex;
    this->arc_number = 0;
    this->graph_pointer = (int **) new int[vertex * vertex];
    this->incidence_matrix_pointer = nullptr;
    std::cout<< "\n Created undirectedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ]";
}


void undirectedGraph::generate_incidence_matrix(){
    if(incidence_matrix_pointer != nullptr){
        //Если мы вызывали ранее generate_incidence_matrix,
        //осталась не освобождённая память, которую нужно отчистить
        delete []  (int*)incidence_matrix_pointer;
    }

    // Выделение памяти под матрицу инцидентности
    auto incidence_matrix_memory = (int(*)[arc_number]) new int[vertex_number * arc_number];
    // Привязка указателя на выделеную память
    this->incidence_matrix_pointer = incidence_matrix_memory;
    // Приведение типов (одномерный массив к двмерному)
    auto incidence_matrix = (int (*)[arc_number]) incidence_matrix_pointer;


    int iter = 0;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    // Алгоритм заполнения матрицы корректными данными
    for(int y = 0;y< vertex_number;y++){
        for(int x = y; x < vertex_number; x++){
            //incidence_matrix[y][iter] = graph[y][x];
            if(graph[y][x] >= 1 ){
                for(int i = 0; i < graph[y][x]; ++i){
                    if(x == y ){
                        incidence_matrix[y][iter] = 1;
                        iter++;
                    } else {
                        incidence_matrix[y][iter] = 1;
                        incidence_matrix[x][iter] = 1;
                        iter++;
                    }
                }

            }
        }
    }
}

void undirectedGraph::AddArc(int first_vertex, int second_vertex) {
    //Проверка на корректность введённых данных
    if(first_vertex < 0 || first_vertex > vertex_number || second_vertex < 0 || second_vertex > vertex_number ){
        throw "Param Error";
    }else{
        auto graph = (int (*)[vertex_number]) graph_pointer; // Добавление дуги в матрицу смежности
        if(first_vertex != second_vertex){ // Проверка на дугу
            graph[first_vertex-1][second_vertex-1] += 1;
        }
        graph[second_vertex-1][first_vertex-1] += 1;
        arc_number += 1;
    }
}

bool undirectedGraph::HasArc(int first_vertex, int second_vertex) {
    //Проверка на корректность введённых данных
    if(first_vertex < 0 || first_vertex > vertex_number || second_vertex < 0 || second_vertex > vertex_number ){
        throw "Param Error";
    }else{
        auto graph = (int (*)[vertex_number]) graph_pointer;
        return graph [first_vertex-1][second_vertex-1];
    }
}

/*class graphController{

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
    static void addArchs(Graph *graph, int vertex_number, int arc_number){
        for(int i = 1; i <= arc_number; ++i){
            //std::cout << "\nget p: " <<graph->getPointer();
            (*graph).AddArc(rand()%vertex_number,rand()%vertex_number);
        }
    }

};*/

int main() {
    undirectedGraph undirectedGraph(7), undirectedGraph1(15), undirectedGraph2(30);
    directedGraph directedGraph(7), directedGraph1(15), directedGraph2(30);
    weightedGraph weightedGraph(7), weightedGraph1(20), weightedGraph2(10);

    GraphContainer graphContainer;

    graphContainer.addToVector(&undirectedGraph);
    graphContainer.addToVector(&undirectedGraph1);
    graphContainer.addToVector(&undirectedGraph2);

    graphContainer.addToVector(&directedGraph);
    graphContainer.addToVector(&directedGraph1);
    graphContainer.addToVector(&directedGraph2);

    graphContainer.addToVector(&weightedGraph);
    graphContainer.addToVector(&weightedGraph1);
    graphContainer.addToVector(&weightedGraph2);

    //Добавление дуг и петель
    graphContainer.addArchsToGraph(&directedGraph, 10);
    graphContainer.addArchsToGraph(&directedGraph1, 20);
    graphContainer.addArchsToGraph(&directedGraph2, 40);

    graphContainer.addArchsToGraph(&undirectedGraph, 10);
    graphContainer.addArchsToGraph(&undirectedGraph1, 20);
    graphContainer.addArchsToGraph(&undirectedGraph2, 40);

/*    graphContainer.addArchsToGraph(&weightedGraph, 10);
    graphContainer.addArchsToGraph(&weightedGraph1, 20);
    graphContainer.addArchsToGraph(&weightedGraph2, 40);*/

    graphContainer.printElementsInfo();

    graphContainer.printGraph(&undirectedGraph);
    graphContainer.printGraph(&undirectedGraph2);

    graphContainer.printGraph(4);
    graphContainer.printGraph(3);

/*    graphContainer.printGraph(&weightedGraph);
    graphContainer.printGraph(&weightedGraph1);*/

    return 0;

/*    graphController graphController;
    graphController.addArchs(&graph, 7, 10);
    graphController.addArchs(&dr_graph, 7, 6);
    graphController.addArchs(&weightedGraph, 7, 6);*/
/*
    graph.AddArc(2, 3);
    graph.AddArc(1, 5);
    graph.AddArc(3, 5);
    graph.AddArc(3, 5);
    graph.AddArc(2, 2);
    graph.AddArc(2, 2);
    graph.AddArc(1, 3);

    graphController.run(&graph);
    graphController.run(&weightedGraph);
    graphController.addArchs(&dr_graph,7, 10);
    graphController.run(&dr_graph);

    dr_graph.print_info();
    dr_graph.print_incidence_matrix();
    dr_graph.print_adjacency_matrix();*/
/*
    std::cout << "\ndirectedGraph";
    graphController.HasArc(&dr_graph);
    std::cout << "\nweightedGraph";
    graphController.HasArc(&w_graph);
    std::cout << graph.getPointer() << std::endl;*/
    return 0;
}

