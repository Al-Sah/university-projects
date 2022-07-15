#include <iostream>
#include <stack>
#include <string>

#include <iomanip>

#define CLR_NORMAL "\033[0m"
#define CLR_RED "\033[31;1;1m"
#define CLR_GREEN "\033[32;1;1m"

typedef  double OPERANT_TYPE;


using namespace std;
bool is_number(char a){
    string numbers = "1234567890.";
    return numbers.find(a) != string::npos;
}
bool is_operation(char a){
    string operation =  "-+*/() ";
    return operation.find(a) != string::npos;
}

bool priority(char a, char b){
    if( b == ')') { return false;}
    if( a == '(') { return true;}
    if( (a == b) || ((a == '*' || a == '/') && (b == '+' || b == '-' ))){
        return false;
    }if(((a == '+' || (a == '-')) && ((b == '-') || (b == '+')))){
        return false;
    }
    return !((a == '*' || a == '/') && ((b == '/' || b == '*')));
}

void system_info_parsing(string str,  std::stack<char> buffer, string data){
    float a = data.size() * 1.5;
    string temp_variable;
    if (buffer.empty()){
        temp_variable = "Буфер пуст";
    }
    while (!buffer.empty()) {
        temp_variable = temp_variable + buffer.top();
        buffer.pop();
    }
    cout << "Строка:  "<< std::setw(a)<< str << "   Буфер:  " << temp_variable << endl;
}
void system_info_calc(double res, std::stack<double> buffer, string data){
    float a = data.size() * 1.5;
    string temp_variable;
    if (buffer.empty()){
        temp_variable = "Буфер пуст";
    }
    while (!buffer.empty()) {
        temp_variable = temp_variable + to_string(buffer.top()) + "  ";
        buffer.pop();
    }
    cout << "Результат:  "<< std::setw(3) << res << "   Буфер:  " << temp_variable << endl;
}

void input_data(string &data, const string& good_chars){
    bool is_not_correct = false;
    do {
        cout << "Введите выражение: ";
        getline(cin, data);
        for (char i : data) {
            if (good_chars.find(i) == std::string::npos) {
                is_not_correct = true;
                cout << CLR_RED <<"\nОшибка ввода\n"<< CLR_NORMAL;
                break;
            } else {
                is_not_correct = false;
            }
        }
    } while (is_not_correct);
}

void parsing(string & data, string &parsed, stack<char> buffer, string temp_variable) {
    parsed = "";
    for (char i : data) {
        if (is_number(i)) {
            temp_variable.push_back(i);
        }
        else if(i == ' '){
            continue;
        }else {
            if (is_operation(i)) {
                if (!temp_variable.empty()) {
                    parsed += temp_variable;
                    system_info_parsing(parsed, buffer, data);
                    parsed.push_back(' ');
                    temp_variable.clear();
                }
                if (buffer.empty() || i == '(') {
                    buffer.push(i);
                    system_info_parsing(parsed, buffer, data);
                } else {
                    if (priority( buffer.top(),i)) {
                        buffer.push(i);
                        system_info_parsing(parsed, buffer, data);
                    } else {
                        while (!buffer.empty() && !priority(buffer.top(), i)) {
                            if (buffer.top() != '(') {
                                parsed =parsed + buffer.top()+ ' ';
                                system_info_parsing(parsed, buffer, data);
                            }
                            if (buffer.top() == '('){
                                buffer.pop();
                                break;
                            }
                            buffer.pop();
                        }
                        if (!buffer.empty() && buffer.top() == '(') {
                            buffer.pop();
                        }
                        if (i != ')') {buffer.push(i);}
                        system_info_parsing(parsed, buffer, data);
                    }
                }
            }
        }
    }
    if (!temp_variable.empty()){parsed = parsed + temp_variable + ' '; }
    while (!buffer.empty()) {
        parsed =parsed + buffer.top()+ ' ';
        system_info_parsing(parsed, buffer, data);
        buffer.pop();
        system_info_parsing(parsed, buffer, data);
    }
}

void calculator(string &parsed, stack<OPERANT_TYPE> calc_buffer, string temp_variable, OPERANT_TYPE &res){
    OPERANT_TYPE a = 0, b = 0, temp_double;
    res = 0;
    for(char i : parsed){
        if(is_number(i)){
            temp_variable.push_back(i);
        }else if(i == ' '){
            if(!temp_variable.empty()){ //size != 0
                temp_double = stod(temp_variable);
                calc_buffer.push(temp_double);
                temp_variable.clear();
                system_info_calc(res, calc_buffer, parsed);
            }
        }else if(is_operation(i)){
            if(!calc_buffer.empty()){
                a = calc_buffer.top();
                calc_buffer.pop();
            }else if(calc_buffer.empty()) {
                a = 0;
            }
            if(!calc_buffer.empty()){
                b = calc_buffer.top();
                calc_buffer.pop();
            }else if(calc_buffer.empty()) {
                b = 0;
            }
            switch (i) {
                case '-':
                    res = b - a;
                    break;
                case '+':
                    res = b + a;
                    break;
                case '/':
                    res = b / a;
                    break;
                case '*':
                    res = b * a;
                    break;
                default:
                    cout << "Ой-Ой";
                    break;
            }
            calc_buffer.push(res);
        }
    }
}


