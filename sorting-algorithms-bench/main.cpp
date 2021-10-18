#include <iostream>
#include <chrono>
#include <functional>
#include <iomanip>


#define MY_SWAP_TEMP_STORAGE(v1,v2) {auto tmp=v1;v1=v2;v2=tmp;}
#define MY_SWAP_ARITHMETIC(v1,v2) {v1+= v2;v2=v1-v2;v1=v1-v2;}
//#define MY_SWAP_XOR(v1,v2) { v1 = v2 ^ v1; v2 = v1 ^ v2;}

template <typename my_type>
void my_swap_temp_storage(my_type &v1,my_type &v2){
    my_type temp=v1;
    v1=v2;
    v2=temp;
}
template <typename my_type>
void my_swap_arithmetic(my_type &v1,my_type &v2){
    v1+= v2;
    v2=v1-v2;
    v1=v1-v2;
}

template <typename my_type>
void FillArray(my_type arr[], size_t size){
    srand(0);
    for(int i = 0; i < size; i++){
        arr[i] = rand() % 1000 - 40;
    }
}

template <typename my_type>
void outArray(my_type arr[], size_t size){
    for(int i = 0; i < 20; i++){
        std::cout << arr[i] << "  ";
    }
}

// bubble_sorts   ***************************************************

template <typename my_type>
void bubble_sort_standard_swap(my_type *arr, size_t size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                std::swap(arr[j + 1], arr[j]);
            }
        }
    }
}
template <typename my_type>
void bubble_sort_user_storage_swap(my_type *arr, size_t size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                my_swap_temp_storage(arr[j + 1], arr[j]);
            }
        }
    }
}
template <typename my_type>
void bubble_sort_user_arithmetic_swap(my_type *arr, size_t size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                my_swap_arithmetic(arr[j + 1], arr[j]);
            }
        }
    }
}
template <typename my_type>
void bubble_sort_temp_storage(my_type *arr, size_t size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                MY_SWAP_TEMP_STORAGE(arr[j + 1], arr[j])
            }
        }
    }
}
template <typename my_type>
void bubble_sort_arithmetic(my_type *arr, size_t size) {
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                MY_SWAP_ARITHMETIC(arr[j + 1], arr[j])
            }
        }
    }
}

//  my_shaker_stop_sorts  *******************************************
template <typename my_type>
void my_shaker_stop_sort_standard_swap(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        int counter = 0;
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                std::swap(arr[i - 1], arr[i]);
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                std::swap(arr[i - 1], arr[i]);
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        right--;
    }
}
template <typename my_type>
void my_shaker_stop_sort_user_storage_swap(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        int counter = 0;
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                my_swap_temp_storage(arr[i - 1], arr[i]);
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                my_swap_temp_storage(arr[i - 1], arr[i]);
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        right--;
    }
}
template <typename my_type>
void my_shaker_stop_sort_user_arithmetic_swap(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        int counter = 0;
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                my_swap_arithmetic(arr[i - 1], arr[i]);
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                my_swap_arithmetic(arr[i - 1], arr[i]);
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        right--;
    }
}

template <typename my_type>
void my_shaker_stop_sort_temp_storage(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        int counter = 0;
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                MY_SWAP_TEMP_STORAGE(arr[i - 1], arr[i])
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                MY_SWAP_TEMP_STORAGE(arr[i - 1], arr[i])
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        right--;
    }
}
template <typename my_type>
void my_shaker_stop_sort_arithmetic(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        int counter = 0;
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                MY_SWAP_ARITHMETIC(arr[i - 1], arr[i])
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                MY_SWAP_ARITHMETIC(arr[i - 1], arr[i])
                ++counter;
            }
        }
        if (counter == 0) {
            return;
        }
        right--;
    }
}


