# web development course (web-dev)
#### internet technologies course (i-tech)
## Course consists of 8 lab works:
    1. Fundamentals of building HTML documents
    2. Cascading Style Sheets (CSS)
    3. Manipulating HTML Document Elements with JavaScript
    4. Page generation on the server side
    5. Exploring PDO extension to provide database access abstraction
    6. MongoDB and client-side data storage
    7. Asynchronous data exchange with the server based on AJAX technology
    8. Full duplex communication based on the WebSocket data transfer protocol

### build & run
#### Build

Lab-works 1-3 do not require any build or dependencies (Plain HTML, CSS, JS).

Lab-works 4-7: PHP. Before 'run' you have to configure fpm/cli php.ini and execute 'composer install' where necessary.

Last lab-work: Start node.js server

#### Run
How to run ? One of the possible ways is to use Nginx.
1. Run script setup-nginx-config.sh (require nginx.config.template)
2. Go to lab-work. Default link: http://lwN.alxlab (where 'N' is a number of laboratory work)
3. Check nginx logs (._.)

---

# Курс по веб-разработки (web-dev)
#### Интернет технологии (i-tech)
## Курс состоит из 8 лабораторных работ
    1. Основы построения HTML-документов
    2. Каскадные таблицы стилей
    3. Управление элементами HTML-документов с помощью JavaScript
    4. Генерация страниц на стороне сервера
    5. Изучение расширения PDO для обеспечения абстракции доступа к базам данных
    6. NoSQL СУБД MongoDB и хранение данных на стороне клиента
    7. Асинхронный обмен данными с сервером на основе технологии AJAX
    8. Полнодуплексный обмен данными на основе протокола передачи данных WebSocket

### Сборка и запуск
#### Сборка

Лабораторные работы 1-3 не требуют сборки или дополнительных зависимостей (Обычный HTML, CSS, JS).

Лабораторные работы 4-7: PHP. Перед запуском вы должны настроить fpm/cli php.ini и выполнить 'composer install', где это необходимо.

Последняя лабораторная работа: Требуется запустить сервер (app.js)

#### Запуск
Один из возможных способов — использовать Nginx.
1. Запустите скрипт setup-nginx-config.sh (требуется nginx.config.template)
2. Перейти к лабораторной работе. Ссылка по умолчанию: http://lwN.alxlab (где N — номер лабораторных работ)
3. Проверьте логи nginx (._.)