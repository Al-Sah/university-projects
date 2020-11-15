#include <iostream>
#include <iomanip>
#include <map>

// цветной вывод в консоль
#define CLR_NORMAL "\033[0m"
#define CLR_GREEN "\033[32;1;1m"

//Базовый абстрактный класс
class Graph{
public:

    // Графы реализованы на основе матрицы смежности

    // Для реализации матриц использовался 2й вариант прошлого проекта "matrix-implementation"
    // Создаётся одномерный массив размером rows * cols (память выделена в одном месте),
    // после чего сводится к двумерному при помощи приведения типов

    //Определение количества ...
    virtual int getIsolatedVertices() =0; //...изолированных вершин
    virtual int getLoopNumber() const =0;  //...петель
    virtual int getVertex() const =0;       //...всех вершин
    virtual int getMultipleArcs() const = 0;  //...кратных дуг

    // Координаты "first_vertex" и "second_vertex" добавляются в матрицу смежноси
    virtual void AddArc(int first_vertex, int second_vertex) =0; //Добавление дуги
    virtual bool HasArc(int first_vertex, int second_vertex) =0; //Проверка наличия дуги между вершинами
    virtual void print_adjacency_matrix() = 0;   // Вывод материалы смежности
    // Построение матрицы инцидентности происходит при каждом обращении к ней,
    // для этого используются данные из матрицы смежности
    virtual void generate_incidence_matrix() = 0; //Генерирование матрицы инцидентности
    virtual void print_incidence_matrix() = 0; // Вывод материалы инцидентности
    virtual void print_info() =0; //Вывод информации про граф
};



//Реализация ориентированного графа
class directedGraph : Graph{
    //указатели на матрицы
    void *graph_pointer; // смежности
    void *incidence_matrix_pointer; //инцидентности

    int vertex_number;
    int arc_number;

public:

    //Переопределённые методы базового класса
    int getIsolatedVertices() override;
    int getLoopNumber() const override;
    int getVertex() const override;
    int getMultipleArcs() const override;

    void AddArc(int first_vertex, int second_vertex)override;
    bool HasArc(int first_vertex, int second_vertex)override;
    void generate_incidence_matrix()override;
    void print_adjacency_matrix()override;
    void print_incidence_matrix()override;
    void print_info()override;


    ~directedGraph();
    directedGraph(int vertex);
};

directedGraph::~directedGraph() {
    // Освобождение памяти
    delete [] (bool*)graph_pointer ;
    if(incidence_matrix_pointer != nullptr){
        delete []  (int*)incidence_matrix_pointer;
    }
}

directedGraph::directedGraph(int vertex) {
    this->vertex_number = vertex;
    this->arc_number = 0;
    this->graph_pointer = (int **) new int[vertex * vertex];
    this->incidence_matrix_pointer = nullptr;
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

int directedGraph::getLoopNumber() const {
    int res = 0;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    //Обход по диагонали (кл-во итераций == колличеству вершин)
    for(int i = 0; i<vertex_number;i++){
        if( graph[i][i] >= 1){
            res += graph[i][i];
        }
    }
    return res;
}

int directedGraph::getVertex() const {
    return vertex_number;
}

int directedGraph::getMultipleArcs() const {
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
        return graph [first_vertex][second_vertex];
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

void directedGraph::print_adjacency_matrix() {
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

void directedGraph::print_incidence_matrix() {
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

void directedGraph::print_info() {
    // Формирование и вывод информации про граф
    std::cout << "\ndirectedGraph with " << vertex_number << " vertices and " << arc_number << " arcs";
    std::cout << "\nLoop number: " << getLoopNumber();
    std::cout << "\nVertex number: " << getVertex();
    std::cout << "\nIsolated vertices: " << getIsolatedVertices();
    std::cout << "\nMultiple arcs: " << getMultipleArcs();
}





class undirectedGraph : Graph{

    void *graph_pointer;
    void *incidence_matrix_pointer;
    int vertex_number;
    int arc_number;

public:

    int getIsolatedVertices()override;
    int getLoopNumber() const override;
    int getVertex() const override;
    int getMultipleArcs() const override;

    void AddArc(int first_vertex, int second_vertex)override;
    bool HasArc(int first_vertex, int second_vertex)override;
    void generate_incidence_matrix()override;
    void print_adjacency_matrix()override;
    void print_incidence_matrix()override;
    void print_info()override;

    ~undirectedGraph();
    undirectedGraph(int vertex);

};

undirectedGraph::~undirectedGraph() {
    // Освобождение памяти
    delete [] (bool*)graph_pointer ;
    if(incidence_matrix_pointer != nullptr){
        delete []  (int*)incidence_matrix_pointer;
    }
}

undirectedGraph::undirectedGraph(int vertex){
    this->vertex_number = vertex;
    this->arc_number = 0;
    this->graph_pointer = (int **) new int[vertex * vertex];
    this->incidence_matrix_pointer = nullptr;
}

int undirectedGraph::getLoopNumber() const {
    int res = 0;
    auto graph = (int (*)[vertex_number]) graph_pointer;
    //Обход по диагонали (кл-во итераций == колличеству вершин)
    for(int i = 0; i<vertex_number;i++){
        if( graph[i][i] >= 1){
            res += graph[i][i];
        }
    }
    return res;
}

int undirectedGraph::getVertex() const {
    return vertex_number;
}

int undirectedGraph::getIsolatedVertices(){
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

int undirectedGraph::getMultipleArcs() const {
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

void undirectedGraph::generate_incidence_matrix(){
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

void undirectedGraph::print_adjacency_matrix(){
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

void undirectedGraph::print_incidence_matrix() {
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
        return graph [first_vertex][second_vertex];
    }
}

void undirectedGraph::print_info() {
    // Формирование и вывод информации про граф
    std::cout << "\nundirectedGraph with " << vertex_number << " vertices and " << arc_number << " arcs";
    std::cout << "\nLoop number: " << getLoopNumber();
    std::cout << "\nVertex number: " << getVertex();
    std::cout << "\nIsolated vertices: " << getIsolatedVertices();
    std::cout << "\nMultiple arcs: " << getMultipleArcs() << "\n";
}


int main() {
    undirectedGraph graph(7);
    directedGraph dr_graph(7);

    //Добавление дуг и петель
    dr_graph.AddArc(2, 3);
    dr_graph.AddArc(1, 5);
    dr_graph.AddArc(3, 5);
    dr_graph.AddArc(3, 5);
    dr_graph.AddArc(2, 2);
    dr_graph.AddArc(1, 3);
    dr_graph.AddArc(5, 3);

    graph.AddArc(2, 3);
    graph.AddArc(1, 5);
    graph.AddArc(3, 5);
    graph.AddArc(3, 5);
    graph.AddArc(2, 2);
    graph.AddArc(2, 2);
    graph.AddArc(1, 3);


    graph.print_info();
    graph.print_adjacency_matrix();
    graph.print_incidence_matrix();

    dr_graph.print_info();
    dr_graph.print_adjacency_matrix();
    dr_graph.print_incidence_matrix();

    std::cout << "\nundirectedGraph\nHasArc (4,6): "
            << graph.HasArc(4,6)
            << "\nHasArc (2,3): "
            << graph.HasArc(2,3)
            << "\nHasArc (3,5): "
            << graph.HasArc(3,5);

    std::cout << "\ndirectedGraph\nHasArc (4,6): "
              << dr_graph.HasArc(4,6)
              << "\nHasArc (2,3): "
              << dr_graph.HasArc(2,3)
              << "\nHasArc (5,3): "
              << dr_graph.HasArc(3,5);
    return 0;
}

