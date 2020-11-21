#include <iostream>
#include <iomanip>
#include "GraphsContainer.h"
#include "GraphsContainer.cpp"

// "конфигурация"
// Вывод в консоль дополнительной информации ( 0 - нет, 1 - да)
#define INCLUDE_EXTRA_INFO 1
// Способ добавления цен на дугу во взвешенном графе (0 - вручную, 1 - рандом)
#define RANDOM_PRICE_GENERATION 1

// цветной вывод в консоль
#define CLR_NORMAL "\033[0m"
#define CLR_GREEN "\033[32;1;1m"
#define CLR_BLUE "\033[34m"

//Базовый абстрактный класс
class Graph{
protected:
    //указатели на матрицы
    void *graph_pointer; // смежности
    void *incidence_matrix_pointer; //инцидентности

    int vertex_number;
    int arc_number;
    virtual void generate_incidence_matrix() = 0;
    virtual void check_input(int v1, int v2);
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
    virtual bool HasArc(int first_vertex, int second_vertex); //Проверка наличия дуги между вершинами
    virtual void print_adjacency_matrix();   // Вывод материалы смежности
    // Построение матрицы инцидентности происходит при каждом обращении к ней,
    // для этого используются данные из матрицы смежности
    //Генерирование матрицы инцидентности
    virtual void print_incidence_matrix(); // Вывод материалы инцидентности
    virtual void print_info() = 0; //Вывод информации про граф
};

int Graph::getVertex() const {
    return vertex_number;
}

int Graph::getArchs() const {
    return arc_number;
}
void Graph::check_input(int v1, int v2) {
    if(v1 < 1 || v1 > vertex_number || v2 < 1 || v2 > vertex_number ){
        throw "Param Error"; // Создание исключения
    }
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
    } // Вывод матрицы
    std::cout << CLR_NORMAL << std::endl;
    for(int y = 0, i = 1; y < vertex_number; y++, i++){
        std::cout << CLR_GREEN << std::setw(2) << i << " " << CLR_NORMAL;
        for(int x = 0; x < vertex_number; x++){
            if(x == y){
                std::cout << CLR_GREEN << std::setw(2) << graph[y][x] << " "<< CLR_NORMAL;
            } else{
                if(graph[y][x] != 0){
                    std::cout << CLR_BLUE<< std::setw(2) << graph[y][x] << " "<< CLR_NORMAL;
                } else{
                    std::cout << std::setw(2) << graph[y][x] << " ";
                }

            }

        }
        std::cout << std::endl;
    }
}

void Graph::print_incidence_matrix() {
    generate_incidence_matrix();
    auto incidence_matrix = (int(*)[arc_number]) incidence_matrix_pointer;

    std::cout<<CLR_GREEN "\nIncidence matrix\n";
    std::cout << "V/arcs: " << arc_number << CLR_NORMAL << std::endl;
    if(arc_number == 0) return; // если нету дуг - нечего выводить
    for(int y = 0, i = 1; y < vertex_number; y++, i++){
        std::cout << CLR_GREEN << std::setw(2) << i << " " << CLR_NORMAL;
        for(int x = 0; x < arc_number; x++){
            if(incidence_matrix[y][x] == 0){
                std::cout << std::setw(2) << incidence_matrix[y][x] << " ";
            } else{
                std::cout << CLR_BLUE << std::setw(2) << incidence_matrix[y][x] << " " << CLR_NORMAL;
            }
        }
        std::cout << std::endl;
    }
}

bool Graph::HasArc(int first_vertex, int second_vertex) {
    try{
        check_input(first_vertex, second_vertex);
    } catch (const char* &error) {
        std::cerr << "\nInput error: index out of range [HasArc]";
        return false;
    }
    auto graph = (int (*)[vertex_number]) graph_pointer;
    return graph [first_vertex-1][second_vertex-1];
}

//Реализация взвешенного графа
class weightedGraph : public Graph{
    void generate_incidence_matrix()override;
public:

