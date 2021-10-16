#include <iostream>

template<typename type_1>

class List {
public:
    List();

    ~List();


    void push_back(type_1 data);
    void insert(type_1 data, int index);
    void push_front(type_1 data);

    void pop_front();
    void pop_back();
    void removeAt(int index);
    void clear();
    int Get_size() { return size; }

    type_1 &operator[](const int index);

private:
    template<typename type_2>
    class Block {
    public:
        Block *next_p, *prev_p;
        type_2 data;

        Block(type_2 data = type_2(), Block *next_p = nullptr, Block *prev_p = nullptr) {
            this->data = data;
            this->next_p = next_p;
            this->prev_p = prev_p;
        }
    };

    int size;
    Block<type_1> *head;
    Block<type_1> *tail;

};

template<typename type_1>

List<type_1>::List() {
    size = 0;
    head = nullptr;
    tail = nullptr;

}

template<typename type_1>

List<type_1>::~List() {
    clear();
}

template<typename type_1>

void List<type_1>::push_back(type_1 data) {

    Block<type_1> *temp = new Block<type_1>;
    temp->next_p = nullptr;
    temp->data = data;
    temp->prev_p = tail;
    if (tail != nullptr) {
        tail->next_p = temp;
    }
    if (head == nullptr) {
        head = temp;
    }

    tail = temp;

    size++;
}

template<typename type_1>
type_1 &List<type_1>::operator[](const int index) {

    int counter = 0;
    Block<type_1> *current = this->head;
    while (current != nullptr) {
        if (counter == index) {
            return current->data;
        }
        current = current->next_p;
        counter++;
    }
    throw std::invalid_argument("index is out of range");
}

template<typename type_1>
void List<type_1>::pop_front() {

    Block<type_1> *old_head = head;
    if(head == nullptr){
        return;
    }
    if (tail == head) {
        head = nullptr;
        tail = nullptr;
    }
    else{
        head->prev_p = nullptr;
        head = head->next_p;
    }
    delete old_head;
    size--;

}

template<typename type_1>
void List<type_1>::clear() {
    while (size != 0) {
        pop_front();
    }

}

template<typename type_1>
void List<type_1>::push_front(type_1 data) {

    Block<type_1> *temp = new Block<type_1>;
    temp->data = data;

    if (head == NULL) //если список пуст
    {
        head = temp; //определяется голова списка
        tail = temp;
    } else {
        Block<type_1> *second = head;
        temp->next_p = head;
        head = temp;
        second->prev_p = head;
    }
    size++;
}

template<typename type_1>
void List<type_1>::insert(type_1 data, int index) {

    if (index == 0) {
        push_front(data);
    }
    if (index == Get_size()) {
        push_back(data);
    } else {

        Block<type_1> *temp = new Block<type_1>;
        temp->data = data;

        Block<type_1> *el_to_replace = head;
        for (int i = index; i > 0; i--) {
            if(el_to_replace == nullptr){
                //FIXME throw
                return;
            }
            el_to_replace = el_to_replace->next_p;
        }
        if(el_to_replace->prev_p == nullptr){
            ////FIXME
            return;
        }
        el_to_replace->prev_p->next_p = temp;
        temp->prev_p = el_to_replace->prev_p;
        temp->next_p = el_to_replace;
        el_to_replace->prev_p = temp;
        size++;

    }
}


template<typename type_1>
void List<type_1>::removeAt(int index) {

    if (index == 0) {
        pop_front();
    }
    if (index == (Get_size() - 1)) {
        pop_back();
    } else {

        Block<type_1> *previouse = this->head;

        for (int i = 0; i < index - 1; i++) {
            previouse = previouse->next_p;
        }

        Block<type_1> *Delete_el = previouse->next_p;

        previouse->next_p = Delete_el->next_p;

        delete Delete_el;
        size--;
    }

}

template<typename type_1>
void List<type_1>::pop_back() {

    Block<type_1> *temp = tail;

    if (temp == nullptr) {

        return;
    }


    if (tail == head) {
        head = nullptr;
        tail = nullptr;
    } else {
        temp->prev_p->next_p = temp->next_p;//null
        tail = temp->prev_p;
    }
    delete temp;
    size--;

}

using namespace std;

enum {
    CMD_EXIT,
    KILL_LAST
};


void Help_me() {
    cout << (int) CMD_EXIT << ". завершить работу\n";
    cout << "1. Добавить элемент в начало\n";
    cout << "2. Добавить элемент внутри списка \n";
    cout << "3. Добавить элемент в конец \n";
    cout << "4. Удалить первый элемент списка\n";
    cout << "5. Удалить элемент внутри списка\n";
    cout << "6. Удалить последний элемент списка\n";
    cout << "7. Узнать размер списка \n";
    cout << "8. Вывести список\n";
    cout << "9. Help\n";
    cout << "10.Отчистить список \n";
    cout << "\nНомер операции: ";
}


#define MY_TYPE long double
MY_TYPE cin_data;
List<MY_TYPE> l1;


void input_check() {
    MY_TYPE a;
    while (!(cin >> a)) {
        cout << "Ошибка ввода, нужен long double";
        cin.clear();
        while (cin.get() != '\n');
    }
    cin_data = a;
}

int index = -1;

int input_check_index() {
    int a;
    while (!(cin >> a)) {
        cout << "Ошибка ввода, нужен int  ";
        cin.clear();
        while (cin.get() != '\n');
    }

    return a;

}

