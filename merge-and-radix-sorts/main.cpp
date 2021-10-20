#include <iostream>
#include<list>
#include<cmath>


template <typename my_type>
void FillArray(my_type arr[], size_t size){
    srand(0);
    for(int i = 0; i < size; i++){
        arr[i] = rand() % 1000;
    }
}

template <typename my_type>
void outArray(my_type arr[], size_t size){
    for(int i = 0; i < size; i++){
        std::cout << arr[i] << "  ";
    }
    std::cout << std::endl;
}


void Merge(int arr[], int p, int q, int r){

    std::size_t left_arr_size,right_arr_size,i,j,k;
    left_arr_size = q - p + 1;
    right_arr_size = r - q;

    int left_arr[left_arr_size], right_arr[right_arr_size];

    for(i=0; i < left_arr_size; i++){
        left_arr[i]=arr[p + i];
    }
    for(j=0; j < right_arr_size; j++){
        right_arr[j]=arr[q + j + 1];
    }
    i=0,j=0;

    for(k=p; i < left_arr_size && j < right_arr_size; k++){
        if(left_arr[i] < right_arr[j]){
            arr[k]=left_arr[i++];
        }
        else{
            arr[k]=right_arr[j++];
        }
    }

    while(i < left_arr_size){
        arr[k++]=left_arr[i++];
    }
    while(j < right_arr_size){
        arr[k++]=right_arr[j++];
    }
}

void MergeSort(int arr[], int p, int r){
    int temp;
    if(p<r){
        temp= (p + r) / 2;
        MergeSort(arr, p, temp);
        MergeSort(arr, temp + 1, r);
        Merge(arr, p, temp, r);
    }
}


void radix_sort(int arr[], size_t size) {

    int i, j, m, p, index, temp, count;

    if (size == 0 || size  == 1) {
        return;
    }

    std::list<int> pocket[10];

    for(i = 0; i < size; i++) {
        m = pow(10, i+1);
        p = pow(10, i);
        for(j = 0; j < size; j++) {
            temp = arr[j]%m;
            index = temp/p;
            pocket[index].push_back(arr[j]);
        }
        count = 0;
        for(j = 0; j<10; j++) {

            while(!pocket[j].empty()) {
                arr[count] = *(pocket[j].begin());
                pocket[j].erase(pocket[j].begin());
                count++;
            }
        }
    }
}

int main() {

    size_t size;
    std::cout << "Введите размер массива: ";
    std::cin >> size;
    int arr[size];
    std::cout << std::endl;

    std::cout << "сортировка слиянием\n";
    FillArray(arr, size);
    outArray(arr, size);
    MergeSort(arr,0,size-1);
    outArray(arr, size);

    std::cout << "\n\nпоразрядная сортировка\n";
    FillArray(arr, size);
    outArray(arr, size);
    radix_sort(arr,size);
    outArray(arr, size);



    return 0;
}