//  my_shaker_sorts  *******************************************
template <typename my_type>
void my_shaker_sort_standard_swap(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                std::swap(arr[i - 1], arr[i]);
            }
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                std::swap(arr[i - 1], arr[i]);
            }
        }
        right--;
    }
}
template <typename my_type>
void my_shaker_sort_user_storage_swap(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                my_swap_temp_storage(arr[i - 1], arr[i]);
            }
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                my_swap_temp_storage(arr[i - 1], arr[i]);
            }
        }
        right--;
    }
}
template <typename my_type>
void my_shaker_sort_user_arithmetic_swap(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                my_swap_arithmetic(arr[i - 1], arr[i]);
            }
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                my_swap_arithmetic(arr[i - 1], arr[i]);
            }
        }
        right--;
    }
}
template <typename my_type>
void my_shaker_sort_temp_storage(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                MY_SWAP_TEMP_STORAGE(arr[i - 1], arr[i])
            }
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                MY_SWAP_TEMP_STORAGE(arr[i - 1], arr[i])
            }
        }
        right--;
    }
}
template <typename my_type>
void my_shaker_sort_arithmetic(my_type *arr, size_t size) {
    size_t left, right;
    left = 1;
    right = size - 1;
    while (left <= right) {
        for (size_t i = right; i >= left; i--) {
            if (arr[i - 1] > arr[i]) {
                MY_SWAP_ARITHMETIC(arr[i - 1], arr[i])
            }
        }
        left++;
        for (size_t i = left; i <= right; i++) {
            if (arr[i - 1] > arr[i]) {
                MY_SWAP_ARITHMETIC(arr[i - 1], arr[i])
            }
        }
        right--;
    }
}
template <typename my_type>
void my_timer(my_type *arr, size_t size, void (*function)(my_type*, size_t) , const char * comment  ) {
    FillArray(arr, size);
    auto begin = std::chrono::steady_clock::now();
    function( arr, size);
    auto end = std::chrono::steady_clock::now();

    auto elapsed_ms = std::chrono::duration_cast<std::chrono::milliseconds>(end - begin);
    std::cout << "The time of "<< std::setw(40)<< comment<<" (arr size: "<<size<<") "<< ": " << elapsed_ms.count() << " ms\n";
    std::flush(std::cout);
}

#define MY_TIMER(ARR,SZ,FN) my_timer(ARR,SZ,FN, #FN)

void test_time(){
    size_t size = 50000;
    int arr[size];
    for(size_t i = 0, a = size; i < size; i++, a --){
        arr[i] = (int)a;
    }

    outArray(arr, size);
    std::cout << "\ntest 10 000 el (worst case)" << std::endl;
    auto begin1 = std::chrono::steady_clock::now();
    my_shaker_stop_sort_standard_swap(arr,size);
    auto end1 = std::chrono::steady_clock::now();
    auto elapsed_ms1 = std::chrono::duration_cast<std::chrono::nanoseconds>(end1 - begin1);
    std::cout << "The time of " <<" (arr size: "<<size<<") "<< ": " << elapsed_ms1.count() << " ms\n";

    outArray(arr, size);
    std::cout << "\ntest 10 000 el (best case)" << std::endl;
    auto begin = std::chrono::steady_clock::now();
    my_shaker_stop_sort_standard_swap(arr,size);
    auto end = std::chrono::steady_clock::now();
    auto elapsed_ms = std::chrono::duration_cast<std::chrono::nanoseconds>(end - begin);
    std::cout << "The time of " <<" (arr size: "<<size<<") "<< ": " << elapsed_ms.count() << " ms\n";

}


int main() {

    test_time();
    std::cout << "Тест закончен .......\n";

    size_t size;
    std::cout << "Введите размер массива: ";
    std::cin >> size;
    int arr[size];
    std::cout << std::endl;

    MY_TIMER(arr, size, bubble_sort_standard_swap);
    MY_TIMER(arr, size, bubble_sort_user_storage_swap);
    MY_TIMER(arr, size, bubble_sort_user_arithmetic_swap);
    MY_TIMER(arr, size, bubble_sort_temp_storage);
    MY_TIMER(arr, size, bubble_sort_arithmetic);
    std::cout << std::endl;
    MY_TIMER(arr, size, my_shaker_sort_standard_swap);
    MY_TIMER(arr, size, my_shaker_sort_user_storage_swap);
    MY_TIMER(arr, size, my_shaker_sort_user_arithmetic_swap);
    MY_TIMER(arr, size, my_shaker_sort_temp_storage);
    MY_TIMER(arr, size, my_shaker_sort_arithmetic);
    std::cout << std::endl;
    MY_TIMER(arr, size, my_shaker_stop_sort_standard_swap);
    MY_TIMER(arr, size, my_shaker_stop_sort_user_storage_swap);
    MY_TIMER(arr, size, my_shaker_stop_sort_user_arithmetic_swap);
    MY_TIMER(arr, size, my_shaker_stop_sort_temp_storage);
    MY_TIMER(arr, size, my_shaker_stop_sort_arithmetic);

    return 0;
}