void correct_index() {
    int a = -1;

    while (a < 0 || a >= l1.Get_size()) {
        a = input_check_index();
        if (a < 0 || a >= l1.Get_size()) {
            cout << "Ошибка ввода ";
        }
    }

    index = a;
}
void correct_index_zzz() {
    int a = -1;

    while (a < 0 || a > l1.Get_size()) {
        a = input_check_index();
        if (a < 0 || a > l1.Get_size()) {
            cout << "Ошибка ввода ";
        }
    }

    index = a;
}

void test_1(){

    List<float> list;
    list.insert(1,0);
    list.push_back(2);
    list.push_front(10);
    list.push_front(5);
    list.pop_front();
    list.insert(33, 2);
    list.removeAt(2);

    float expected_list[]={10,1,2};

    int expected_size = sizeof(expected_list)/sizeof(float);

    if(list.Get_size() != expected_size){
        cerr<< "FAILED - wrong number of elements"<<endl;
        exit(1);
    }

    int bugs_detected = 0;
    for(int i=0;i<expected_size;i++){
        if(expected_list[i] != list[i]){
            cerr<< "FAILED - wrong element at index["<< i <<"] ( "<< expected_list[i]<<" != "<< list[i]<< ")"<<endl;
            bugs_detected++;
        }
    }

    if(bugs_detected > 0){
        exit(1);
    }
    else{
        cerr<< "\nAll correct, no bug detected\n\n";
//        flush(cerr);
    }
}


int main() {


    test_1();

    int operation;
    Help_me();
    do {


        while (!(cin >> operation)) {
            cout << "Ошибка ввода, нужен int\n";
            cin.clear();
            while (cin.get() != '\n');
        }

        switch (operation) {
            case CMD_EXIT:
                cout << "\n***  Работа завершена  ***\n";
                break;
            case 1:
                cout << "Введите данные: ";
                input_check();
                l1.push_front(cin_data);
                cout << endl;
                cout << "Выполнено\n\nНомер операции: ";
                break;
            case 2:
                if (l1.Get_size() == 0) {
                    cout << "Ваш список пуст, элемент будет добавлен автоматически\n";
                    cout << "Введите данные: ";
                    input_check();
                    l1.push_front(cin_data);
                    cout << "Выполнено\n\nНомер операции: ";
                    break;
                }
                cout << "Введите данные: ";
                input_check();
                cout << "Позиция в списке от 0 до " << l1.Get_size() << ":";

                correct_index_zzz();
                l1.insert(cin_data, index);

                index = -1;
                cout << "Выполнено\n\nНомер операции: ";

                break;
            case 3:
                cout << "Введите данные: ";
                input_check();
                cout << endl;
                l1.push_back(cin_data);
                cout << "Выполнено\n\nНомер операции: ";
                break;
            case 4:
                if (l1.Get_size() == 0) {
                    cout << "Ваш список пуст(\nПопробуйте другую операцию: ";
                    break;
                }
                l1.pop_front();
                cout << "Выполнено\n\nНомер операции: ";
                break;
            case 5:
                if (l1.Get_size() == 0) {
                    cout << "Ваш список пуст(\nПопробуйте другую операцию: ";
                    break;
                }
                cout << "Позиция в списке от 0 до " << l1.Get_size() - 1 << ":";
                correct_index();
                l1.removeAt(index);
                index = -1;
                cout << "Выполнено\n\nНомер операции: ";
                break;
            case 6:
                if (l1.Get_size() == 0) {
                    cout << "Ваш список пуст(\nПопробуйте другую операцию: ";
                    break;
                }
                l1.pop_back();
                cout << "Выполнено\n\nНомер операции: ";
                break;
            case 7:
                cout << "Количество элементов в списке: " << l1.Get_size() << endl;
                cout << "Выполнено\n\nНомер операции: ";
                break;
            case 8:
                for (int i = 0; i < l1.Get_size(); i++) {
                    std::cout << l1[i] << "  ";
                }
                cout << "Выполнено\n\nНомер операции: ";
                break;
            case 9:
                Help_me();
                break;
            default:
                cout << "Ошибка ввода (Операции с таким номером нет) Введите (от 0 до 10) :";
                break;
            case 10:
                if(l1.Get_size() == 0){
                    cout << "Ваш список пуст(\nПопробуйте другую операцию: ";
                    break;
                }
                l1.clear();
                cout << "Выполнено\n\nНомер операции: ";
                break;
        }
    } while (operation != 0);
    return 0;
}


#if 0

template <typename type_1>
class Block{
public:
    Block *next_p;
    type_1 data;
    Block(type_1 data = type_1(), Block *next_p = nullptr){
        this->data = data;
        this->next_p = next_p;
    }
};
#endif


#if 0
Block<type_1> *block = new Block<type_1>;
    block->data = data;

    if(head == nullptr){
        block->next_p = block;
        block->prev_p = block;
        head = block;
    }
    else{
        Block<type_1> *current = this->head;
        while (current->next_p != nullptr){
            current = current->next_p;
        }
        current->next_p = new Block<type_1>(data);

    }
#endif

#if 0
template <typename type_1>
class Block{
public:
    Block *next_p;
    type_1 data;
    Block(type_1 data = type_1(), Block *next_p = nullptr){
        this->data = data;
        this->next_p = next_p;
    }
};

typedef Block<int> IntNode;
typedef Block<std::string> StringNode;

int main() {

IntNode * head = new IntNode(0);

    head = new IntNode(1, head);
    head = new IntNode(2, head);
    head = new IntNode(3, head);
    head = new IntNode(4, head);

    IntNode *it = head;
    while(it){
        std::cout << "[" << it->data << "]" << std::endl;
        it = it->next_p;
    }

    return 0;
}
#endif