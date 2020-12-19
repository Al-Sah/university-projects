#include "graphs.h"

int Graph::getVertex() const {
    return vertex_number;
}
int Graph::getArchs() const {
    return arc_number;
}
void * Graph::getGraphPointer()const{
    return graph_pointer;
}
void * Graph::getIncidenceMatrixPointer()const{
    return incidence_matrix_pointer;
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
void Graph::setArces(int arch){
    this->arc_number = arch;
}
int Graph::getIsolatedVertices() const{
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
     auto graph = (int (*)[vertex_number]) graph_pointer;
    for(int i = 0; i< this->vertex_number; i++){
        for(int j = 0; j < this->vertex_number; j++){
            graph[i][j] = 0;
        }
    }

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
std::string weightedGraph::getVertexList() {
    std::string out;
    out = "Vertex/Price \n";
    auto graph = (int (*)[vertex_number]) graph_pointer;
    for(int y = 0;y< vertex_number;y++){
        for(int x = y; x < vertex_number; x++){
            if(graph[y][x] >= 1 ){
                out = out +"[" + std::to_string(y+1) + " - " + std::to_string(x+1) + "] pr: " + std::to_string(graph[y][x]) + "\n";
            }
        }
    }
    return out;
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

void GraphsContainer::push_back(Graph* graph) {
    graphsVector.push_back(graph);
}

void GraphsContainer::addArchsToGraph(Graph * *graph) {
    int vertex =0, randD;
    for(int i = 1; i <= (*graph)->getVertex(); ++i){
        vertex = i;
        while(vertex == i){

           vertex = rand()%((*graph)->getVertex()-1)+1;
        }
        (*graph)->AddArc(i,vertex);

    }
    int counter = 0;
    auto graph_matrix = (int (*)[(*graph)->getVertex()])(*graph)->getGraphPointer();
    for(int i = 0; i <(*graph)->getVertex(); i++){
        counter = 0;
        for(int j = 0; j < (*graph)->getVertex(); j++){
            if(graph_matrix[i][j]>0){
                counter++;
            }
        }
        if(counter<4){
            randD = rand()%3;
            for(int x = 0; x < randD; ++x){
                vertex = i;
                while(vertex == i){
                   vertex = rand()%((*graph)->getVertex()-1)+1;
                }(*graph)->AddArc(i+1,vertex);
            }
        }
    }
}


Graph* GraphsContainer::operator[](const int index) {
    return graphsVector[index];
}