    int getMultipleArcs() const override;
    void AddArc(int first_vertex, int second_vertex)override;
    void print_info()override;

    ~weightedGraph();
    weightedGraph(int vertex);
    weightedGraph(const weightedGraph &weightedGraph); // конструктор копирования
    weightedGraph(weightedGraph &&weightedGraph); // конструктор перемещения

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
    #if INCLUDE_EXTRA_INFO
    std::cout << "\n Deletion weightedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ][inc_matrix_ptr: " << incidence_matrix_pointer << " ]" << std::flush;
    #endif
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
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Created weightedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ]";
    #endif
}
weightedGraph::weightedGraph(const weightedGraph &weightedGraph) {
    this->vertex_number = weightedGraph.vertex_number;
    this->arc_number = weightedGraph.arc_number;
    this->graph_pointer = (int **) new int[vertex_number * vertex_number];
    this->incidence_matrix_pointer = nullptr;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    auto matrixWG = (int (*)[weightedGraph.vertex_number]) weightedGraph.graph_pointer;
    for(int i = 0; i< this->vertex_number; i++){
        for(int j = 0; j < this->vertex_number; j++){
            graph[i][j] = matrixWG[i][j];
        }
    }
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Copied weightedGraph \n  from [graph.this: " << &weightedGraph << " ][graph_pointer: " << weightedGraph.graph_pointer << " ]"
    << "\n  To [this: "<< this << "][ graph_pointer:" << graph_pointer << " ]";
    #endif
}

weightedGraph::weightedGraph(weightedGraph &&weightedGraph){
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Transferring weightedGraph \n  from [graph.this: " << &weightedGraph << " ][graph_pointer: " << weightedGraph.graph_pointer << " ]"
             << "\n  To [this: "<< this << "]";
    #endif
    this->vertex_number = weightedGraph.vertex_number;
    this->arc_number = weightedGraph.arc_number;
    this->graph_pointer = weightedGraph.graph_pointer;
    this->incidence_matrix_pointer = weightedGraph.incidence_matrix_pointer;

    weightedGraph.graph_pointer = nullptr;
    weightedGraph.incidence_matrix_pointer = nullptr;
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
    try {
        this->check_input(first_vertex, second_vertex);
    } catch (const char* &error) {
        std::cerr << "\nInput error: index out of range [cased by weightedGraph.AddArc]" << std::flush;
        return;
    }
    #if RANDOM_PRICE_GENERATION
    int price = rand()%49+1;
    #else
    int price = price_check();
    #endif
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
    void generate_incidence_matrix()override;
    void print_info()override;

    ~directedGraph();
    directedGraph(int vertex);
    directedGraph(const directedGraph &directedGraph);  //констуктор копирования
    directedGraph(directedGraph &&directedGraph); // конструктор перемещения
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
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Deletion directedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ][inc_matrix_ptr: " << incidence_matrix_pointer << " ]" << std::flush;
    #endif
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
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Created directedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ]";
    #endif
}

