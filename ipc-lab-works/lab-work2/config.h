//
// Created by Al_Sah on 18.10.2021.
//

#ifndef LAB_WORK2_CONFIG_H
#define LAB_WORK2_CONFIG_H

#define BYTES 1000

#define MIN_VALUE 33
#define MAX_VALUE 150

#define ENABLE_SYNCHRONIZATION
#ifdef ENABLE_SYNCHRONIZATION
#define INIT_STATE FALSE // non-signaled event state
#else
#define INIT_STATE TRUE // signaled event state
#endif

#endif //LAB_WORK2_CONFIG_H