struct {
    const char *input_expression;
    const char *parsed_expression;
} test_cases_parsing[]={
        {"(2-2) + (24*(34-5*4)) -1 - 45*5-(35*12)-1","2 2 - 24 34 5 4 * - * + 1 - 45 5 * - 35 12 * - 1 - "},
        {"(2*(5+1))/3+7-1","2 5 1 + * 3 / 7 + 1 - "},
        {"-6 -5*4", "6 - 5 4 * - "}
};
struct {
    const char *parsed_expression;
    const char *counted;
} test_cases_calculator[]={
        {"2 2 - 24 34 5 4 * - * + 1 - 45 5 * - 35 12 * - 1 - ","-311"},
        {"2 5 1 + * 3 / 7 + 1 - ","10"},
//        {"3 5 / 5.1 * - 48.4 +", "45.34"} //-3/5*5.1 + 48.4
};


void parsing_test (string &parsed, stack<char> buffer, string temp_variable){
    int i = 0;
    cout << CLR_GREEN <<  "Parsing_test"<< CLR_NORMAL << endl;
    for(auto test_case_parsing: test_cases_parsing){
        ++i;
        string test_input = test_case_parsing.input_expression;
        parsing( test_input, parsed, buffer, temp_variable);
        if(parsed == test_case_parsing.parsed_expression){
            cout << "test №:" << i << CLR_GREEN <<  "  NICE"<< CLR_NORMAL << endl;
        }else {
            cout << "test №:" << i << CLR_RED << "  FAILED"<< CLR_NORMAL << endl;
        }
    }
}
void calculator_test(string &parsed, stack<OPERANT_TYPE> calc_buffer, string temp_variable, OPERANT_TYPE &res){
    int i = 0;
    cout << CLR_GREEN <<  "Calculator_test"<< CLR_NORMAL << endl;
    for(auto test_case_calculator : test_cases_calculator){
        ++i;
        string parsed = test_case_calculator.parsed_expression;
        calculator(parsed, calc_buffer, temp_variable, res);
        if(res == stod(test_case_calculator.counted)){
            cout << "test №:" << i << CLR_GREEN <<  "  NICE"<< CLR_NORMAL << endl;
        }else {
            cout << "test №:" << i << CLR_RED << "  FAILED"<< CLR_NORMAL << endl;
        }
    }
}
void help(){
    cout << "\n 0. Завершить работу\n";
    cout << " 1. Перевести в ОПЗ\n";
    cout << " 2. Перевести и посчитать выражение\n";
}



int main() {
    std::stack<char> buffer;
    std::stack<OPERANT_TYPE> calc_buffer;
    string output_data, data, temp_variable, parsed;
    OPERANT_TYPE res = 0;
    string good_chars = "1234567890+-*/(.) ";

    parsing_test(parsed, buffer, temp_variable);
    calculator_test(parsed, calc_buffer, temp_variable,res);


    help();
    int operation;

    do{
        cout << "\nВведите номер операции: ";
        while (!(cin >> operation)) {
            cout << "Ошибка ввода, нужен int\n";
            cin.clear();
            while (cin.get() != '\n');
        }
        cin.ignore();
        switch (operation) {
            case 0:
                cout << "\n***  Работа завершена  ***\n";
                break;
            case 1:
                input_data(data, good_chars);
                parsing(data,parsed, buffer, temp_variable);
                cout << "\nПеревод в ОПЗ:\n" << parsed;
                break;
            case 2:
                input_data(data, good_chars);
                parsing(data,parsed, buffer, temp_variable);
                calculator(parsed, calc_buffer, temp_variable, res);
                cout <<"\nРезультат "<< res;
                break;
            default:
                cout << "Такой операции нет";
                break;
        }
    } while (operation != 0);
    return 0;
}


#if 0
input_data(data, good_chars);
    parsing(data,parsed, buffer, temp_variable);
    cout << parsed;
    calculator(parsed, calc_buffer, temp_variable, res);

    cout <<"\nres "<< res;

vector<int> data;
for (int & i : data) {
while (!(cin >> i) && (reinterpret_cast<const char *>(i) == "1" || "2" ||"3" || "4" ||"5" || "6" ||"7" || "8" ||"9" || "0" ||"+" || "-" || "*"|| "/" || "(" || ")")) {
cout << "Ошибка ввода";
cin.clear();
while (cin.get() != '\n');
}


}
char a = '.';
    char b = '0';
    cout << " numb " <<  is_number(data[0]) << " smb " << is_operation(b) << endl;



char b1 = '1';
            char b1s =  "1";
            char b1s2[] = {'a', 'b', 'c', 0};
#endif