directedGraph::directedGraph(const directedGraph &directedGraph) {
    this->vertex_number = directedGraph.vertex_number;
    this->arc_number = directedGraph.arc_number;
    this->graph_pointer = (int **) new int[vertex_number * vertex_number];
    this->incidence_matrix_pointer = nullptr;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    for(int i = 0; i< this->vertex_number; i++){
        for(int j = 0; j < this->vertex_number; j++){
            graph[i][j] = ((int (*)[directedGraph.vertex_number]) directedGraph.graph_pointer)[i][j];
        }
    }
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Copied directedGraph \n  from [graph.this: " << &directedGraph << " ][graph_pointer: " << directedGraph.graph_pointer << " ]"
    << "\n  To [this: "<< this << "][ graph_pointer:" << graph_pointer << " ]";
    #endif
}
directedGraph::directedGraph(directedGraph &&directedGraph){
    #if INCLUDE_EXTRA_INFO
    std::cout << "\n Transferring directedGraph \n  from [graph.this: " << &directedGraph << " ][graph_pointer: " << directedGraph.graph_pointer << " ]"
              << "\n  To [this: " << this << "]";
    #endif
    this->vertex_number = directedGraph.vertex_number;
    this->arc_number = directedGraph.arc_number;
    this->graph_pointer = directedGraph.graph_pointer;
    this->incidence_matrix_pointer = directedGraph.incidence_matrix_pointer;

    directedGraph.graph_pointer = nullptr;
    directedGraph.incidence_matrix_pointer = nullptr;
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
    try {
        this->check_input(first_vertex, second_vertex);
    } catch (const char* &error) {
        std::cerr << "\nInput error: index out of range [cased by directedGraph.AddArc]" << std::flush;
        return;
    }
    auto graph = (int (*)[vertex_number]) graph_pointer;
    graph[first_vertex-1][second_vertex-1] += 1; // Добавление дуги в матрицу смежности
    arc_number += 1;
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
    void print_info()override;
    ~undirectedGraph();
    undirectedGraph(int vertex);
    undirectedGraph(const undirectedGraph &undirectedGraph); //констуктор копирования
    undirectedGraph(undirectedGraph &&undirectedGraph); // конструктор перемещения

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
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Deletion undirectedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ][inc_matrix_ptr: " << incidence_matrix_pointer << " ]" << std::flush;
    #endif
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
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Created undirectedGraph [this: " << this << " ][graph_pointer: " <<graph_pointer << " ]";
    #endif
}

undirectedGraph::undirectedGraph(const undirectedGraph &undirectedGraph) {
    this->vertex_number = undirectedGraph.vertex_number;
    this->arc_number = undirectedGraph.arc_number;
    this->graph_pointer = (int **) new int[vertex_number * vertex_number];
    this->incidence_matrix_pointer = nullptr;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    for(int i = 0; i< this->vertex_number; i++){
        for(int j = 0; j < this->vertex_number; j++){
            graph[i][j] = ((int (*)[undirectedGraph.vertex_number]) undirectedGraph.graph_pointer)[i][j];
        }
    }
    #if INCLUDE_EXTRA_INFO
    std::cout<< "\n Copied undirectedGraph \n  from [graph.this: " << &undirectedGraph << " ][graph_pointer: " << undirectedGraph.graph_pointer << " ]"
    << "\n  To [this: "<< this << "][ graph_pointer:" << graph_pointer << " ]";
    #endif
}
undirectedGraph::undirectedGraph(undirectedGraph &&undirectedGraph){
    #if INCLUDE_EXTRA_INFO
    std::cout << "\n Transferring undirectedGraph \n  from [graph.this: " << &undirectedGraph << " ][graph_pointer: " << undirectedGraph.graph_pointer << " ]"
              << "\n  To [this: " << this << "]";
    #endif
    this->vertex_number = undirectedGraph.vertex_number;
    this->arc_number = undirectedGraph.arc_number;
    this->graph_pointer = undirectedGraph.graph_pointer;
    this->incidence_matrix_pointer = undirectedGraph.incidence_matrix_pointer;

    undirectedGraph.graph_pointer = nullptr;
    undirectedGraph.incidence_matrix_pointer = nullptr;
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
    try {
        this->check_input(first_vertex, second_vertex);
    } catch (const char* &error) {
        std::cerr << "\nInput error: index out of range [cased by undirectedGraph.AddArc]" << std::flush;
        return;
    }
    auto graph = (int (*)[vertex_number]) graph_pointer; // Добавление дуги в матрицу смежности
    if(first_vertex != second_vertex){ // Проверка на дугу
        graph[first_vertex-1][second_vertex-1] += 1;
    }
    graph[second_vertex-1][first_vertex-1] += 1;
    arc_number += 1;

}

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
    [[maybe_unused]] weightedGraph weightedGraph6 = weightedGraph(5);

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